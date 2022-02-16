using System;
using System.Collections.Generic;
using GlobalHelpersDefaults;
using Multiplicity.PulseFilters;

namespace Multiplicity
{
    public static class PulseShapeDiscriminators
    {
        private static List<PsdComponent> GetPsdFromFixedTimeTrigger<TPulse>(
            double Trigger, Pulses<TPulse> Pulses,
            int FastInterval, int SlowInterval, int nPulses, double AmplitudeDivisor) where TPulse : IPulseWaveform
        {
            PulseShapeDiscrimination<TPulse> psd =
                new FixedTriggerPsd<TPulse>((int)Trigger, FastInterval, SlowInterval, AmplitudeDivisor);
            return psd.GetPSD(Pulses, nPulses);
        }

        private static List<PsdComponent> GetPsdFromPeakMaxOffSetTrigger<TPulse>(
            double Trigger, Pulses<TPulse> Pulses,
            int FastInterval, int SlowInterval, int nPulses, double AmplitudeDivisor) where TPulse : IPulseWaveform
        {
            PulseShapeDiscrimination<TPulse> psd =
                new PulseHeightFixedOffSetPsd<TPulse>((int)Trigger, FastInterval, SlowInterval, AmplitudeDivisor);
            return psd.GetPSD(Pulses, nPulses);
        }

        private static List<PsdComponent> GetPsdFromPeakHeightFractionTrigger<TPulse>(
            double Trigger,
            Pulses<TPulse> Pulses,
            int FastInterval, int SlowInterval, int nPulses, double AmplitudeDivisor) where TPulse : IPulseWaveform
        {
            PulseShapeDiscrimination<TPulse> psd =
                new PulseHeightFractionPsd<TPulse>(Trigger, FastInterval, SlowInterval, AmplitudeDivisor);
            return psd.GetPSD(Pulses, nPulses);
        }

        public abstract class PulseShapeDiscrimination<TPulse> where TPulse : IPulseWaveform
        {
            private readonly int slowInterval;
            private readonly int fastInterval;
            private readonly double amplitudeDivisor;

            protected int fastStartTime;

            private int fastEndTime; // could make these equal but don't limit method to adjacent intervals
            private int slowStartTime;
            private int slowEndTime;

            protected PulseShapeDiscrimination(int FastInterval, int SlowInterval, double AmplitudeDivisor)
            {
                fastInterval = FastInterval;
                slowInterval = SlowInterval;
                amplitudeDivisor = (AmplitudeDivisor > 0) ? AmplitudeDivisor : 1;
            }

            public PsdWaveformGui GetPsdWaveformGui(TPulse pulse, PsdSpecification psdSpecification)
            {
                PulseShapeParticleFilter<TPulse> psdParticleFilter =
                    new PulseShapeParticleFilter<TPulse>(psdSpecification, Particle.Undetermined);
                PsdComponent psd = GetPsdForPulse(pulse);
                return new PsdWaveformGui
                {
                    FastTimeLow = fastStartTime,
                    FastTimeHigh = fastEndTime,
                    SlowTimeLow = slowStartTime,
                    SlowTimeHigh = slowEndTime,
                    TriggerTime = fastStartTime,
                    Waveform = pulse.GetAdcWaveform(),
                    PSD = psd,
                    PsdParticle = psdParticleFilter.GetParticleFromPulse(pulse)
                };
            }

            public List<PsdComponent> GetPSD(Pulses<TPulse> pulses, int nPulses)
            {
                Random rand = new Random();

                List<TPulse> sampledPulses = new List<TPulse>(nPulses);
                nPulses = (nPulses > pulses.NumberOfPulses) ? pulses.NumberOfPulses : nPulses;
                for (int i = 0; i < nPulses; i++)
                {
                    sampledPulses.Add(pulses.GetPulseByIndex(rand.Next(pulses.NumberOfPulses)));
                }

                return GetPsdFromPulseList(sampledPulses);
            }

            private List<PsdComponent> GetPsdFromPulseList(List<TPulse> pulses)
            {
                List<PsdComponent> psd =
                    new List<PsdComponent>();
                foreach (TPulse p in pulses)
                {
                    psd.Add(GetPsdForPulse(p));
                }

                return psd;
            }

            public PsdComponent GetPsdForSinglePulse(TPulse pulse)
            {
                return GetPsdForPulse(pulse);
            }

            private PsdComponent GetPsdForPulse(TPulse pulse)
            {
                SetIntegrationTimeBounds(pulse);
                double slow = pulse.IntegratePulseByIndex(slowStartTime, slowEndTime);
                double fast = pulse.IntegratePulseByIndex(fastStartTime, fastEndTime);
                return new PsdComponent(slow, fast, amplitudeDivisor);
            }

            protected abstract void SetIntegrationTimeBounds(TPulse pulseWaveform);

            protected void SetIntegrationAfterStartSet()
            {
                fastEndTime = fastStartTime + fastInterval;
                slowStartTime = fastEndTime;
                slowEndTime = slowStartTime + slowInterval;
            }
        }

