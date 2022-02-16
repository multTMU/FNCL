using System.Collections.Generic;
using GlobalHelpersDefaults;
using Multiplicity.PulseFilters;

namespace Multiplicity
{
    public static partial class PulsesHelper
    {
        public static Pulses<PoliMiPulse> GetDefaultFncLPoliMiPulses(string file, double activity, int mcnpNPS,
            int seed)
        {
            Pulses<PoliMiPulse> pulses =
                new FnclPoliMiPulses(file, fileIsToBigToReadAtOnce(file), activity, mcnpNPS, seed);
            PoliMiFileHelper.AddPulses(pulses);
            return pulses;
        }

        public static Pulses<PoliMiPulse> GetPoliMiPulses(string file)
        {
            Pulses<PoliMiPulse> pulses = new PoliMiPulses(file, fileIsToBigToReadAtOnce(file));
            PoliMiFileHelper.AddPulses(pulses);
            return pulses;
        }

        public static Pulses<PoliMiPulse> GetNeutronPulsesFromPoliMi(string file)
        {
            Pulses<PoliMiPulse> pulses =
                new ParticleFilteredPulses<PoliMiPulse>(file, fileIsToBigToReadAtOnce(file), Particle.Neutron);
            PoliMiFileHelper.AddPulses(pulses);
            return pulses;
        }

        public static Pulses<PoliMiPulse> GetPhotonPulsesFromPoliMi(string file)
        {
            Pulses<PoliMiPulse> pulses =
                new ParticleFilteredPulses<PoliMiPulse>(file, fileIsToBigToReadAtOnce(file), Particle.Photon);
            PoliMiFileHelper.AddPulses(pulses);
            return pulses;
        }

        public class PoliMiPulses : Pulses<PoliMiPulse>
        {
            public PoliMiPulses(string file, bool bigFile) : base(file, bigFile, PulseFileType.PoliMi)
            {
            }
        }

        private class FnclPoliMiPulses : Pulses<PoliMiPulse>
        {
            private readonly double activity;
            private readonly int mcnpSamples;
            private readonly int seed;

            public FnclPoliMiPulses(string file, bool bigFile, double Activity, int McnpSamples,
                int Seed = PoliMiHistoryFilter.DEFAULT_SEED) : base(file, bigFile, PulseFileType.PoliMi)
            {
                activity = Activity;
                mcnpSamples = McnpSamples;
                seed = Seed;
            }

            protected override List<IPulseFilter<PoliMiPulse>> GetFilters()
            {
                List<IPulseFilter<PoliMiPulse>> filters;
                filters = new List<IPulseFilter<PoliMiPulse>>();
                filters.Add(new PoliMiHistoryFilter(activity, mcnpSamples, seed));
                filters.AddRange(GetFnclPostHistoryFilters());
                return filters;
            }
        }

        private static List<IPulseFilter<PoliMiPulse>> GetFnclPostHistoryFilters()
        {
            List<IPulseFilter<PoliMiPulse>> filters = new List<IPulseFilter<PoliMiPulse>>();
            filters.Add(new ParticleFilter<PoliMiPulse>(FnclHelpers.PARTICLE));
            filters.Add(new PulseHeightKeVeeFilter<PoliMiPulse>(FnclHelpers.GetDefaultPulseHeightBounds()));
            filters.Add(new FilterCrossTalk<string, PoliMiPulse>(FnclHelpers.CROSSTALK_VETO_TIME,
                FnclHelpers.GetDefaultCrossTalkDictionaryPoliMi()));
            return filters;
        }
    }
}
