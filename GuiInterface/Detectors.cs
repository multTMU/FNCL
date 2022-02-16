using System;
using System.Collections.Generic;
using GlobalHelpers;
using GlobalHelpersDefaults;
using Multiplicity;

namespace GuiInterface
{
    public interface IDetectorDefaults
    {
        GateSettings GetDieAwayStart();
        GateSettings GetDieAwayEnd();
        int GetDieAwayIncrements();
        MultiplicityGateType GetDieAwayGateType();
        int GetPreDelay();
        int GetLongDelay();
        int GetPsdPeakMaxTriggerOffset();
        int GetGate();
        double GetPulseHeightLLD();
        int GetDetectorOne();
        int GetDetectorTwo();
        int GetDetectorThree();
        int GetDetectorFour();
        int GetPanelOne();
        PsdTriggerTypes GetPsdTriggerType();
        int GetPanelTwo();
        int GetPanelThree();
        int GetPSDfast();
        int GetPSDslow();
        bool GetCrosstalk();
        double GetActivity();
        int GetSeed();
        int GetNPS();
        int GetPulseWaveTimeStep();
        double GetPsdAmplitudeScalar();
        int GetAdCTrigger();
        int GetFuelRowCol();
        double GetPulseHeightULD();

        int GetCorrelatedPulseTime();

        // List<AppliedPulseFilters> GetFilterOrder();
        Particle GetParticle();
        double GetPileUpScalar();
        double GetPileUpInterval();
        int GetCrosstalkVetoTime();
        double GetFlatTopDuration();
        double GetFlatTopPeakMaxTolerancePercent();
    }

    public static class DetectorTypeGuiHelper
    {
        public static IDetectorDefaults GetDefault()
        {
            return new NoWorkingDetector();
        }

        public static IDetectorDefaults GetDetector(DetectorType detectorType)
        {
            switch (detectorType)
            {
                case DetectorType.None:
                    return new NoWorkingDetector();
                case DetectorType.FastNeutronCollar:
                    return new FastNeutronCollarWorkingDetector();
                case DetectorType.NGammaPrototype:
                    break;
                default:
                    return new NoWorkingDetector();
            }

            return new NoWorkingDetector();
        }
    }

    public class FastNeutronCollarWorkingDetector : WorkingDetectorBase
    {
        public override GateSettings GetDieAwayStart()
        {
            return new GateSettings(60, 0, 600);
        }

        public override Particle GetParticle()
        {
            return FnclHelpers.PARTICLE;
        }

        public override double GetPileUpScalar()
        {
            return FnclHelpers.PILEUP_SENSITIVITY;
        }

        public override double GetPileUpInterval()
        {
            return FnclHelpers.PILEUP_INTERVAL;
        }

        public override int GetCrosstalkVetoTime()
        {
            return FnclHelpers.CROSSTALK_VETO_TIME;
        }

        public override double GetFlatTopDuration()
        {
            return FnclHelpers.FLATTOP_DURATION;
        }

        public override double GetFlatTopPeakMaxTolerancePercent()
        {
            return FnclHelpers.FLATTOP_MAX_PEAK_PERCENT;
        }

        public override GateSettings GetDieAwayEnd()
        {
            return new GateSettings(120, 0, 1200);
        }

        public override int GetPreDelay()
        {
            return FnclHelpers.PREDELAY_SEO;
        }

        public override int GetLongDelay()
        {
            return FnclHelpers.LONGDELAY_SEO;
        }

        public override int GetPsdPeakMaxTriggerOffset()
        {
            return FnclHelpers.PSD_PEAKMAX_TRIGGER;
        }

        public override int GetGate()
        {
            return FnclHelpers.COINCIDENCE_INTERVAL;
        }

        public override double GetPulseHeightLLD()
        {
            return FnclHelpers.PULSE_AMPLITUDE_DISCRIMINATOR_KEVEE;
        }

        public override int GetDetectorOne()
        {
            return FnclHelpers.DETECTOR_ONE;
        }

        public override int GetDetectorTwo()
        {
            return FnclHelpers.DETECTOR_TWO;
        }

        public override int GetDetectorThree()
        {
            return FnclHelpers.DETECTOR_THREE;
        }

        public override int GetDetectorFour()
        {
            return FnclHelpers.DETECTOR_FOUR;
        }

        public override int GetPanelOne()
        {
            return FnclHelpers.PANEL_ONE;
        }

        public override PsdTriggerTypes GetPsdTriggerType()
        {
            return FnclHelpers.PSD_TYPE;
        }

        public override int GetPanelTwo()
        {
            return FnclHelpers.PANEL_TWO;
        }

        public override int GetPanelThree()
        {
            return FnclHelpers.PANEL_THREE;
        }

        public override int GetPSDfast()
        {
            return FnclHelpers.PSD_FAST_INTERVAL;
        }

        public override int GetPSDslow()
        {
            return FnclHelpers.PSD_SLOW_INTERVAL;
        }

        public override bool GetCrosstalk()
        {
            return FnclHelpers.FITLER_CROSSTALK;
        }

        public override double GetActivity()
        {
            return FnclHelpers.POLIMI_ACTIVITY;
        }

