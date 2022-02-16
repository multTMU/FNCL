using System;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class FnclAnalysisGUI
    {
        private PulseFilters filters;
        private CombineBatchPulseFiles combinePulsesBatch;

        private void RunPulseFilters(object sender, EventArgs e)
        {
            RunCurrentPulseFilters();
        }

        private void SaveCurrentFilters(string saveFile)
        {
            throw new NotImplementedException();
        }

        private void RunCurrentPulseFilters()
        {
            StartBusy("Running Pulse Filters...");
            guiLogicAnalysis.ResetFilteredPulses();
            guiLogicAnalysis.ResetSavedFilters();

            foreach (AppliedPulseFilters f in filters.GetFilterOrder())
            {
                switch (f)
                {
                    case AppliedPulseFilters.Particle:
                        guiLogicAnalysis.FilterPSD(filters.GetParticle(), filters.GetPsdFile());
                        guiLogicAnalysis.FilterByParticle(filters.GetParticle());
                        break;

                    case AppliedPulseFilters.Detectors:
                        guiLogicAnalysis.FilterByDetectors(filters.GetSelectedDetectors());
                        break;

                    case AppliedPulseFilters.ADC:
                        guiLogicAnalysis.FilterADC(filters.GetAdcLLD(), filters.GetAdcULD());
                        break;

                    case AppliedPulseFilters.Offset:
                        guiLogicAnalysis.TimeShift(filters.GetPanelOneOffSets(), filters.GetPanelTwoOffSets(),
                            filters.GetPanelThreeOffSets());
                        break;

                    case AppliedPulseFilters.Energy:
                        guiLogicAnalysis.FilterByPulseHeightKeVee(filters.GetPulseHeightLLDKeVee(),
                            filters.GetPulseHeightULDKeVee());
                        break;

                    case AppliedPulseFilters.Correlated:
                        guiLogicAnalysis.FilterCorrelatedPulseSelector(filters.GetMaxTimeBetweenPulses());
                        break;

                    case AppliedPulseFilters.CrossTalk:
                        guiLogicAnalysis.FilterByCrossTalk(filters.GetPileUp(), filters.GetDetectorCrossTalk());
                        break;

                    case AppliedPulseFilters.Stream:
                        guiLogicAnalysis.FilterByTimeWindow(filters.GetStartTime(), filters.GetEndTime());
                        break;

                    case AppliedPulseFilters.PileUp:
                        guiLogicAnalysis.PileUpRejector(filters.GetPileUpScalar(), filters.GetPileUpInterval());
                        break;

                    case AppliedPulseFilters.FlatTop:
                        guiLogicAnalysis.FilterFlatTop(filters.GetFlatTopDuration(),
                            filters.GetFlatTopPeakMaxPercent());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            UpdateMainForm();
            EndBusy();
        }

        private void bFilter_Click(object sender, EventArgs e)
        {
            filters?.Close();

            filters = new PulseFilters();

            filters.SetDefaults(DetectorDefaults.GetPulseHeightLLD(), DetectorDefaults.GetPulseHeightULD(),
                DetectorDefaults.GetCrosstalkVetoTime(), DetectorDefaults.GetCrosstalk(),
                DetectorDefaults.GetAdCTrigger(),
                guiLogicAnalysis.GetFirstPulseTime(),
                guiLogicAnalysis.GetLastPulseTime(), DetectorDefaults.GetCorrelatedPulseTime(),
                guiLogicAnalysis.GetFilterOrder(), DetectorDefaults.GetParticle(), DetectorDefaults.GetPileUpInterval(),
                DetectorDefaults.GetPileUpScalar(), DetectorDefaults.GetFlatTopDuration(),
                DetectorDefaults.GetFlatTopPeakMaxTolerancePercent());

            filters.EnableParticleSelector(guiLogicAnalysis.EnableParticleSelect());
            filters.EnablePulseHeight(guiLogicAnalysis.EnablePulseHeight());
            filters.EnablePSD(guiLogicAnalysis.EnablePSD());
            filters.EnableADCtrigger(guiLogicAnalysis.EnablePAD());
            filters.EnableCorrelatedPulseTime(guiLogicAnalysis.EnableCorrelatedPulseTime());
            filters.EnablePileUpRejection(guiLogicAnalysis.EnablePileUpRejector());
            filters.EnableBatchCombinePulses(guiLogicAnalysis.EnableBatchCombinePulses());

            filters.RunFilters += RunPulseFilters;
            filters.ResetPulses += ResetPulses;
            filters.EditCurrentPsd += EditCurrentPsd;
            filters.BatchCombinePulses += LaunchBatchCombinePulses;
            filters.SaveCurrentToFlat += SaveCurrentPulses;
            filters.Show();
        }

        private void SaveCurrentPulses(object sender, EventArgs e)
        {
            OnSaveCurrentPulses();
        }

        private void OnSaveCurrentPulses()
        {
            SavePulses();
        }

        private void LaunchBatchCombinePulses(object sender, EventArgs e)
        {
            combinePulsesBatch?.Close();
            combinePulsesBatch = new CombineBatchPulseFiles();
            combinePulsesBatch.RunBatchCombinePulsesToFlat += OnRunBatchCombinePulses;
            combinePulsesBatch.Show();
        }

        private void OnRunBatchCombinePulses(object sender, EventArgs e)
        {
            RunBatchCombinePulses();
        }

        private void RunBatchCombinePulses()
        {
            if (combinePulsesBatch.IsHandleCreated)
            {
                bool applyFilters = combinePulsesBatch.ApplyFilters;
                if (applyFilters)
                {
                    RunCurrentPulseFilters();
                }

                StartBusy("Combine and Save Pulses...");
                guiLogicAnalysis.CombineAndSavePulsesBatch(combinePulsesBatch.FilePrefix,
                    combinePulsesBatch.CountTimeSec, combinePulsesBatch.MaxFileSizeMB, applyFilters,
                    combinePulsesBatch.CombineActive, combinePulsesBatch.CombinePassive);
                EndBusy();
            }
        }
    }
}
