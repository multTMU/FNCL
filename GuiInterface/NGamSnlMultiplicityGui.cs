using System.Collections.Generic;
using Multiplicity;
using Multiplicity.PulseFilters;

namespace GuiInterface
{
    public class NGamSnlMultiplicityGui : BaseMultiplicityGuiInterface<NGamSnlPulse>
    {
        public NGamSnlMultiplicityGui(string PulseFile) : base(PulseFile)
        {
        }

        protected override Pulses<NGamSnlPulse> GetPulsesFromFile()
        {
            return PulsesHelper.GetNGamSnlPulses(pulseFile);
        }

        public override int GetStartingDetectorIndex()
        {
            return 0; // being "lazy" because I turned in my 2 weeks notice
        }

        public override PulseFileType GetPulseType()
        {
            return PulseFileType.NGamSnl;
        }

        public override bool GuiPoliMiSpecs()
        {
            return false;
        }

        public override bool GuiPulseHeight()
        {
            return true;
        }

        public override List<double> GetPAD()
        {
            List<double> pulseAmp = new List<double>();

            if (amplitudeType == PulseAmplitudeType.KeVee)
            {
                foreach (var p in filteredPulses.GetPulses())
                {
                    pulseAmp.Add(p.GetPulseHeightKeVee());
                }
            }

            return pulseAmp;
        }

        public override void FilterPulseHeightKeVee(double pulseHeightLLD, double pulseHeightULD)
        {
            filteredPulses.RunExternalFilter(
                new PulseHeightKeVeeFilter<NGamSnlPulse>(pulseHeightLLD, pulseHeightULD));
            base.FilterPulseHeightKeVee(pulseHeightLLD, pulseHeightULD);
        }

        public override List<AppliedPulseFilters> GetApplicableFilters()
        {
            return new List<AppliedPulseFilters>()
            {
                AppliedPulseFilters.Detectors,
                AppliedPulseFilters.Energy,
                AppliedPulseFilters.Offset,
                AppliedPulseFilters.CrossTalk,
                AppliedPulseFilters.Correlated,
                AppliedPulseFilters.Stream
            };
        }

        public override bool GuiPSD()
        {
            return false;
        }
    }
}
