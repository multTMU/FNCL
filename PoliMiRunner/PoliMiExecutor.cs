using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using GlobalHelpers;
using GlobalHelpersDefaults;
using Multiplicity;

namespace Runner
{
    public class NGen350Executor : FnclExecutor
    {
        public NGen350Executor(ProblemConfig Config, List<ProblemSpecification> ProblemSpecsToRun) : base(Config,
            ProblemSpecsToRun)
        {
        }

        protected override string GetSecondMpPostDetectorFile()
        {
            return PoliMiMPPostInputHelper.GetNGen350DetectorFile();
        }
    }

    public class NGammaExecutor : PoliMiExecutor
    {
        public NGammaExecutor(ProblemConfig Config, List<ProblemSpecification> ProblemSpecsToRun) : base(Config,
            ProblemSpecsToRun)
        {
        }

        // For now just copy FNCL, as we have 12 detectors
        protected override Pulses<PoliMiPulse> GetPulses(ProblemSpecification probSpec)
        {
            return PulsesHelper.GetDefaultFncLPoliMiPulses(probSpec.PulseFile,
                probSpec.SourceActivity, probSpec.nMCNP,
                probSpec.Seed);
        }

        protected override List<int> GetGates()
        {
            var gates = new List<int>();
            gates.Add((int)NGammaHelpers.COINCIDENCE_INTERVAL);
            gates.AddRange(config.GateWidthNanoSeconds);
            return gates;
        }

        protected override IMultiplicityGate GetMultGate(Pulses<PoliMiPulse> pulses)
        {
            return MultiplicityGatesHelper.GetMultiplicityGate(pulses.Clone(), (int)config.PreDelay,
                (int)config.LongDelay);
        }

        protected override List<int> GetDetectors()
        {
            return FnclHelpers.GetPoliMiDetectors();
        }

        protected override List<string> GetMpPostDetectorFile()
        {
            return new List<string>() {PoliMiMPPostInputHelper.GetNGamDetectorFile()};
        }
    }

    public class FnclExecutor : PoliMiExecutor
    {
        public FnclExecutor(ProblemConfig Config, List<ProblemSpecification> ProblemSpecsToRun) : base(Config,
            ProblemSpecsToRun)
        {
        }

        protected override Pulses<PoliMiPulse> GetPulses(ProblemSpecification probSpec)
        {
            return PulsesHelper.GetDefaultFncLPoliMiPulses(probSpec.PulseFile,
                probSpec.SourceActivity, probSpec.nMCNP,
                probSpec.Seed);
        }

        protected override List<int> GetGates()
        {
            var gates = new List<int>();
            gates.Add((int)FnclHelpers.COINCIDENCE_INTERVAL);
            gates.AddRange(config.GateWidthNanoSeconds);
            return gates;
        }

        protected override IMultiplicityGate GetMultGate(Pulses<PoliMiPulse> pulses)
        {
            return MultiplicityGatesHelper.GetMultiplicityGate(pulses.Clone(), (int)config.PreDelay,
                (int)config.LongDelay);
        }

        protected override List<int> GetDetectors()
        {
            return FnclHelpers.GetPoliMiDetectors();
        }

        protected override List<string> GetMpPostDetectorFile()
        {
            List<string> mmpostFiles = new List<string>();
            mmpostFiles.Add(PoliMiMPPostInputHelper.GetFnclDetectorFile());
            if (PoliMiMPPostInputHelper.IncludeAdditionalDetector())
            {
                mmpostFiles.Add(GetSecondMpPostDetectorFile());
            }

            return mmpostFiles;
        }

        protected virtual string GetSecondMpPostDetectorFile()
        {
            return PoliMiMPPostInputHelper.GetHe3DetectorFile();
        }
    }

    public abstract class PoliMiExecutor
    {
        public bool RanWithoutErrors { get; private set; }

        private const int GOOD_EXIT = 0;
        private const string BATCH_FILE = "runPoliMi_MPPost.bat";
        private const string PULSE_FILE_EXT = "_All_pulses.o";
        private const string MULTIPLET_RESULT_EXT = ".mult";
        private const string MATICES_RESULT_EXT = ".matmult";
        private const string INP = "inp=";
        private const string OUT = "out=";
        private const string OUT_EXT = ".out";

        protected ProblemConfig config;
        private List<ProblemSpecification> problemSpecsToRun;

        protected PoliMiExecutor(ProblemConfig Config, List<ProblemSpecification> ProblemSpecsToRun)
        {
            config = Config;
            problemSpecsToRun = ProblemSpecsToRun;
            RanWithoutErrors = true;
        }

        public void RunSimulationAndAnalysis(bool doAnalysis)
        {
            RanWithoutErrors = true;
            foreach (var prob in problemSpecsToRun)
            {
                RunProblem(prob, doAnalysis);
            }
        }

        private void RunProblem(ProblemSpecification problemSpecs, bool doAnalysis)
        {
            if (!ExecuteBatchFile(problemSpecs.BatchFile))
            {
                RanWithoutErrors = false;
            }

            if (File.Exists(problemSpecs.PulseFile) && doAnalysis)
            {
                RunShiftRegisterAndMultipletMatices(problemSpecs);
            }
        }

        public void RunSimulationAndAnalysisParallel(bool doAnalysis)
        {
            List<List<ProblemSpecification>> batchesOfProblems = GetBatchesOfParallelProblems();
            foreach (var batch in batchesOfProblems)
            {
                Parallel.ForEach(batch, (problem) => RunProblem(problem, doAnalysis));
            }
        }

