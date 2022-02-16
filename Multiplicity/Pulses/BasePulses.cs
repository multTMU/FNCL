using System.Collections.Generic;
using GlobalHelpersDefaults;
using Multiplicity.PulseFilters;

namespace Multiplicity
{
    public static partial class PulsesHelper
    {
        public static Pulses<Pulse> GetNeutronSingleDetectorEventsFromFnclFlat(string file,
            double timeVeto = FnclHelpers.CROSSTALK_VETO_TIME)
        {
            Pulses<Pulse> pulses = new FilterMultipleEventsPulses<Pulse>(file, fileIsToBigToReadAtOnce(file),
                PulseFileType.FnclFlat, timeVeto);
            FlatFileHelper.AddPulses(pulses);
            return pulses;
        }

        public static Pulses<Pulse> GetNeutronNoCrossTalkFnclFlat<TKey>(string file,
            Dictionary<TKey, List<int>> crossTalkDictionary,
            double timeVeto = FnclHelpers.CROSSTALK_VETO_TIME)
        {
            Pulses<Pulse> pulses = new FilteredCrossTalkPulses<TKey, Pulse>(file, fileIsToBigToReadAtOnce(file),
                PulseFileType.FnclFlat, timeVeto, crossTalkDictionary);
            FlatFileHelper.AddPulses(pulses);
            return pulses;
        }

        public static Pulses<Pulse> GetFnclFlatFilePulses(string file)
        {
            Pulses<Pulse> fncl = new FnclPulses(file, fileIsToBigToReadAtOnce(file));
            FlatFileHelper.AddPulses(fncl);
            return fncl;
        }

        private class ParticleFilteredPulses<TPulse> : Pulses<TPulse> where TPulse : IPulse
        {
            private readonly Particle particle;
            private IPulseFilter<TPulse> filter;

            public ParticleFilteredPulses(string file, bool bigFile, Particle particleToUse) : base(
                file, bigFile, PulseFileType.PoliMi)
            {
                particle = particleToUse;
                filter = new ParticleFilter<TPulse>(particle);
            }

            protected override List<IPulseFilter<TPulse>> GetFilters()
            {
                return new List<IPulseFilter<TPulse>>() {filter};
            }
        }

        private class FnclPulses : Pulses<Pulse>
        {
            public FnclPulses(string file, bool bigFile) : base(file, false, PulseFileType.FnclFlat)
            {
            }
        }

        private class FilterMultipleEventsPulses<TPulse> : Pulses<TPulse> where TPulse : IPulse
        {
            protected double timeVeto;

            public FilterMultipleEventsPulses(string file, bool largeFile, PulseFileType fileType,
                in double TimeVeto) : base(file, largeFile, fileType)
            {
                timeVeto = TimeVeto;
            }

            protected override List<IPulseFilter<TPulse>> GetFilters()
            {
                return new List<IPulseFilter<TPulse>>()
                {
                    new FilterMultipleEventsInOneDetector<TPulse>(timeVeto, DetectorsInFile)
                };
            }
        }

        private class FilteredCrossTalkPulses<TKey, TPulse> : FilterMultipleEventsPulses<TPulse> where TPulse : IPulse
        {
            private readonly Dictionary<TKey, List<int>> crossTalkDictionary;

            public FilteredCrossTalkPulses(string file, bool largeFile, PulseFileType fileType,
                in double TimeVeto, in Dictionary<TKey, List<int>> CrossTalkDictionary) : base(file, largeFile,
                fileType, in TimeVeto)
            {
                crossTalkDictionary = CrossTalkDictionary;
            }

            protected override List<IPulseFilter<TPulse>> GetFilters()
            {
                return new List<IPulseFilter<TPulse>>()
                {
                    new FilterCrossTalk<TKey, TPulse>(timeVeto, crossTalkDictionary)
                };
            }
        }
    }
}
