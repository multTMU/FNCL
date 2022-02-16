using System;
using System.Collections.Generic;

namespace Multiplicity
{
    public readonly struct DoublesKey : IEquatable<DoublesKey>
    {
        public readonly int DetectorA;
        public readonly int DetectorB;

        public DoublesKey(int detectorA, int detectorB)
        {
            DetectorA = detectorA;
            DetectorB = detectorB;
        }

        public bool Equals(DoublesKey other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (this.DetectorA * this.DetectorB).GetHashCode();
        }

        public override string ToString()
        {
            return "(" + DetectorA + "," + DetectorB + ")";
        }
    }

    /// <summary>
    /// Makes the doubles matrix (symmetric) given a list of detectors
    /// </summary>
    /// Must implement IPulse, but beyond that is just for any Pulse filters applied
    public static class MultipletMatricesHelper<TPulse> where TPulse : IPulse
    {
        public static Dictionary<DoublesKey, MultiplicityRates> GetMultipletRatesMatrix(Pulses<TPulse> Pulses,
            List<int> Detectors, int GateWidth, int PreDelay, int LongDelay)
        {
            Pulses<TPulse> savePulses = Pulses.Clone();
            Dictionary<DoublesKey, MultiplicityRates> doublesMatrix = new Dictionary<DoublesKey, MultiplicityRates>();
            MultiplicityRates allDetectorsRates =
                MultiplicityRatesHelper<TPulse>.GetMultiplicityRates(
                    MultiplicityGatesHelper.GetMultiplicityGate(Pulses, PreDelay, LongDelay), GateWidth);

            foreach (var a in Detectors)
            {
                foreach (var b in Detectors)
                {
                    var key = new DoublesKey(a, b);
                    if (!doublesMatrix.ContainsKey(key))
                    {
                        doublesMatrix.Add(key,
                            GetFilteredRates(GateWidth, PreDelay, LongDelay, savePulses, key) / allDetectorsRates);
                    }
                }
            }

            return doublesMatrix;
        }

        private static MultiplicityRates GetFilteredRates(int GateWidth, int PreDelay, int LongDelay,
            Pulses<TPulse> savePulses, DoublesKey key)
        {
            Pulses<TPulse> pulses = savePulses.Clone();
            pulses.RunExternalFilter(
                new PulseFilters.FilterByDetector<TPulse>(new List<int>() {key.DetectorA, key.DetectorB}));

            var rates = MultiplicityRatesHelper<TPulse>.GetMultiplicityRates(
                MultiplicityGatesHelper.GetMultiplicityGate(pulses, PreDelay, LongDelay), GateWidth);
            return rates;
        }
    }
}
