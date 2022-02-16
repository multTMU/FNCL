using System;
using System.Collections.Generic;
using GeometrySampling;

namespace Multiplicity.PulseFilters
{
    /// <summary>
    /// Based on method described in Caen FNCL manual UM7098 page 18
    /// </summary>
    /// <typeparam name="TPulse"></typeparam>
    public class PileUpRejector<TPulse> : PulseFilter<TPulse> where TPulse : IPulseWaveform
    {
        private readonly double timeDelta;
        private readonly double scalar;
        private Bounds<double> leftTimes;
        private Bounds<double> centralTimes;
        private Bounds<double> rightTimes;

        public PileUpRejector(double TimeDelta, double Scalar)
        {
            timeDelta = TimeDelta;
            scalar = Scalar;

            leftTimes = new Bounds<double>(0, 0);
            centralTimes = new Bounds<double>(0, 0);
            rightTimes = new Bounds<double>(0, 0);
        }

        public bool IsPiledUp(TPulse pulse)
        {
            return isPileUp(pulse);
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (!isPileUp(p))
                {
                    filteredPulses.Add(p);
                }
            }
        }

        private bool isPileUp(TPulse pulse)
        {
            double maxTimeOfWaveform = pulse.GetTimeDurationOfWaveform();
            int startIndexLeft = 0;

            SetIntegrationIndices(pulse.GetTimeOfIndex(startIndexLeft));
            while (rightTimes.Upper < maxTimeOfWaveform)
            {
                startIndexLeft++;
                if (isPileUp(IntegratePulse(pulse, leftTimes), IntegratePulse(pulse, centralTimes),
                    IntegratePulse(pulse, rightTimes)))
                {
                    return false;
                }

                SetIntegrationIndices(pulse.GetTimeOfIndex(startIndexLeft));
            }

            return true;
        }

        private bool isPileUp(double leftTimeIntegral, double centralTimeIntegral, double rightTimeIntegral)
        {
            double leftTest = centralTimeIntegral - ((leftTimeIntegral + rightTimeIntegral) / 2.0);
            double rightTest = scalar * Math.Sqrt(centralTimeIntegral + ((leftTimeIntegral + rightTimeIntegral) / 4.0));

            return (leftTest >= rightTest);
        }

        private double IntegratePulse(TPulse pulse, Bounds<double> timeBounds)
        {
            return pulse.IntegratePulseByTimes(timeBounds.Lower, timeBounds.Upper);
        }

        private void SetIntegrationIndices(double leftStartTime)
        {
            leftTimes.Lower = leftStartTime;
            leftTimes.Upper = leftTimes.Lower + timeDelta;

            centralTimes.Lower = leftTimes.Upper;
            centralTimes.Upper = centralTimes.Lower + timeDelta;

            rightTimes.Lower = centralTimes.Upper;
            rightTimes.Upper = rightTimes.Lower + timeDelta;
        }
    }
}
