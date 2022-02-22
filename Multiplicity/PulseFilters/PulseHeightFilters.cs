using System.Collections.Generic;
using GeometrySampling;

namespace Multiplicity.PulseFilters
{
    public abstract class PulseHeightFilter<TPulse> : PulseFilter<TPulse> where TPulse : IPulseHeight
    {
        private readonly List<Bounds<double>> pulseHeights;

        protected PulseHeightFilter(List<Bounds<double>> validPulseHeightRanges)
        {
            pulseHeights = validPulseHeightRanges;
        }

        protected PulseHeightFilter(double minPulseHeight)
        {
            pulseHeights = new List<Bounds<double>>() {new Bounds<double>(minPulseHeight, double.MaxValue)};
        }

        protected PulseHeightFilter(double pulseHeightLLD, double pulseHeightULD)
        {
            pulseHeights = new List<Bounds<double>>() {new Bounds<double>(pulseHeightLLD, pulseHeightULD)};
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (PulseIsBound(p))
                {
                    filteredPulses.Add(p);
                }
            }
        }

        private bool PulseIsBound(TPulse p)
        {
            foreach (var b in pulseHeights)
            {
                if (b.BoundsValue(GetPulseHeight(p)))
                {
                    return true;
                }
            }

            return false;
        }

        protected abstract double GetPulseHeight(TPulse pulse);
    }

    public class PulseAdcFilter<TPulse> : PulseHeightFilter<TPulse> where TPulse : IPulseWaveform
    {
        public PulseAdcFilter(List<Bounds<double>> validPulseHeightRanges) : base(validPulseHeightRanges)
        {
        }

        public PulseAdcFilter(double minPulseHeight) : base(minPulseHeight)
        {
        }

        public PulseAdcFilter(int minPulseHeight, int maxPulseHeight) : base(new List<Bounds<double>>()
        {
            new Bounds<double>(minPulseHeight, maxPulseHeight)
        })
        {
        }

        protected override double GetPulseHeight(TPulse pulse)
        {
            return pulse.GetAdcPulseMax();
            //return pulse.GetAdcIntegral();
        }
    }

    public class PulseHeightKeVeeFilter<TPulse> : PulseHeightFilter<TPulse> where TPulse : IPulseHeight
    {
        public PulseHeightKeVeeFilter(List<Bounds<double>> validPulseHeightRanges) : base(validPulseHeightRanges)
        {
        }

        public PulseHeightKeVeeFilter(double minPulseHeight) : base(minPulseHeight)
        {
        }

        public PulseHeightKeVeeFilter(double pulseHeightLLD, double pulseHeightULD) : base(pulseHeightLLD,
            pulseHeightULD)
        {
        }

        protected override double GetPulseHeight(TPulse pulse)
        {
            return pulse.GetPulseHeightKeVee();
        }
    }
}
