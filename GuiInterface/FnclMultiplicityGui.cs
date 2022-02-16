using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalHelpers;
using GlobalHelpersDefaults;
using Multiplicity;
using Multiplicity.PulseFilters;

namespace GuiInterface
{
    public class FnclBinaryMultiplicityGui : BaseMultiplicityGuiInterface<FnclPulse>
    {
        public FnclBinaryMultiplicityGui(string PulseFile) : base(PulseFile)
        {
        }

        public override void CombineAndSavePulsesBatch(string filePrefix, double countTimeSec, double maxFileSizeMb,
            bool applyFilters,
            bool active, bool passive)
        {
            if (applyFilters)
            {
                CombineBinaryPulses.SavePulses(pulseFile, filePrefix, countTimeSec, maxFileSizeMb, active,
                    passive, filteredPulses.SavedFilters);
            }
            else
            {
                CombineBinaryPulses.SavePulses(pulseFile, filePrefix, countTimeSec, maxFileSizeMb, active,
                    passive);
            }
        }

        public override bool GuiEnableBatchPulseCombine()
        {
            return true;
        }

        public override void SetPsdParameters(DetectorKey detectorKey, PsdSpecification psd)
        {
            PulseShapeDiscriminationCalibration.SetDetector(detectorKey, psd);
        }

        public override PsdWaveformGui GetPsdPulseWaveform(int pulseIndex, PsdSpecification psdSpecification,
            DetectorKey detector)
        {
            Pulses<FnclPulse> psdViewerPulses = GetPulsesForDetector(detector);
            return PulseShapeDiscriminators.GetPsdWaveformGuiFromPulse(psdSpecification,
                psdViewerPulses.GetPulseByIndex(pulseIndex));
        }

        public override List<int> GetPulseWaveForm(int pulseIndex)
        {
            return pulses.GetPulseByIndex(pulseIndex).GetAdcWaveform();
        }

        public override PsdSpecification GetPsdSpecs(DetectorKey detectorKey)
        {
            return PulseShapeDiscriminationCalibration.GetCalibrationByDetector(detectorKey);
        }

        public override void LoadPsdFromFnclSettings()
        {
            FnclSettingsFileHelper.SetPsdCalibrationFromSettings(pulseFile);
        }

        protected override Pulses<FnclPulse> GetPulsesFromFile()
        {
            return PulsesHelper.GetFnclBinaryFilePulses(pulseFile);
        }

        public override PulseFileType GetPulseType()
        {
            return PulseFileType.FnclBinary;
        }

        public override bool GuiPoliMiSpecs()
        {
            return false;
        }

        public override bool GuiEnableParticleSelect()
        {
            return true; // only for PSD
        }

        public override bool GuiPulseHeight()
        {
            return true;
        }

        public override bool GuiPSD()
        {
            return true;
        }

        public override int GetStartingDetectorIndex()
        {
            return FnclHelpers.FIRST_DETECTOR_INDEX;
        }

        public override void RejectPileUp(double scalar, double interval)
        {
            filteredPulses.RunExternalFilter(new PileUpRejector<FnclPulse>(interval, scalar));
        }

        public override void FilterFlatTop(double duration, double peakMaxTolerancePercent)
        {
            filteredPulses.RunExternalFilter(new PulseFlatTopFilter<FnclPulse>(duration, peakMaxTolerancePercent));
        }

        public override void PulseShapeDiscrimination(Particle filterParticle, string psdFile = "")
        {
            if (File.Exists(psdFile))
            {
                PulseShapeDiscriminationCalibration.LoadPsdCalibrationFromFile(psdFile);
            }

            filteredPulses.RunExternalFilter(
                new PulseShapeDiscriminatorCalibrationFilter<FnclPulse>(filterParticle));
        }

        public override List<PsdComponent> GetPsdForPulses(DetectorKey detectorKey, int numberPulses)
        {
            PsdSpecification detectorPSD = PulseShapeDiscriminationCalibration.GetCalibrationByDetector(detectorKey);

            return PulseShapeDiscriminators.GetPsd(detectorPSD.TriggerType, detectorPSD.Trigger,
                GetPulsesForDetector(detectorKey), (int)detectorPSD.Fast,
                (int)detectorPSD.Slow, numberPulses, detectorPSD.AmplitudeDivisor);
        }

        public override void FilterByAdcTrigger(int adcLLD, int adcULD)
        {
            filteredPulses.RunExternalFilter(new PulseAdcFilter<FnclPulse>(adcLLD, adcULD));
            base.FilterByAdcTrigger(adcLLD, adcULD);
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
            else
            {
                foreach (var p in filteredPulses.GetPulses())
                {
                    pulseAmp.Add(p.GetAdcPulseMax());
                }
            }

            return pulseAmp;
        }

        public override void FilterPulseHeightKeVee(double pulseHeightLLD, double pulseHeightULD)
        {
            filteredPulses.RunExternalFilter(
                new PulseHeightKeVeeFilter<FnclPulse>(pulseHeightLLD, pulseHeightULD));
            base.FilterPulseHeightKeVee(pulseHeightLLD, pulseHeightULD);
        }

        public override bool GuiEnablePileUpRejector()
        {
            return true;
        }

