using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GlobalHelpers;
using GlobalHelpersDefaults;
//using System.Xml.Serialization;
using Runner;

namespace GuiInterface
{
    public static class GuiLogicSimulation
    {
        private static ProblemConfig config;

        static GuiLogicSimulation()
        {
            config = new ProblemConfig();
            LoadDictionaries();
        }

        public static string GetPoliMiPath()
        {
            return config.FullPathToPoliMiExe;
        }

        public static string GetMPPostPath()
        {
            return config.FullPathToMPPostExe;
        }

        public static DetectorType GetDetectorType()
        {
            return config.Detector;
        }

        private static void LoadDictionaries()
        {
            try
            {
                ConfigureDictionaries.InitializeDictionaries();//config.DataDirectory);
            }
            catch
            {
                if (!string.IsNullOrEmpty(config.DataDirectory))
                {
                    MessageBox.Show("Could not Configure from : " + config.DataDirectory, "Error Data Directory",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void RunProblems(ModelTypes model, List<SimulationSpecification> problems)
        {
            List<SimulationSpecification> active = new List<SimulationSpecification>();
            List<SimulationSpecification> passive = new List<SimulationSpecification>();

            foreach (var p in problems)
            {
                if (p.ActiveProblem)
                {
                    active.Add(p);
                }
                else
                {
                    passive.Add(p);
                }
            }

            RunActiveProblems(model, active);
            RunPassiveProblems(model, passive);
        }

        private static List<SimulationSpecification> GetNonFuel(List<SimulationSpecification> mixed)
        {
            List<SimulationSpecification> nonFuel = new List<SimulationSpecification>();
            foreach (var m in mixed)
            {
                if (string.IsNullOrEmpty(m.FuelFile))
                {
                    nonFuel.Add(m);
                }
            }

            return nonFuel;
        }

        public static void SaveLastConfiguration(string LastPulseFile)
        {
            AnalysisConfigFiles.SaveLastRunConfig(new AnalysisConfigFiles.GuiLastRunConfig
            {
                DataDirectory = config.DataDirectory,
                DetectorBasis = config.DetectorBasisFile,
                PoliMiPath = config.FullPathToPoliMiExe,
                MPPostPath = config.FullPathToMPPostExe,
                PulseDirectory = GetPathOfPulseFile(LastPulseFile),
                Detector = config.Detector
            });
        }

        private static string GetPathOfPulseFile(string lastPulseFile)
        {
            try
            {
                return Path.GetFullPath(lastPulseFile);
            }
            catch
            {
                return string.Empty;
            }
        }

        private static List<SimulationSpecification> GetFuel(List<SimulationSpecification> mixed)
        {
            List<SimulationSpecification> fuel = new List<SimulationSpecification>();
            foreach (var m in mixed)
            {
                if (!string.IsNullOrEmpty(m.FuelFile))
                {
                    fuel.Add(m);
                }
            }

            return fuel;
        }

        private static void RunPassiveProblems(ModelTypes model, List<SimulationSpecification> passive)
        {
            RunProblemSet(PoliMiRunnerGuiHelper.GetFnclRunnerPassiveFuel(model), GetFuel(passive));
            RunProblemSet(PoliMiRunnerGuiHelper.GetModelRunnerPassiveNonFuel(model), GetNonFuel(passive));
        }

        private static void RunActiveProblems(ModelTypes model, List<SimulationSpecification> active)
        {
            RunProblemSet(PoliMiRunnerGuiHelper.GetFnclRunnerActiveFuel(model), GetFuel(active));
            RunProblemSet(PoliMiRunnerGuiHelper.GetFnclRunnerActiveNonFuel(model), GetNonFuel(active));
        }

        private static void RunProblemSet(IModelRunner runner, List<SimulationSpecification> problems)
        {
            if (problems.Count > 0)
            {
                if (string.IsNullOrEmpty(config.DetectorOutPutFile))
                {
                    SetDetectorBasis(config.DetectorBasisFile);
                }

                runner.SetConfig(config);
                runner.SetProblems(problems);
                runner.Run();
            }
        }

        public static void SetDetectorBasis(string detectorBasis)
        {
            config.DetectorBasisFile = detectorBasis;
            config.DetectorOutPutFile = Path.GetFileNameWithoutExtension(detectorBasis) + "Det.txt";
        }

        public static void SetMPPostExe(string mpPostExe)
        {
            config.FullPathToMPPostExe = mpPostExe;
        }

        public static void SetPoliMiExe(string poliMiExe)
        {
            config.FullPathToPoliMiExe = poliMiExe;
        }

        public static void InitializeFromLastRun()
        {
            config.DataDirectory = AnalysisConfigFiles.LastRunConfig.DataDirectory;
            config.DetectorBasisFile = AnalysisConfigFiles.LastRunConfig.DetectorBasis;
            config.FullPathToPoliMiExe = AnalysisConfigFiles.LastRunConfig.PoliMiPath;
            config.FullPathToMPPostExe = AnalysisConfigFiles.LastRunConfig.MPPostPath;
        }

        private static class AnalysisConfigFiles
        {
            public struct GuiLastRunConfig
            {
                public string DataDirectory { get; set; }
                public string DetectorBasis { get; set; }
                public string PoliMiPath { get; set; }
                public string MPPostPath { get; set; }
                public string PulseDirectory { get; set; }
                public DetectorType Detector { get; set; }

                public bool NotEmpty()
                {
                    return !string.IsNullOrEmpty(DataDirectory) ||
                           !string.IsNullOrEmpty(DetectorBasis) ||
                           !string.IsNullOrEmpty(PoliMiPath) ||
                           !string.IsNullOrEmpty(MPPostPath) ||
                           !string.IsNullOrEmpty(PulseDirectory);
                }
            }

            private const string LAST_RUN_FILE = "multiplicityConfig.txt";
            private static readonly string lastRunFile;
            public static GuiLastRunConfig LastRunConfig;

            static AnalysisConfigFiles()
            {
                lastRunFile = getLastRunConfigFile();
                if (File.Exists(lastRunFile))
                {
                    try
                    {
                        loadConfig();
                    }
                    catch
                    {
                        useDefaultConfig();
                    }
                }
                else
                {
                    useDefaultConfig();
                }
            }

            public static void SaveLastRunConfig(GuiLastRunConfig config)
            {
                if (config.NotEmpty())
                {
                    try
                    {
                        WriteToFlatFile(config);
                    }
                    catch
                    {
                        // Just don't write the file  
                    }
                }
            }

            private static void WriteToFlatFile(GuiLastRunConfig config)
            {
                using (StreamWriter sw = new StreamWriter(lastRunFile, false))
                {
                    sw.WriteLine(config.DataDirectory);
                    sw.WriteLine(config.DetectorBasis);
                    sw.WriteLine(config.PoliMiPath);
                    sw.WriteLine(config.MPPostPath);
                    sw.WriteLine(config.PulseDirectory);
                    sw.WriteLine(config.Detector.ToString());
                }
            }

            private static void ReadFromFlatFile()
            {
                useDefaultConfig();
                using (StreamReader sr = new StreamReader(lastRunFile))
                {
                    LastRunConfig.DataDirectory = sr.ReadLine();
                    LastRunConfig.DetectorBasis = sr.ReadLine();
                    LastRunConfig.PoliMiPath = sr.ReadLine();
                    LastRunConfig.MPPostPath = sr.ReadLine();
                    LastRunConfig.PulseDirectory = sr.ReadLine();
                    try
                    {
                        LastRunConfig.Detector = (DetectorType)Enum.Parse(typeof(DetectorType), sr.ReadLine());
                    }
                    catch
                    {
                        LastRunConfig.Detector = DetectorType.None;
                    }
                }
            }

            private static void useDefaultConfig()
            {
                LastRunConfig = new GuiLastRunConfig
                {
                    DataDirectory = string.Empty,
                    DetectorBasis = string.Empty,
                    PoliMiPath = string.Empty,
                    MPPostPath = string.Empty,
                    PulseDirectory = string.Empty
                };
            }

            private static void loadConfig()
            {
                try
                {
                    ReadFromFlatFile();
                }
                catch
                {
                    useDefaultConfig();
                }
            }

            private static string getLastRunConfigFile()
            {
                return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location),
                    LAST_RUN_FILE);
            }
        }
        
    }
}
