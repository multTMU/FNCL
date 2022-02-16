using GeometrySampling;
using GlobalHelpers;
using NeutronCaptureGammaDetector;
using Runner;

namespace PoliMiRunner
{
    public abstract class RunNGammaDetectorBase : ModelRunner
    {
        protected Point3D faceCenter;
        protected double shieldThickess;
        private NGammaDetector nGammaDetector;
        private ProblemConfig problemConfig;

        protected RunNGammaDetectorBase(string configurationFile, string comment, double StandOff,
            double shieldThickness) : base(configurationFile, comment)
        {
            InitializeRunNGam(StandOff, shieldThickness);
        }

        protected RunNGammaDetectorBase(ProblemConfig Config, string comment, double StandOff, double shieldThickness) :
            base(Config, comment)
        {
            InitializeRunNGam(StandOff, shieldThickness);
        }

        protected RunNGammaDetectorBase(ProblemConfig config) : base(config, "NgammaDetector")
        {
            InitializeRunNGam(0, 0);
        }

        private void InitializeRunNGam(double StandOff, double ShieldThickess)
        {
            faceCenter = Extents.NGammaDetector.FACE_NORMAL * StandOff;
            shieldThickess = ShieldThickess;
        }

        public override void DisplaceHeightFromCenter(double heightDisplacement)
        {
            faceCenter.Z += heightDisplacement;
        }

        protected override PoliMiExecutor GetExecutor()
        {
            return new NGammaExecutor(config, problemsToRun);
        }

        protected override void InitializeComponents()
        {
            nGammaDetector = new NGammaDetector(faceCenter, shieldThickess);
            AddComponent(nGammaDetector);
        }

        protected override MPPostSpecification GetPrimaryDetectorDefault()
        {
            return DetectorFileMaker.GetNGam12DetectorDefault();
        }

        //protected override MPPostSpecification GetSecondaryDetector()
        //{
        //    return new MPPostSpecification();
        //}

        protected override void SetUpFromSpecs(SimulationSpecification specs)
        {
            InitializeRunNGam(specs.StandOff, specs.PbThickness);
        }
    }

    public class RunNGammaDetector : RunNGammaDetectorBase
    {
        public RunNGammaDetector(string configurationFile, string comment, double StandOff, double ShieldThickness) :
            base(configurationFile, comment, StandOff, ShieldThickness)
        {
        }

        public RunNGammaDetector(ProblemConfig Config, string comment, double StandOff, double ShieldThickness) : base(
            Config, comment, StandOff, ShieldThickness)
        {
        }

        public RunNGammaDetector(ProblemConfig Config) : base(Config)
        {
        }

        protected override string GetPrimaryDetectorFile()
        {
            return PoliMiMPPostInputHelper.GetNGamDetectorFile();
        }

        protected override string GetSecondaryDetectorFile()
        {
            return string.Empty;
        }

        //protected override string GetPrimaryDetectorOutputFile()
        //{
        //    return PoliMiMPPostInputHelper.GetNGamOutputPrefix();
        //}

        //protected override string GetSecondaryDetectorOutputFile()
        //{
        //    return string.Empty;
        //}
    }
}