        public override List<AppliedPulseFilters> GetApplicableFilters()
        {
            return new List<AppliedPulseFilters>()
            {
                AppliedPulseFilters.Particle,
                AppliedPulseFilters.Detectors,
                AppliedPulseFilters.FlatTop,
                AppliedPulseFilters.ADC,
                AppliedPulseFilters.PileUp,
                AppliedPulseFilters.Energy,
                AppliedPulseFilters.Offset,
                AppliedPulseFilters.CrossTalk,
                AppliedPulseFilters.Correlated,
                AppliedPulseFilters.Stream
            };
        }

        public override bool GetIsPileUp(int pulseIndex, double scalar, double interval)
        {
            PileUpRejector<FnclPulse> pileUp = new PileUpRejector<FnclPulse>(interval, scalar);
            return pileUp.IsPiledUp(filteredPulses.GetPulseByIndex(pulseIndex));
        }
    }

    public class FnlcPoliMiMultiplicityGui : BaseMultiplicityGuiInterface<PoliMiPulse>
    {
        private List<PulsesHelper.PoliMiSimulations> poliMiProblems;

        public FnlcPoliMiMultiplicityGui(string PulseFile) : base(PulseFile)
        {
            poliMiProblems = new List<PulsesHelper.PoliMiSimulations>();
        }

        public FnlcPoliMiMultiplicityGui(List<PulsesHelper.PoliMiSimulations> poliMiSimulationsList, int seed) : base(
            poliMiSimulationsList.First().PulseFile)
        {
            poliMiProblems = poliMiSimulationsList;
            WritePoliMiProblemsToFile();
            pulses = PulsesHelper.GetCombinedPulses(poliMiProblems, seed);
            ClonePulses();
        }

        private void WritePoliMiProblemsToFile()
        {
            foreach (var p in poliMiProblems)
            {
                p.WriteToFile();
            }
        }

        public override int GetFileSize()
        {
            int fileSize = 0;
            foreach (var p in poliMiProblems)
            {
                FileInfo info = new FileInfo(p.PulseFile);
                fileSize += (int)(info.Length / 1000000);
            }

            return fileSize;
        }

        public override DateTime GetFileCreationTime()
        {
            DateTime newest = DateTime.MinValue;
            foreach (var p in poliMiProblems)
            {
                FileInfo info = new FileInfo(p.PulseFile);
                if (info.CreationTime > newest)
                {
                    newest = info.CreationTime;
                }
            }

            return newest;
        }

        protected override Pulses<PoliMiPulse> GetPulsesFromFile()
        {
            return PulsesHelper.GetPoliMiPulses(pulseFile);
        }

        public override bool GuiEnableParticleSelect()
        {
            return true;
        }

        public override List<AppliedPulseFilters> GetApplicableFilters()
        {
            return new List<AppliedPulseFilters>()
            {
                AppliedPulseFilters.Particle,
                AppliedPulseFilters.Detectors,
                AppliedPulseFilters.Energy,
                AppliedPulseFilters.Offset,
                AppliedPulseFilters.CrossTalk,
                AppliedPulseFilters.Correlated,
                AppliedPulseFilters.Stream
            };
        }

        public override PulseFileType GetPulseType()
        {
            return PulseFileType.PoliMi;
        }

        public override bool GuiPoliMiSpecs()
        {
            return true;
        }

        public override bool GuiPulseHeight()
        {
            return true;
        }

        public override bool GuiPSD()
        {
            return false;
        }

        public override void FilterByParticle(Particle particle)
        {
            filteredPulses.RunExternalFilter(new ParticleFilter<PoliMiPulse>(particle));
            base.FilterByParticle(particle);
        }

        public override int GetStartingDetectorIndex()
        {
            return GlobalDefaults.FIRST_POLIMI_DETECTOR_INDEX;
        }

        public override void FilterPulseHeightKeVee(double pulseHeightLLD, double pulseHeightULD)
        {
            filteredPulses.RunExternalFilter(
                new PulseHeightKeVeeFilter<PoliMiPulse>(pulseHeightLLD, pulseHeightULD));
            base.FilterPulseHeightKeVee(pulseHeightLLD, pulseHeightULD);
        }

        public override List<PulsesHelper.PoliMiSimulations> GetPoliMiProblems()
        {
            return poliMiProblems;
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
    }

    public class FnclTimeStampMultiplicityGui : BaseMultiplicityGuiInterface<Pulse>
    {
        public FnclTimeStampMultiplicityGui(string PulseFile) : base(PulseFile)
        {
        }

        protected override Pulses<Pulse> GetPulsesFromFile()
        {
            return PulsesHelper.GetFnclFlatFilePulses(pulseFile);
        }

        public override PulseFileType GetPulseType()
        {
            return PulseFileType.FnclFlat;
        }

        public override bool GuiPoliMiSpecs()
        {
            return false;
        }

        public override bool GuiPulseHeight()
        {
            return false;
        }

        public override List<AppliedPulseFilters> GetApplicableFilters()
        {
            return new List<AppliedPulseFilters>()
            {
                AppliedPulseFilters.Particle,
                AppliedPulseFilters.Detectors,
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

        public override int GetStartingDetectorIndex()
        {
            return FnclHelpers.FIRST_DETECTOR_INDEX;
        }
    }
}
