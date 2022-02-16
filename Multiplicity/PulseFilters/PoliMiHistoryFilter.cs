using System;
using System.Collections.Generic;
using MathNet.Numerics.Distributions;

namespace Multiplicity.PulseFilters
{
    public class PoliMiHistoryFilter : PulseFilter<PoliMiPulse>
    {
        public const int DEFAULT_SEED = 0;
        private const int STARTING_INVALID_HISTORY = -1;
        private const double MAX_EXPECETED_TIME = 1e9;
        private readonly double activity;
        private readonly Random rand;
        private readonly double maxTime;

        private double timeOffset;

        public PoliMiHistoryFilter(double ActivityBqs, int McnpSamplesNps, int Seed = DEFAULT_SEED)
        {
            activity = ActivityBqs;
            rand = new Random(GetRandomSeed(Seed));
            maxTime = SampleMeasurementTimeNanoSec(activity, McnpSamplesNps, rand);
        }

        public static double SampleMeasurementTimeNanoSec(double activityBqs, int mcnpSamples, Random randGen)
        {
            double expectedTime = PulsesHelper.ConvertSecondsToNanoSeconds((double)mcnpSamples / activityBqs);
            return (expectedTime > MAX_EXPECETED_TIME) ? expectedTime : Poisson.Sample(randGen, expectedTime);
        }

        protected override void filterPulses(List<PoliMiPulse> unfilteredPulses)
        {
            int currentHistory = STARTING_INVALID_HISTORY;

            foreach (var p in unfilteredPulses)
            {
                if (p.History != currentHistory)
                {
                    currentHistory = p.History;
                    timeOffset = GetNextTime();
                }

                AddTimeShiftedPulse(p);
            }

            FilterPulsesByTime();
        }

        private void FilterPulsesByTime()
        {
            TimeOrderFilter<PoliMiPulse> timeFilter = new TimeOrderFilter<PoliMiPulse>();
            filteredPulses = timeFilter.GetFilteredPulses(filteredPulses);
        }

        private void AddTimeShiftedPulse(PoliMiPulse historyPulse)
        {
            PoliMiPulse timePulse = historyPulse;
            timePulse.ShiftTime(timeOffset);
            filteredPulses.Add(timePulse);
        }

        private static int GetRandomSeed(int seed)
        {
            return (seed == DEFAULT_SEED) ? (int)DateTime.Now.Ticks : seed;
        }

        private double GetNextTime()
        {
            return maxTime * GetRandom();
        }

        private double GetRandom()
        {
            return rand.NextDouble();
        }
    }

    public class PoliMiConvertTimeToHistorySorted : PulseFilter<PoliMiPulse>
    {
        protected override void filterPulses(List<PoliMiPulse> unfilteredPulses)
        {
            unfilteredPulses.Sort((x, y) => x.History.CompareTo(y.History));
            filteredPulses = unfilteredPulses;
        }
    }
}
