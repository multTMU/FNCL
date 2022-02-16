using System.Collections.Generic;

namespace Multiplicity
{
    public static class DetectorResponses
    {
        public static Dictionary<int, double> GetDetectorResponses<TPulse>(Pulses<TPulse> pulses, double activity)
            where TPulse : IPulse
        {
            Dictionary<int, double> drf = new Dictionary<int, double>();
            double numberOfParticles = pulses.GetTimeOfLastPulse() * PulsesHelper.ConvertActivityToPerNanoSec(activity);

            foreach (var det in pulses.DetectorsInFile)
            {
                Pulses<TPulse> detectorPulses = pulses.Clone();
                detectorPulses.RunExternalFilter(new PulseFilters.FilterByDetector<TPulse>(det));
                drf.Add(det, CalculateEfficiency(detectorPulses, numberOfParticles));
            }

            return drf;
        }

        private static double CalculateEfficiency<TPulse>(Pulses<TPulse> detectorPulses, double numberOfParticles)
            where TPulse : IPulse
        {
            if (numberOfParticles <= 0)
            {
                return 0.0;
            }

            return detectorPulses.NumberOfPulses / numberOfParticles;
        }
    }
}