        private class PulseHeightFractionPsd<TPulse> : PulseShapeDiscrimination<TPulse> where TPulse : IPulseWaveform
        {
            private readonly double trigger;

            public PulseHeightFractionPsd(double TriggerFraction, int FastInterval,
                int SlowInterval, double AmplitudeDivisor) : base(FastInterval, SlowInterval, AmplitudeDivisor)
            {
                trigger = TriggerFraction;
            }

            protected override void SetIntegrationTimeBounds(TPulse pulseWaveform)
            {
                fastStartTime = pulseWaveform.GetAdCPulseTimeFromPeakHeightFraction(trigger);
                SetIntegrationAfterStartSet();
            }
        }

        private class PulseHeightFixedOffSetPsd<TPulse> : PulseShapeDiscrimination<TPulse> where TPulse : IPulseWaveform
        {
            private readonly int triggerOffset;

            public PulseHeightFixedOffSetPsd(int TriggerOffset, int FastInterval,
                int SlowInterval, double AmplitudeDivisor) : base(FastInterval, SlowInterval, AmplitudeDivisor)
            {
                triggerOffset = TriggerOffset;
            }

            protected override void SetIntegrationTimeBounds(TPulse pulseWaveform)
            {
                fastStartTime = pulseWaveform.GetAdcPulseTimeOffSetFromPeak(triggerOffset);
                SetIntegrationAfterStartSet();
            }
        }

        private class FixedTriggerPsd<TPulse> : PulseShapeDiscrimination<TPulse> where TPulse : IPulseWaveform
        {
            private readonly int startTime;
            private bool timesNotSet;

            //Single Fixed
            public FixedTriggerPsd(int TriggerTime, int FastInterval, int SlowInterval, double AmplitudeDivisor) : base(
                FastInterval, SlowInterval, AmplitudeDivisor)
            {
                startTime = TriggerTime;
                timesNotSet = true;
            }

            protected override void SetIntegrationTimeBounds(TPulse pulseWaveform)
            {
                // No need to do this every time, as it is fixed
                if (timesNotSet)
                {
                    fastStartTime = startTime;
                    SetIntegrationAfterStartSet();
                    timesNotSet = false;
                }
            }
        }

        // prefer not to pass PSD specfication, as we don't need the polyline 
        public static PulseShapeDiscrimination<TPulse> GetPulseShapeDiscriminator<TPulse>(
            PsdTriggerTypes triggerType,
            double psdTrigger, int fastInterval, int slowInterval, double amplitudeDivisor)
            where TPulse : IPulseWaveform
        {
            switch (triggerType)
            {
                case PsdTriggerTypes.NotDefined:
                    throw new Exception("Must define a Pulse Shape Discrimination Type");
                case PsdTriggerTypes.Fixed:
                    return new FixedTriggerPsd<TPulse>((int)psdTrigger, fastInterval, slowInterval, amplitudeDivisor);
                case PsdTriggerTypes.PeakOffset:
                    return new PulseHeightFixedOffSetPsd<TPulse>((int)psdTrigger, fastInterval, slowInterval,
                        amplitudeDivisor);
                case PsdTriggerTypes.PeakHeight:
                    return new PulseHeightFractionPsd<TPulse>(psdTrigger, fastInterval, slowInterval, amplitudeDivisor);
                default:
                    throw new ArgumentOutOfRangeException(nameof(triggerType), triggerType, null);
            }
        }

        public static List<PsdComponent> GetPsd<TPulse>(
            PsdTriggerTypes triggerType,
            double psdTrigger, Pulses<TPulse> pulses, int fastInterval, int slowInterval, int nPulses,
            double amplitudeDivisor) where TPulse : IPulseWaveform
        {
            switch (triggerType)
            {
                case PsdTriggerTypes.Fixed:
                    return GetPsdFromFixedTimeTrigger(psdTrigger, pulses, fastInterval, slowInterval, nPulses,
                        amplitudeDivisor);
                case PsdTriggerTypes.PeakOffset:
                    return GetPsdFromPeakMaxOffSetTrigger(psdTrigger, pulses, fastInterval, slowInterval, nPulses,
                        amplitudeDivisor);
                case PsdTriggerTypes.PeakHeight:
                    return GetPsdFromPeakHeightFractionTrigger(psdTrigger, pulses, fastInterval, slowInterval, nPulses,
                        amplitudeDivisor);
                default:
                    throw new ArgumentOutOfRangeException(nameof(triggerType), triggerType, null);
            }
        }

        public static PsdWaveformGui GetPsdWaveformGuiFromPulse<TPulse>(PsdSpecification specification, TPulse pulse)
            where TPulse : IPulseWaveform
        {
            var psd = GetPulseShapeDiscriminator<TPulse>(specification.TriggerType, specification.Trigger,
                specification.Fast, specification.Slow, specification.AmplitudeDivisor);

            return psd.GetPsdWaveformGui(pulse, specification);
        }
    }
}