        private List<List<ProblemSpecification>> GetBatchesOfParallelProblems()
        {
            List<List<ProblemSpecification>> batchesOfProblems = new List<List<ProblemSpecification>>();
            List<ProblemSpecification> batch = new List<ProblemSpecification>();
            foreach (var p in problemSpecsToRun)
            {
                batch.Add(p);
                if (batch.Count >= (Environment.ProcessorCount - 1)
                ) // should leave a processor free for everything else right?
                {
                    batchesOfProblems.Add(batch);
                    batch = new List<ProblemSpecification>();
                }
            }

            batchesOfProblems.Add(batch);
            return batchesOfProblems;
        }

        protected abstract Pulses<PoliMiPulse> GetPulses(ProblemSpecification probSpec);
        protected abstract List<int> GetGates();
        protected abstract IMultiplicityGate GetMultGate(Pulses<PoliMiPulse> Pulses);
        protected abstract List<int> GetDetectors();

        protected virtual int GetPredelay()
        {
            return (int)config.PreDelay;
        }

        protected virtual int GetLongDelay()
        {
            return (int)config.LongDelay;
        }

        private void RunShiftRegisterAndMultipletMatices(ProblemSpecification probSpec)
        {
            List<MultiplicityRates> multipletRates = new List<MultiplicityRates>();
            List<Dictionary<DoublesKey, MultiplicityRates>> multipletMatrices =
                new List<Dictionary<DoublesKey, MultiplicityRates>>();

            Pulses<PoliMiPulse> pulses = GetPulses(probSpec);
            IMultiplicityGate multGate = GetMultGate(pulses);

            List<int> gates = GetGates();

            foreach (var g in gates)
            {
                multipletRates.Add(MultiplicityRatesHelper<PoliMiPulse>.GetMultiplicityRates(multGate, g));
                multipletMatrices.Add(MultipletMatricesHelper<PoliMiPulse>.GetMultipletRatesMatrix(pulses,
                    GetDetectors(), g, GetPredelay(), GetLongDelay()));
            }

            WriteMultipletFile(probSpec, multipletRates);
            WriteMutlipletMatricesFile(probSpec, multipletMatrices);
        }

        private void WriteMutlipletMatricesFile(ProblemSpecification probSpec,
            List<Dictionary<DoublesKey, MultiplicityRates>> multipletMatrices)
        {
            string file = Path.ChangeExtension(probSpec.PulseFile, MATICES_RESULT_EXT);
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Detectors\t" + MultiplicityRates.HEADER);
                foreach (var m in multipletMatrices)
                {
                    sw.Write(m.Keys.ToString() + "\t" + m.Values.ToString());
                }
            }
        }

        private void WriteMultipletFile(ProblemSpecification probSpec, List<MultiplicityRates> multipletRates)
        {
            string file = Path.ChangeExtension(probSpec.PulseFile, MULTIPLET_RESULT_EXT);
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(MultiplicityRates.HEADER);
                foreach (var m in multipletRates)
                {
                    sw.WriteLine(m.ToString());
                }

                sw.WriteLine();
                sw.WriteLine("Activity: " + probSpec.SourceActivity + " NPS: " + probSpec.nMCNP);
                sw.WriteLine(MultiplicityRates.HEADER);
                foreach (var m in multipletRates)
                {
                    sw.WriteLine(m.ToString());
                }
            }
        }

        private bool ExecuteBatchFile(string batchFileToRun)
        {
            int exitCode;
            string batchFile = Path.GetFileName(batchFileToRun);
            string directory = Path.GetDirectoryName(batchFileToRun);

            ProcessStartInfo processInfo = new ProcessStartInfo("cmd")
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = false,
                UseShellExecute = false,
                WorkingDirectory = directory,
                Arguments = "/c start /wait " + batchFile
            };

            Process process = Process.Start(processInfo);
            process.WaitForExit();
            exitCode = process.ExitCode;
            process.Close();

            return exitCode == GOOD_EXIT;
        }

        public string GetPulseFileFromMCNPinput(string fileName)
        {
            string workDir = Path.GetDirectoryName(fileName);
            string pulseFile = Path.Combine(workDir,
                Path.GetFileNameWithoutExtension(config.DetectorOutPutFile) + PULSE_FILE_EXT);
            return pulseFile;
        }

        private string GetPostCommand(string detectorName)
        {
            return config.FullPathToMPPostExe + " " + detectorName;
        }

        private string GetPoliMiCommand(string file)
        {
            return config.FullPathToPoliMiExe + " " + INP + Path.GetFileName(file) + " " + OUT +
                   Path.ChangeExtension(Path.GetFileName(file), OUT_EXT);
        }

        public string MakeBatchFile(string fileName)
        {
            string batchFile = Path.Combine(Path.GetDirectoryName(fileName), BATCH_FILE);
            using (StreamWriter sw = new StreamWriter(batchFile))
            {
                sw.WriteLine(GetPoliMiCommand(fileName));
                foreach (var m in GetMpPostDetectorFile())
                {
                    sw.WriteLine(GetPostCommand(m));
                }

                sw.WriteLine("exit");
            }

            return batchFile;
        }

        protected abstract List<string> GetMpPostDetectorFile();
    }
}
