using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using FastNeutronCollar;
using GeometrySampling;
using GlobalHelpers;
using GlobalHelpersDefaults;
using PoliMiRunner;

namespace Runner
{
    public struct ProblemSpecification
    {
        public string BatchFile;
        public string PulseFile;
        public double SourceActivity;
        public int nMCNP;
        public int Seed;
        public Particle ParticleInProblem;
    }

    public static class ProblemSpecificationHelper
    {
        public static void WriteToFile(string file, ProblemSpecification specs)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file, false))
                {
                    sw.WriteLine(specs.PulseFile);
                    sw.WriteLine(specs.BatchFile);
                    sw.WriteLine(specs.ParticleInProblem);
                    sw.WriteLine(specs.nMCNP);
                    sw.WriteLine(specs.SourceActivity);
                    sw.WriteLine(specs.Seed);
                }
            }
            catch
            {
                throw new Exception("Failed to write ProblemSpecifications to " + file);
            }
        }

        public static ProblemSpecification ReadFromFile(string file)
        {
            ProblemSpecification specs = new ProblemSpecification();
            try
            {
                using (StringReader sr = new StringReader(file))
                {
                    specs.PulseFile = sr.ReadLine();
                    specs.BatchFile = sr.ReadLine();
                    specs.ParticleInProblem = (Particle)Enum.Parse(typeof(Particle), sr.ReadLine());
                    specs.nMCNP = int.Parse(sr.ReadLine());
                    specs.SourceActivity = double.Parse(sr.ReadLine());
                    specs.Seed = int.Parse(sr.ReadLine());
                }
            }
            catch
            {
                throw new Exception("Failed to read: " + file);
            }

            return specs;
        }
    }

    public abstract class RunFnclDetector : ModelRunner
    {
        protected Point3D CenterOfFNCL;
        protected double heightDisplacement;

        private FNCLcomponent fncl;

        protected RunFnclDetector(string configurationFile, string comment) : base(configurationFile, comment)
        {
            InitializeRunFNCL();
        }

        protected RunFnclDetector(ProblemConfig Config, string comment) : base(Config, comment)
        {
            InitializeRunFNCL();
        }

        private void InitializeRunFNCL()
        {
            CenterOfFNCL = GlobalDefaults.CENTER;
            heightDisplacement = 0;
            fncl = new FNCLcomponent();
            AddComponent(fncl);
        }

        protected override PoliMiExecutor GetExecutor()
        {
            return new FnclExecutor(config, problemsToRun);
        }

        public override void DisplaceHeightFromCenter(double HeightDisplacement)
        {
            heightDisplacement = HeightDisplacement;
            CenterOfFNCL = GlobalDefaults.CENTER;
            CenterOfFNCL.Z += HeightDisplacement;
            fncl.RaiseOrLowerFNCL(HeightDisplacement);
        }

        protected override void AddBaseComponent()
        {
            AddComponent(fncl);
            base.AddBaseComponent();
        }

        protected override MPPostSpecification GetPrimaryDetectorDefault()
        {
            return DetectorFileMaker.GetFnclDetectorDefault();
        }
    }

    [Serializable]
    public struct ProblemConfig
    {
        public string DataDirectory { get; set; }
        public string ResultsDirectory { get; set; }
        public string DetectorBasisFile { get; set; }
        public string DetectorOutPutFile { get; set; }
        public string FullPathToPoliMiExe { get; set; }
        public string FullPathToMPPostExe { get; set; }
        public List<int> GateWidthNanoSeconds { get; set; }
        public double PreDelay { get; set; }
        public double LongDelay { get; set; }
        public DetectorType Detector { get; set; }
    }

    public static class ProblemConfigurationHelper
    {
        private static XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProblemConfig));

        public static ProblemConfig GetConfig(string configFile)
        {
            if (File.Exists(configFile))
            {
                FileStream reader = new FileStream(configFile, FileMode.Open);
                return (ProblemConfig)xmlSerializer.Deserialize(reader);
            }
            else
            {
                throw new Exception("Configuration file not found: " + configFile);
            }
        }

        public static void WriteConfig(string configFile, ProblemConfig config)
        {
            FileStream writer = new FileStream(configFile, FileMode.Create);
            xmlSerializer.Serialize(writer, config);
            writer.Close();
        }
    }
}
