using FastNeutronCollar;
using GlobalHelpers;

namespace Runner
{
    //interface IFuelModels
    //{
    //    //void SetActiveOverFuelSource(bool useActiveInterrogationSource);
    //    void SetFuelFile(string FuelFile);
    //}

    //public class AmLiFuelFNCL : AmLiFNCL, IFuelModels
    //{
    //    private const string COMMENT = "Fuel";
    //    private string fuelFile;
    //    private bool useFuelSource;

    //    public AmLiFuelFNCL(ProblemConfig Config, bool UseAmLiOverSpontaneousFission, AmLiBlockTypes AmLiBlock,
    //        string comment) : base(
    //        Config, UseAmLiOverSpontaneousFission, AmLiBlock, COMMENT + " " + comment)
    //    {
    //        SetActiveOverFuelSource(UseAmLiOverSpontaneousFission);
    //    }

    //    public AmLiFuelFNCL(string configurationFile, bool UseAmLiOverSpontaneousFission, AmLiBlockTypes AmLiBlock,
    //        string comment) : base(
    //        configurationFile, UseAmLiOverSpontaneousFission, AmLiBlock, COMMENT + " " + comment)
    //    {
    //        SetActiveOverFuelSource(UseAmLiOverSpontaneousFission);
    //    }

    //    private void SetActiveOverFuelSource(bool useActiveInterrogationSource)
    //    {
    //        useFuelSource = !useActiveInterrogationSource;
    //    }

    //    public void SetFuelFile(string FuelFile)
    //    {
    //        fuelFile = Path.Combine(config.DataDirectory, FuelFile);
    //    }

    //    protected override void InitializeComponents()
    //    {
    //        AddComponent(new FuelAssemblyComponent(fuelFile, useFuelSource));
    //        base.InitializeComponents();
    //    }
    //}

    public class AmLiFNCL : RunFnclDetector
    {
        private const string COMMENT = "AmLi Source FNCL";

        // private MyPoint3D blockCenter;
        //private MyPoint3D blockExtents;
        //private MyPoint3D amLiCenter;
        //private double caseThickness;
        //private int blockMat;
        //protected int caseMat;
        private double magnitudeRight;
        private double magnitudeLeft;
        private AmLiBlockTypes amLiBlock;
        protected bool activeInterrogation;

        public AmLiFNCL(ProblemConfig Config, bool ActiveInterrogation, AmLiBlockTypes AmLiBlock,
            string additionalComment = "") : base(Config,
            COMMENT + " " + additionalComment)
        {
            InitializeAmLiFncl(ActiveInterrogation, AmLiBlock);
        }

        public AmLiFNCL(string configurationFile, bool ActiveInterrogation, AmLiBlockTypes AmLiBlock,
            string additionalComment = "") : base(
            configurationFile,
            COMMENT + " " + additionalComment)
        {
            InitializeAmLiFncl(ActiveInterrogation, AmLiBlock);
        }

        private void InitializeAmLiFncl(bool ActiveInterrogation, AmLiBlockTypes AmLiBlock)
        {
            activeInterrogation = ActiveInterrogation;
            //blockMat = Materials.HDPE;
            //caseMat = Materials.ALUMINUM; 
            //caseThickness = Extents.ENCLOSURE_THICK;
            //  blockCenter = Extents.AmLiSource.BlockCenter;
            // blockExtents = Extents.AmLiSource.BlockExtent;
            magnitudeLeft = Extents.SelMeasurementSetup.AmLiMagnitudeLeft;
            magnitudeRight = Extents.SelMeasurementSetup.AmLiMagnitudeRight;
            amLiBlock = AmLiBlock;
            // amLiCenter = Extents.AmLiSource.SourceCenter;
        }

        protected override void InitializeComponents()
        {
            AddComponent(AmLiBlockHelper.GetAmLiBlock(amLiBlock, Indices.AmLi.BASEINDEX, heightDisplacement,
                magnitudeLeft,
                magnitudeRight, activeInterrogation));
        }


        protected override void SetUpFromSpecs(SimulationSpecification specs)
        {
            magnitudeLeft = specs.AmLiLeft;
            magnitudeRight = specs.AmLiRight;
            activeInterrogation = specs.ActiveProblem;
            amLiBlock = specs.AmLiBlockType;
        }

        protected override string GetPrimaryDetectorFile()
        {
            return PoliMiMPPostInputHelper.GetFnclDetectorFile();
        }

        protected override string GetSecondaryDetectorFile()
        {
            return string.Empty;
        }

        //protected override string GetPrimaryDetectorOutputFile()
        //{
        //    return PoliMiMPPostInputHelper.GetFnclOutputPrefix();
        //}

        //protected override string GetSecondaryDetectorOutputFile()
        //{
        //    return string.Empty;
        //}
    }
}
