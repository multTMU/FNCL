using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FastNeutronCollar;
using GlobalHelpers;
using GlobalHelpersDefaults;
using Multiplicity;
using PoliMiRunner;

namespace Runner
{
    public abstract class ModelRunner
    {
        protected MPPostSpecification primaryDetector;
        protected MPPostSpecification secondaryDetector;

        private const bool DEFAULT_PARALLEL = true;
        private const string MCNP_FILE = "mcnp.inp";
        private const string SPEC_FILE = "poliMiSpecs.inp";
        private int NPS;
        protected ProblemConfig config;
        protected List<string> description;

        protected List<ProblemSpecification> problemsToRun;
        private List<IComponentSpecification> components;
        private string ProblemDirectory;
        private string MCNPfile;
        private PoliMiExecutor runner;

        private const double NO_DEFINED_ACTIVITY = 0;
        private bool useComponentSource;
        protected SourceSpecification sourceSpecification;

        protected IComponentSpecification soureModel;

        protected ModelRunner(string configurationFile, string comment)
        {
            // Must be first to establish dictionaries
            config = ProblemConfigurationHelper.GetConfig(configurationFile);
            InitializeModelRunner(comment);
        }

        public void AddSourceModel(IComponentSpecification SourceModel)
        {
            soureModel = SourceModel;
        }

        protected ModelRunner(ProblemConfig Config, string comment)
        {
            config = Config;
            InitializeModelRunner(comment);
        }

        private void InitializeModelRunner(string comment)
        {
            InitializeDictionaries();
            InitializeLists();
            description.Add(comment);
            runner = GetExecutor();
            useComponentSource = true;
            primaryDetector = GetPrimaryDetectorDefault();
            secondaryDetector = GetSecondaryDetectorDefault();
        }

        public void SetUpFromGenericSpecifications(SimulationSpecification specs)
        {
            description.Add(specs.Description);
            SetUpFromSpecs(specs);
        }

        public void OverridePrimaryDetector(MPPostSpecification detector)
        {
            primaryDetector = detector;
        }

        public void OverrideSecondaryDetector(MPPostSpecification detector)
        {
            secondaryDetector = detector;
        }

        protected abstract void SetUpFromSpecs(SimulationSpecification specs);
        public abstract void DisplaceHeightFromCenter(double heightDisplacement);
        protected abstract PoliMiExecutor GetExecutor();

        public void OverrideComponentSource(SourceSpecification newSource)
        {
            sourceSpecification = newSource;
            OverrideComponentSource();
        }

        public void OverrideComponentSource()
        {
            // case when sourceSpecification is defined in another component (e.g. fuel pins)
            useComponentSource = false;
        }

        public void MakeMCNPfiles(string directoryName, int nps, Particle particleInProblem,
            double SourceActivityScalar = NO_DEFINED_ACTIVITY)
        {
            NPS = nps;
            ProblemDirectory = directoryName;
            MCNPfile = GetFileInWorkingDir(MCNP_FILE);

            RefreshComponents();
            InitializeComponents();
            GlobalDefaults.SetParticleImportance(particleInProblem);

            WriteMcnpFile();

            primaryDetector.SetDetectorCells(PoliMiMPPostInputHelper.GetDetectors());
            primaryDetector.SetNPS(NPS);
            primaryDetector.WriteToFile(GetFileInWorkingDir(GetPrimaryDetectorFile()));

            if (PoliMiMPPostInputHelper.IncludeAdditionalDetector())
            {
                secondaryDetector.SetDetectorCells(PoliMiMPPostInputHelper.GetDetectors());
                secondaryDetector.SetNPS(NPS);
                secondaryDetector.WriteToFile(GetFileInWorkingDir(GetSecondaryDetectorFile()));
            }

            if (SourceActivityScalar == NO_DEFINED_ACTIVITY)
            {
                SourceActivityScalar = NPS;
            }

            MakeFilesToRun(SourceActivityScalar, particleInProblem);
        }

        protected abstract string GetPrimaryDetectorFile();

        protected virtual string GetSecondaryDetectorFile()
        {
            return string.Empty;
        }

        private void WriteMcnpFile()
        {
            MakeInputFile mcnp;
            if (useComponentSource)
            {
                mcnp = new MakeInputFile(MCNPfile, description, components, NPS);
            }
            else
            {
                mcnp = new MakeInputFile(MCNPfile, description, components, sourceSpecification, NPS);
            }

            mcnp.WriteFile();
        }

        protected abstract MPPostSpecification GetPrimaryDetectorDefault();

        protected virtual MPPostSpecification GetSecondaryDetectorDefault()
        {
            return new MPPostSpecification();
        }

        private void MakeFilesToRun(double SourceActivityScalar, Particle particleInProblem)
        {
            ProblemSpecification spec = new ProblemSpecification
            {
                BatchFile = runner.MakeBatchFile(MCNPfile),
                PulseFile = runner.GetPulseFileFromMCNPinput(MCNPfile),
                SourceActivity = SourceActivityScalar,
                nMCNP = NPS,
                ParticleInProblem = particleInProblem
            };

            WritePoliMiSpecsToFile(spec);
            problemsToRun.Add(spec);
        }

        private void WritePoliMiSpecsToFile(ProblemSpecification spec)
        {
            PulsesHelper.PoliMiSimulations simulations =
                new PulsesHelper.PoliMiSimulations(spec.PulseFile, spec.nMCNP, spec.SourceActivity);
            simulations.WriteToFile();
        }

        private void InitializeLists()
        {
            problemsToRun = new List<ProblemSpecification>();
            description = new List<string>();
            components = new List<IComponentSpecification>();
        }

        private string GetFileInDataDir(string file)
        {
            return Path.Combine(config.DataDirectory, file);
        }

        private void RefreshComponents()
        {
            components.Clear();
            AddBaseComponent();
        }

        protected virtual void AddBaseComponent()
        {
            if (soureModel != null)
            {
                AddComponent(soureModel);
            }
        }

        private string GetFileInWorkingDir(string file)
        {
            string newDirectory;

            if (string.IsNullOrEmpty(config.ResultsDirectory))
            {
                newDirectory = ProblemDirectory;
            }
            else
            {
                newDirectory = Path.Combine(config.ResultsDirectory, ProblemDirectory);
            }

            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }

            return Path.Combine(newDirectory, file);
        }

        protected abstract void InitializeComponents();

        private void InitializeDictionaries()
        {
            ConfigureDictionaries.InitializeDictionaries();//config.DataDirectory);
        }

        protected void AddComponent(IComponentSpecification newComponent)
        {
            components.Add(newComponent);
        }

        public void RunPoliMiPostAndAnalysis(bool parallel = DEFAULT_PARALLEL)
        {
            Task.Run(() =>
                Run(parallel, true)).ConfigureAwait(false);
        }

        public void RunPoliMiandMPPost(bool parallel = DEFAULT_PARALLEL)
        {
            Task.Run(() =>
                Run(parallel, false)).ConfigureAwait(false);
        }

        private void Run(bool parallel, bool doAnalysis)
        {
            if (parallel)
            {
                runner.RunSimulationAndAnalysisParallel(doAnalysis);
            }
            else
            {
                runner.RunSimulationAndAnalysis(doAnalysis);
            }

            problemsToRun.Clear();
        }

        public string GetLatestPulseFile()
        {
            return problemsToRun.Last().PulseFile;
        }
    }
}
