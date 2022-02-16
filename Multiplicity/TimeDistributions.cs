using System.Collections.Generic;

namespace Multiplicity
{
    public static class TimeDistributions<TPulse> where TPulse : IPulse
    {
        public const int NO_TIME_CONSTRAINT = 0;

        public static List<double> GetIntervalDistribution(Pulses<TPulse> pulses,
            double MinInterval = NO_TIME_CONSTRAINT, double MaxInterval = NO_TIME_CONSTRAINT)
        {
            List<double> intervalTimes = new List<double>();

            bool boundAbove = (int)MaxInterval != NO_TIME_CONSTRAINT;
            bool boundBelow = (int)MinInterval != NO_TIME_CONSTRAINT;

            for (int i = 0; i < pulses.NumberOfPulses - 1; i++)
            {
                double pulseInterval = pulses.GetPulseTimeByIndex(i + 1) - pulses.GetPulseTimeByIndex(i);
                if (AddPulseInterval(boundBelow, MinInterval, boundAbove, MaxInterval, pulseInterval))
                {
                    intervalTimes.Add(pulseInterval);
                }
            }

            return intervalTimes;
        }

        private static bool AddPulseInterval(bool boundBelow, double minInterval, bool boundAbove, double maxInterval,
            double pulseInterval)
        {
            if (boundAbove && !boundBelow)
            {
                return pulseInterval <= maxInterval;
            }

            if (!boundAbove && boundBelow)
            {
                return pulseInterval >= minInterval;
            }

            if (boundAbove && boundBelow)
            {
                return (pulseInterval <= maxInterval) && (pulseInterval >= minInterval);
            }

            return true;
        }
    }
}
