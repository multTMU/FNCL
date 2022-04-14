using FastNeutronCollar;
using GeometrySampling;
using GlobalHelpers;
using PoliMiRunner;

namespace Runner
{
    //public class MP320FNCLfuel : Mp320Fncl, IFuelModels
    //{
    //    private string fuelFile;
    //    private readonly bool useNgenSource;
    //    private const string COMMENT = "Fuel";

    //    public MP320FNCLfuel(string configFile, bool UseNgenSource) : base(configFile, UseNgenSource, COMMENT)
    //    {
    //        useNgenSource = UseNgenSource;
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

    public class Mp320Fncl : RunFnclDetector
    {
        protected static string COMMENT = "MP320 DD FNCL";
        private bool useNgenSource;
        private MyPoint3D nGenCenter;
        private MyPoint3D nGenAxis;
        private bool useCd;
        private bool usePb;
        private double thicknessCd;
        private double thicknessPb;
        private double extraPEthickness;

        private bool useSideShieldLeftPanelTwo;
        private bool useSideShieldRightPanelOne;
        private MyPoint3D sideShieldDimensions;

        public Mp320Fncl(string configFile, bool ActiveInterrogation, string additionalComment = "") : base(configFile,
            COMMENT + " " + additionalComment)
        {
            InitializeDefaults(ActiveInterrogation);
        }

        private void InitializeDefaults(bool ActiveInterrogation)
        {
            useNgenSource = ActiveInterrogation;
            extraPEthickness = 0;
            nGenAxis = Extents.Mp320.Axis;
            nGenCenter = Extents.Mp320.CenterRelativeToModeratorBulkFace;
        }

        public Mp320Fncl(ProblemConfig Config, bool ActiveInterrogation, string additionalComment = "") : base(Config,
            COMMENT + " " + additionalComment)
        {
            InitializeDefaults(ActiveInterrogation);
        }

        public void SetNeutronGeneratorCenter(MyPoint3D Center)
        {
            nGenCenter = Center + CenterOfFNCL;
        }

        public void SetNeutronGeneratorAxis(MyPoint3D Axis)
        {
            nGenAxis = Axis;
        }

        public void SetExtraPEthickness(double thicknessPE)
        {
            extraPEthickness = thicknessPE;
        }

        protected override void InitializeComponents()
        {
            AddComponent(new Mp320Component(nGenCenter, nGenAxis, usePb, thicknessPb, useCd, thicknessCd,
                sideShieldDimensions,
                useNgenSource, heightDisplacement, extraPEthickness, useSideShieldLeftPanelTwo,
                useSideShieldRightPanelOne));
        }

        protected override void SetUpFromSpecs(SimulationSpecification specs)
        {
            useNgenSource = specs.ActiveProblem;
            extraPEthickness = specs.ModeratorThickness;
            useCd = specs.UseCdShield;
            usePb = specs.UsePbShield;
            thicknessCd = specs.CdThickness;
            thicknessPb = specs.PbThickness;
            useSideShieldLeftPanelTwo = specs.UseLeftPanelTwoShield;
            useSideShieldRightPanelOne = specs.UseRightPanelOneShield;
            sideShieldDimensions = specs.ExtraPbShieldDimensions;
        }

        protected override string GetPrimaryDetectorFile()
        {
            return PoliMiMPPostInputHelper.GetFnclDetectorFile();
        }

        protected override string GetSecondaryDetectorFile()
        {
            return PoliMiMPPostInputHelper.GetHe3DetectorFile();
        }

        protected override MPPostSpecification GetSecondaryDetectorDefault()
        {
            return DetectorFileMaker.GetHe3DetectorDefault();
        }

        public void SetShield(bool UsePb, double ThicknessPb, bool UseCd, double ThicknessCd)
        {
            usePb = UsePb;
            useCd = UseCd;
            thicknessCd = ThicknessCd;
            thicknessPb = ThicknessPb;
        }
    }

    public class Mp320FnclSel : Mp320Fncl, ISelMeasurement
    {
        protected int nPucks;
        protected MyPoint3D topOfPostPucks;

        public Mp320FnclSel(ProblemConfig Config, bool UseNGenSource) : base(Config, UseNGenSource)
        {
            InitializeSelFncl();
        }

        public Mp320FnclSel(string configFile, bool UseNGenSource) : base(configFile, UseNGenSource)
        {
            InitializeSelFncl();
        }

        public int GetNumberOfPucks()
        {
            return nPucks;
        }

        public void SetNumberOfPucks(int pucks)
        {
            nPucks = pucks;
        }

        public void InitializeSelFncl()
        {
            nPucks = 0;
            topOfPostPucks = SelMeasurementComponents.GetCenterOfTopOfPucksAndPost(nPucks);
        }

        public MyPoint3D GetTopOfPostPucks()
        {
            return SelMeasurementComponents.GetCenterOfTopOfPucksAndPost(nPucks);
        }

        protected override void SetUpFromSpecs(SimulationSpecification specs)
        {
            nPucks = specs.NumberOfSelPucks;
            base.SetUpFromSpecs(specs);
        }
    }
}
