using System.IO;
using FastNeutronCollar;
using GeometrySampling;
using GlobalHelpers;
using PoliMiRunner;

namespace Runner
{
    //public class nGen350FnclFuel : nGen350Fncl, IFuelModels
    //{
    //    private string fuelFile;
    //    private readonly bool useNgenSource;
    //    private const string COMMENT = "Fuel";

    //    public nGen350FnclFuel(string configurationFile, bool ActiveInterrogation, string additionalComment = "") : base(configurationFile, ActiveInterrogation, additionalComment)
    //    {
    //        useNgenSource = ActiveInterrogation;
    //    }

    //    public nGen350FnclFuel(ProblemConfig Config, bool ActiveInterrogation, string additionalComment = "") : base(Config, ActiveInterrogation, additionalComment)
    //    {
    //        useNgenSource = ActiveInterrogation;
    //    }

    //    public void SetFuelFile(string FuelFile)
    //    {
    //        fuelFile = Path.Combine(config.DataDirectory, FuelFile);
    //    }

    //    protected override void InitializeComponents()
    //    {
    //        AddComponent(new FuelAssemblyComponent(fuelFile, !useNgenSource));
    //        base.InitializeComponents();
    //    }
    //}


    public class nGen350Fncl : RunFnclDetector
    {
        protected static string COMMENT = "StarFire nGen350 DD FNCL";
        private bool useNgenSource;
        private Point3D sourceLocation;
        private Point3D nGenAxis;
        private double rotation;

        public nGen350Fncl(string configurationFile, bool ActiveInterrogation, string additionalComment = "") : base(
            configurationFile, COMMENT + " " + additionalComment)
        {
            InitializeDefaults(ActiveInterrogation);
        }

        public nGen350Fncl(ProblemConfig Config, bool ActiveInterrogation, string additionalComment = "") : base(Config,
            COMMENT + " " + additionalComment)
        {
            InitializeDefaults(ActiveInterrogation);
        }

        private void InitializeDefaults(bool ActiveInterrogation)
        {
            useNgenSource = ActiveInterrogation;
            nGenAxis = Extents.NGen350.Axis;
            sourceLocation = Extents.NGen350.InternalSourceLocation;
            rotation = 0;
        }

        protected override void SetUpFromSpecs(SimulationSpecification specs)
        {
            useNgenSource = specs.ActiveProblem;
            sourceLocation = specs.GeneratorSourcePosistion;
            nGenAxis = specs.GeneratorAxis;
            rotation = specs.RotationDegrees;
        }

        protected override PoliMiExecutor GetExecutor()
        {
            return new NGen350Executor(config, problemsToRun);
        }

        protected override string GetPrimaryDetectorFile()
        {
            return PoliMiMPPostInputHelper.GetFnclDetectorFile();
        }

        protected override string GetSecondaryDetectorFile()
        {
            return PoliMiMPPostInputHelper.GetNGen350DetectorFile();
        }

        protected override MPPostSpecification GetSecondaryDetectorDefault()
        {
            return DetectorFileMaker.GetNgen350Monitors();
        }

        protected override void InitializeComponents()
        {
            AddComponent(new StarFireNGen350(sourceLocation, nGenAxis, useNgenSource, heightDisplacement, rotation));
        }
        
    }
}