        public override int GetNPS()
        {
            return FnclHelpers.POLIMI_NPS;
        }

        public override int GetCorrelatedPulseTime()
        {
            return FnclHelpers.CORRELATED_PULSE_TIME;
        }

        public override int GetPulseWaveTimeStep()
        {
            return FnclHelpers.WAVEFORM_TIMESTEP;
        }

        public override double GetPsdAmplitudeScalar()
        {
            return FnclHelpers.PSD_AMPLITUDE_SCALAR;
        }

        public override int GetAdCTrigger()
        {
            return FnclHelpers.ADC_TRIGGER;
        }

        public override double GetPulseHeightULD()
        {
            return 5e4;
        }
    }

    public class NoWorkingDetector : WorkingDetectorBase
    {
        public override int GetPSDslow()
        {
            return 0;
        }

        public override double GetPulseHeightLLD()
        {
            return 0;
        }

        public override double GetPulseHeightULD()
        {
            return 0;
        }

        public override int GetCorrelatedPulseTime()
        {
            return 0;
        }

        public override int GetPulseWaveTimeStep()
        {
            return 0;
        }

        public override double GetPileUpScalar()
        {
            return 0;
        }

        public override double GetPileUpInterval()
        {
            return 0;
        }

        public override int GetCrosstalkVetoTime()
        {
            return 0;
        }

        public override double GetFlatTopDuration()
        {
            return Double.MaxValue;
        }

        public override double GetFlatTopPeakMaxTolerancePercent()
        {
            return 100;
        }

        public override bool GetCrosstalk()
        {
            return false;
        }

        public override int GetDetectorThree()
        {
            return 0;
        }

        public override int GetDetectorTwo()
        {
            return 0;
        }

        public override GateSettings GetDieAwayEnd()
        {
            return new GateSettings(0, 0, 0);
        }

        public override GateSettings GetDieAwayStart()
        {
            return new GateSettings(0, 0, 0);
        }

        public override int GetPsdPeakMaxTriggerOffset()
        {
            return 0;
        }

        public override double GetPsdAmplitudeScalar()
        {
            return 1;
        }

        public override int GetGate()
        {
            return 0;
        }

        public override int GetPreDelay()
        {
            return 0;
        }

        public override int GetPSDfast()
        {
            return 0;
        }

        public override int GetLongDelay()
        {
            return 0;
        }

        public override int GetNPS()
        {
            return 0;
        }

        public override int GetPanelOne()
        {
            return 0;
        }

        public override int GetPanelThree()
        {
            return 0;
        }

        public override int GetPanelTwo()
        {
            return 0;
        }

        public override int GetDetectorFour()
        {
            return 0;
        }

        public override int GetDetectorOne()
        {
            return 0;
        }

        public override double GetActivity()
        {
            return 0;
        }

        public override int GetAdCTrigger()
        {
            return 0;
        }
    }

    public abstract class WorkingDetectorBase : IDetectorDefaults
    {
        public int GetSeed()
        {
            return new Random().Next();
        }

        public virtual PsdTriggerTypes GetPsdTriggerType()
        {
            return PsdTriggerTypes.NotDefined;
        }

        public MultiplicityGateType GetDieAwayGateType()
        {
            return MultiplicityGateType.ShiftRegister;
        }

        public int GetDieAwayIncrements()
        {
            return 0;
        }

        public int GetFuelRowCol()
        {
            return FuelAssemblyManager.GetDefaultRowsAndColumns();
        }

        public virtual List<AppliedPulseFilters> GetFilterOrder()
        {
            List<AppliedPulseFilters> defaultFilter = new List<AppliedPulseFilters>();
            foreach (AppliedPulseFilters f in Enum.GetValues(typeof(AppliedPulseFilters)))
            {
                defaultFilter.Add(f);
            }

            return defaultFilter;
        }

        public virtual Particle GetParticle()
        {
            return Particle.NeutronAndPhoton;
        }

        public abstract double GetActivity();
        public abstract int GetAdCTrigger();
        public abstract bool GetCrosstalk();
        public abstract int GetDetectorFour();
        public abstract int GetDetectorOne();
        public abstract int GetDetectorThree();
        public abstract int GetDetectorTwo();
        public abstract GateSettings GetDieAwayEnd();
        public abstract GateSettings GetDieAwayStart();
        public abstract int GetGate();
        public abstract int GetLongDelay();
        public abstract int GetNPS();
        public abstract int GetPanelOne();
        public abstract int GetPanelThree();
        public abstract int GetPanelTwo();
        public abstract int GetPreDelay();
        public abstract int GetPSDfast();
        public abstract int GetPsdPeakMaxTriggerOffset();
        public abstract double GetPsdAmplitudeScalar();
        public abstract int GetPSDslow();
        public abstract double GetPulseHeightLLD();
        public abstract double GetPulseHeightULD();
        public abstract int GetCorrelatedPulseTime();
        public abstract int GetPulseWaveTimeStep();
        public abstract double GetPileUpScalar();
        public abstract double GetPileUpInterval();
        public abstract int GetCrosstalkVetoTime();
        public abstract double GetFlatTopDuration();
        public abstract double GetFlatTopPeakMaxTolerancePercent();
    }
}
