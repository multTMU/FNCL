using System.Collections.Generic;
using System.Linq;
using GlobalHelpersDefaults;

namespace Multiplicity.PulseFilters
{
    public class PulseFlatTopFilter<TPulse> : PulseFilter<TPulse> where TPulse : IPulseWaveform
    {
        private double flatTopTimeThreshold;
        private double peakMaxTolerance;

        public PulseFlatTopFilter(double FlatTopTimeThreshold, double PeakMaxTolerancePercent)
        {
            flatTopTimeThreshold = FlatTopTimeThreshold;
            peakMaxTolerance = PeakMaxTolerancePercent / 100.0;
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (notFlatTopPulse(p))
                {
                    filteredPulses.Add(p);
                }
            }
        }

        private bool notFlatTopPulse(TPulse pulse)
        {
            return (pulse.DurationOfPulsePeak(peakMaxTolerance) <= flatTopTimeThreshold);
        }
    }

    public class PulseShapeDiscriminatorCalibrationFilter<TPulse> : PulseFilter<TPulse> where TPulse : IPulseWaveform
    {
        protected Particle particle;

        public PulseShapeDiscriminatorCalibrationFilter(Particle filterParticle)
        {
            particle = filterParticle;
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            FilterByDetector<TPulse> detectorFilter;
            foreach (KeyValuePair<DetectorKey, PsdSpecification> dCal in PulseShapeDiscriminationCalibration
                .GetDictionary())
            {
                detectorFilter = new FilterByDetector<TPulse>(FNCLdetectorDictionary.GetDetectorIndex(dCal.Key));
                List<TPulse> detectorPulses = detectorFilter.GetFilteredPulses(unfilteredPulses);
                filteredPulses.AddRange(psdFilterDetectorPulses(detectorPulses, dCal.Value));
            }
        }

        private List<TPulse> psdFilterDetectorPulses(List<TPulse> detectorPulses, PsdSpecification calibration)
        {
            PulseShapeParticleFilter<TPulse> psdParticleFilter =
                new PulseShapeParticleFilter<TPulse>(calibration, particle);
            return psdParticleFilter.GetFilteredPulses(detectorPulses);
        }
    }

    public class PulseShapeParticleFilter<TPulse> : PulseFilter<TPulse> where TPulse : IPulseWaveform
    {
        private const int INITIAL_INDEX = -1;
        protected Particle particle;
        private PulseShapeDiscriminators.PulseShapeDiscrimination<TPulse> discriminator;
        private PsdSpecification calibration;

        public PulseShapeParticleFilter(PsdSpecification Calibration, Particle filterParticle)
        {
            calibration = Calibration;
            particle = filterParticle;
            Initialize();
        }

        private void Initialize()
        {
            discriminator = PulseShapeDiscriminators.GetPulseShapeDiscriminator<TPulse>(calibration.TriggerType,
                calibration.Trigger, (int)calibration.Fast, (int)calibration.Slow, calibration.AmplitudeDivisor);
        }

        public Particle GetParticleFromPulse(TPulse pulse)
        {
            particle = Particle.Neutron;
            return pulseShapePasses(pulse) ? Particle.Neutron : Particle.Photon;
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (particle == Particle.Undetermined || particle == Particle.NeutronAndPhoton)
                {
                    p.SetParticle(GetParticleFromPulse(p));
                    filteredPulses.Add(p);
                }
                else
                {
                    if (pulseShapePasses(p))
                    {
                        p.SetParticle(particle);
                        filteredPulses.Add(p);
                    }
                }
            }
        }

        private bool pulseShapePasses(TPulse pulseWaveform)
        {
            bool pulseAboveCurve = isPulseAboveCurve(pulseWaveform);
            if (particle == Particle.Neutron)
            {
                return pulseAboveCurve;
            }

            return !pulseAboveCurve;
        }

        private bool isPulseAboveCurve(TPulse pulseWaveform)
        {
            PsdComponent psd = discriminator.GetPsdForSinglePulse(pulseWaveform);
            int psdCurveIndex = GetPsdIndex(psd);

            if (pointIsLeftOfCurve(psdCurveIndex))
            {
                return psd.PSD > calibration.PolyLine.First().PSD;
            }
            else if (pointIsRightOfCurve(psdCurveIndex))
            {
                return psd.PSD > calibration.PolyLine.Last().PSD;
            }
            else
            {
                return isPulseAboveLineSegment(psd, psdCurveIndex);
            }
        }

        private bool isPulseAboveLineSegment(PsdComponent psd, int psdCurveIndex)
        {
            PsdComponent psdLeft = calibration.PolyLine[psdCurveIndex];
            PsdComponent psdRight = calibration.PolyLine[psdCurveIndex + 1];

            return psd.PSD > GetLinePoint(psdLeft, psdRight, psd.Amplitude);
        }

        private double GetLinePoint(PsdComponent psdLeft,
            PsdComponent psdRight, double psdAmplitude)
        {
            double slope = (psdRight.PSD - psdLeft.PSD) / (psdRight.Amplitude - psdLeft.Amplitude);
            double pointPsd = slope * (psdAmplitude - psdLeft.Amplitude) + psdLeft.PSD;
            return pointPsd;
        }

        private bool pointIsRightOfCurve(int psdCurveIndex)
        {
            return psdCurveIndex == (calibration.PolyLine.Count - 1);
        }

        private static bool pointIsLeftOfCurve(int psdCurveIndex)
        {
            return psdCurveIndex == INITIAL_INDEX;
        }

        private int GetPsdIndex(PsdComponent psd)
        {
            int psdCurveIndex = INITIAL_INDEX;
            int i = -1;
            foreach (var p in calibration.PolyLine)
            {
                i++;
                if (psd.Amplitude < p.Amplitude)
                {
                    psdCurveIndex = i;
                    break;
                }
            }

            return psdCurveIndex;
        }
    }
}
