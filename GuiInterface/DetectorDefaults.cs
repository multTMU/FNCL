using GlobalHelpersDefaults;
using Multiplicity;

namespace GuiInterface
{
    // keep this verbose setup for implementing other detectors
    public static class DetectorDefaults
    {
        private static IDetectorDefaults detectorDefaults;

        static DetectorDefaults()
        {
            detectorDefaults = DetectorTypeGuiHelper.GetDefault();
        }

        public static void UpdateSelectedDetector(DetectorType detectorType)
        {
            detectorDefaults = DetectorTypeGuiHelper.GetDetector(detectorType);
        }

        public static double GetFlatTopDuration()
        {
            return detectorDefaults.GetFlatTopDuration();
        }

        public static double GetFlatTopPeakMaxTolerancePercent()
        {
            return detectorDefaults.GetFlatTopPeakMaxTolerancePercent();
        }

        public static GateSettings GetDieAwayStart()
        {
            return detectorDefaults.GetDieAwayStart();
        }

        public static double GetPileUpScalar()
        {
            return detectorDefaults.GetPileUpScalar();
        }

        public static double GetPileUpInterval()
        {
            return detectorDefaults.GetPileUpInterval();
        }

        public static GateSettings GetDieAwayEnd()
        {
            return detectorDefaults.GetDieAwayEnd();
        }

        public static int GetDieAwayIncrements()
        {
            return detectorDefaults.GetDieAwayIncrements();
        }

        public static MultiplicityGateType GetDieAwayGateType()
        {
            return detectorDefaults.GetDieAwayGateType();
        }

        public static int GetPreDelay()
        {
            return detectorDefaults.GetPreDelay();
        }

        public static int GetLongDelay()
        {
            return detectorDefaults.GetLongDelay();
        }

        public static int GetPsdPeakMaxTriggerOffset()
        {
            return detectorDefaults.GetPsdPeakMaxTriggerOffset();
        }

        public static int GetGate()
        {
            return detectorDefaults.GetGate();
        }

        public static double GetPulseHeightLLD()
        {
            return detectorDefaults.GetPulseHeightLLD();
        }

        public static int GetDetectorOne()
        {
            return detectorDefaults.GetDetectorOne();
        }

        public static int GetDetectorTwo()
        {
            return detectorDefaults.GetDetectorTwo();
        }

        public static int GetDetectorThree()
        {
            return detectorDefaults.GetDetectorThree();
        }

        public static int GetDetectorFour()
        {
            return detectorDefaults.GetDetectorFour();
        }

        public static int GetPanelOne()
        {
            return detectorDefaults.GetPanelOne();
        }

        public static PsdTriggerTypes GetPsdTriggerType()
        {
            return detectorDefaults.GetPsdTriggerType();
        }

        public static int GetPanelTwo()
        {
            return detectorDefaults.GetPanelTwo();
        }

        public static int GetPanelThree()
        {
            return detectorDefaults.GetPanelThree();
        }

        public static int GetPSDfast()
        {
            return detectorDefaults.GetPSDfast();
        }

        public static int GetPSDslow()
        {
            return detectorDefaults.GetPSDslow();
        }

        public static bool GetCrosstalk()
        {
            return detectorDefaults.GetCrosstalk();
        }

        public static double GetActivity()
        {
            return detectorDefaults.GetActivity();
        }

        public static int GetSeed()
        {
            return detectorDefaults.GetSeed();
        }

        public static int GetNPS()
        {
            return detectorDefaults.GetNPS();
        }

        public static int GetPulseWaveTimeStep()
        {
            return detectorDefaults.GetPulseWaveTimeStep();
        }

        public static double GetPsdAmplitudeScalar()
        {
            return detectorDefaults.GetPsdAmplitudeScalar();
        }

        public static int GetAdCTrigger()
        {
            return detectorDefaults.GetAdCTrigger();
        }

        public static int GetFuelRowCol()
        {
            return detectorDefaults.GetFuelRowCol();
        }

        public static double GetPulseHeightULD()
        {
            return detectorDefaults.GetPulseHeightULD();
        }

        public static int GetCorrelatedPulseTime()
        {
            return detectorDefaults.GetCorrelatedPulseTime();
        }

        //public static List<AppliedPulseFilters> GetFilterOrder()
        //{
        //    return detectorDefaults.GetFilterOrder();
        //}

        public static Particle GetParticle()
        {
            return detectorDefaults.GetParticle();
        }

        public static int GetCrosstalkVetoTime()
        {
            return detectorDefaults.GetCrosstalkVetoTime();
        }
    }
}
