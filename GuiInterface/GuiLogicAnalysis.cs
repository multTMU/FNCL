using System;
using System.Collections.Generic;
using GlobalHelpersDefaults;
using Multiplicity;

namespace GuiInterface
{
    public class GuiLogicAnalysis
    {
        public string PulseFile { get; private set; }
        public string PsdFile => pulseManager.GetPsdFile();

        public double GetPoliMiActivity
        {
            get { return poliMiSpecs.ActivityBqs; }
        }

        public int GetPoliMiMcnpNPS
        {
            get { return poliMiSpecs.McnpNPS; }
        }

        private IGuiInterface pulseManager;

        public void ResetSavedFilters()
        {
            pulseManager.ResetSavedFilters();
        }

        private MultiplicityRates rates;
        private PulsesHelper.PoliMiSimulations poliMiSpecs;

        public GuiLogicAnalysis()
        {
            pulseManager = new UndefinedPulsesForGui();
            PulseFile = string.Empty;
        }

        public void SetPulseFile(string file)
        {
            PulseFile = file;
            pulseManager = MultiplicityInterfaceHelper.GetMulitiplicityGUIhelper(PulseFile);
            UpdateDictionaries();
        }

        public List<int> GetRandAHisto()
        {
            return pulseManager.GetRealsAndAccidentals();
        }

        public int GetNumberFilteredPulses(DetectorKey detectorKey)
        {
            return pulseManager.GetNumberFilteredPulses(detectorKey);
        }

        public List<int> GetRealsHisto()
        {
            return pulseManager.GetReals();
        }

        public double GetCountTime()
        {
            return pulseManager.GetCountTime();
        }

        public DateTime GetCreation()
        {
            try
            {
                return pulseManager.GetFileCreationTime();
            }
            catch
            {
                return DateTime.MaxValue;
            }
        }

        public int GetNumberUnfilteredPulses()
        {
            return pulseManager.GetNumberUnFilteredPulses();
        }

        public bool EnablePoliMiComponents()
        {
            return pulseManager.GuiPoliMiSpecs();
        }

        public int GetFileSize()
        {
            try
            {
                return pulseManager.GetFileSize();
            }
            catch
            {
                return 0;
            }
        }

        public string GetPulseTypeString()
        {
            return MultiplicityInterfaceHelper.GetPulseTypeToString(pulseManager.GetPulseType());
        }

        public bool EnablePulseHeight()
        {
            return pulseManager.GuiPulseHeight();
        }

        public bool EnablePAD()
        {
            return pulseManager.GuiPulseHeight();
        }

        public bool EnablePSD()
        {
            return pulseManager.GuiPSD();
        }

        public void FilterFlatTop(double duration, double peakMaxTolerancePercent)
        {
            pulseManager.FilterFlatTop(duration, peakMaxTolerancePercent);
        }

        public bool EnablePileUpRejector()
        {
            return pulseManager.GuiEnablePileUpRejector();
        }

        public void RunMultiplicityGate(IMultiplicityViewer multViewer)
        {
            pulseManager.SetMultiplicityGate(multViewer);
            rates = pulseManager.GetMultipletRates();
            rates = rates.ConvertToSeconds();
        }

        public double GetSingles()
        {
            return rates.Singles;
        }

        public double GetDoubles()
        {
            return rates.Doubles;
        }

        public double GetTriples()
        {
            return rates.Triples;
        }

        public List<int> GetPulseWaveForm(int pulseIndex)
        {
            return pulseManager.GetPulseWaveForm(pulseIndex);
        }

        public int GetNumberFilteredPulses()
        {
            return pulseManager.GetNumberFilteredPulses();
        }

        public double GetCountTimeFiltered()
        {
            return pulseManager.GetCountTimeFiltered();
        }

        public void ResetFilteredPulses()
        {
            pulseManager.ResetFilteredPulses();
        }

        public bool GetIsPileUp(int pulseIndex, double scalar, double interval)
        {
            return pulseManager.GetIsPileUp(pulseIndex, scalar, interval);
        }

        public void FilterByDetectors(List<int> selectedDetectors)
        {
            pulseManager.FilterByDetectors(selectedDetectors);
        }

        public void FilterByPulseHeightKeVee(double pulseHeightLLD, double pulseHeightULD)
        {
            pulseManager.FilterPulseHeightKeVee(pulseHeightLLD, pulseHeightULD);
        }

        public void FilterByCrossTalk(int vetoGate, CrossTalk crossTalk)
        {
            pulseManager.FilterCrossTalk(vetoGate, crossTalk);
        }

        public List<double[]> GetPSD(DetectorKey detectorKey, int numberPulses)
        {
            List<PsdComponent> psd = pulseManager.GetPsdForPulses(detectorKey, numberPulses);
            List<double[]> plotPoints = new List<double[]>();
            foreach (var p in psd)
            {
                plotPoints.Add(new double[] {p.Amplitude, p.PSD});
            }

            return plotPoints;
        }

        public void FilterADC(int adcLLD, int adcULD)
        {
            pulseManager.FilterByAdcTrigger(adcLLD, adcULD);
        }

        public int GetNumberUnfilteredPulses(DetectorKey detectorKey)
        {
            return pulseManager.GetNumberFilteredPulses(detectorKey);
        }

        public void TimeShift(List<int> getPanelOneOffSets, List<int> getPanelTwoOffSets,
            List<int> getPanelThreeOffSets)
        {
            pulseManager.TimeShiftDetectors(MultiplicityInterfaceHelper.GeTimeShiftsForPanel(getPanelOneOffSets,
                getPanelTwoOffSets,
                getPanelThreeOffSets));
        }

        public void SetPSD(DetectorKey currentDetector, PsdSpecification psdSpecs)
        {
            pulseManager.SetPsdParameters(currentDetector, psdSpecs);
        }

        public double GetTriplesUncert()
        {
            return GetMultipletUncert();
        }

        private double GetMultipletUncert()
        {
            return 0;
        }

        public double GetSinglesUncert()
        {
            return GetMultipletUncert();
        }

        public double GetDoubleUncert()
        {
            return GetMultipletUncert();
        }

        public List<PulsesHelper.PoliMiSimulations> GetPoliMiProblems()
        {
            return pulseManager.GetPoliMiProblems();
        }

        public List<double> GetPulseTimes()
        {
            return pulseManager.GetPulseTimes();
        }

        public void SetPoliMiProblems(List<PulsesHelper.PoliMiSimulations> poliMiProblems, int seed)
        {
            pulseManager = MultiplicityInterfaceHelper.GetMulitiplicityGUIhelper(poliMiProblems, seed);
            UpdateDictionaries();
        }

        public PsdSpecification GetPsdSpecification(DetectorKey detectorKey)
        {
            return pulseManager.GetPsdSpecs(detectorKey);
        }

        private void UpdateDictionaries()
        {
            FNCLdetectorDictionary.MakeDictionary(pulseManager.GetStartingDetectorIndex());
            pulseManager.LoadPsdFromFnclSettings();
        }

        public void WriteFilteredPulsesToFile(string saveFile)
        {
            pulseManager.SaveCurrentFilteredPulsesToFile(saveFile);
        }

        public void SavePsdFile(string saveFile, PsdSpecification psdSpecification)
        {
            pulseManager.SavePsdToFile(saveFile, psdSpecification);
        }

        public void SavePsdFile(string saveFile, int psdFast, int psdSlow, double psdTrigger,
            PsdTriggerTypes psdType, double amplitudeDivisor,
            List<PsdComponent> psdCurve)
        {
            pulseManager.SavePsdToFile(saveFile,
                new PsdSpecification(psdSlow, psdFast, psdCurve, psdType, psdTrigger, amplitudeDivisor));

            //psdCurve, psdFast, psdSlow, psdType, psdTrigger));
        }

        public void SetPAD(PulseAmplitudeType amplitudeType)
        {
            pulseManager.SetPad(amplitudeType);
        }

        public List<double> GetPAD()
        {
            return pulseManager.GetPAD();
        }

        public bool EnableParticleSelect()
        {
            return pulseManager.GuiEnableParticleSelect();
        }

        public void FilterByParticle(Particle particle)
        {
            pulseManager.FilterByParticle(particle);
        }

        public void FilterByTimeWindow(double startTime, double endTime)
        {
            pulseManager.FilterTimeWindow(startTime, endTime);
        }

        public void PileUpRejector(double scalar, double interval)
        {
            pulseManager.RejectPileUp(scalar, interval);
        }

        public List<double> CalculateDieAwayRates(double minTime, double maxTime)
        {
            return pulseManager.CalculateDieAway(minTime, maxTime);
        }

        //public double[] GetDieAwayGatesPlot()
        //{
        //    return pulseManager.GetDieAwayGatesPlot();
        //}

        public List<Tuple<double, double>> GetDieAwayIntervals()
        {
            return pulseManager.GetDieAwayLine();
        }

        public List<Tuple<double, double>> GetDieAwayFitLine()
        {
            return pulseManager.GetDieAwayFitLine();
        }

        public void CalculateDieAwayFit(CurveFitType FitType, List<Tuple<double, double>> dieAwayHistogram)
        {
            pulseManager.CalculateDieAwayFit(FitType, dieAwayHistogram);
        }

        public List<double> GetDieAwayFitParameters()
        {
            return pulseManager.GetDieAwayFitParameters();
        }

        public void SelectedDetectorChanged(DetectorType selectedDetectorType)
        {
            DetectorDefaults.UpdateSelectedDetector(selectedDetectorType);
            DetectorEnergyCalibration.DetectorChagned(selectedDetectorType);
            pulseManager.UpdateSelectedDetector(selectedDetectorType);
        }

        public double GetFirstPulseTime()
        {
            return pulseManager.GetFirstPulseTime();
        }

        public double GetLastPulseTime()
        {
            return pulseManager.GetLastPulseTime();
        }

        public void FilterCorrelatedPulseSelector(int maxTimeBetweenPulses)
        {
            pulseManager.CorrelatedPulseSelector(maxTimeBetweenPulses);
        }

        public bool EnableCorrelatedPulseTime()
        {
            return pulseManager.GuiEnableCorrelatedPulseTime();
        }

        public void FilterPSD(Particle filterParticle, string psdFile = "")
        {
            pulseManager.PulseShapeDiscrimination(filterParticle, psdFile);
        }

        public void LoadPsdFile(string psdPsdFile)
        {
            pulseManager.LoadPsdFile(psdPsdFile);
        }

        public bool AbleToSetPoliMiSpecs(string poliMiFile)
        {
            try
            {
                poliMiSpecs = new PulsesHelper.PoliMiSimulations(poliMiFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Dictionary<int, double> CalculateDrf(double drfSourceRate)
        {
            return pulseManager.CalculateDrf(drfSourceRate);
        }

        public double GetDieAwayGoodnessOfFit()
        {
            return pulseManager.GetDieAwayGoodnessOfFit();
        }

        public PsdWaveformGui GetPsdPulseWaveform(int pulseIndex, PsdSpecification psdSpecification,
            DetectorKey detector)
        {
            return pulseManager.GetPsdPulseWaveform(pulseIndex, psdSpecification, detector);
        }

        public void CombineAndSavePulsesBatch(string filePrefix, double countTimeSec, double maxFileSizeMb,
            bool applyFilters, bool active, bool passive)
        {
            pulseManager.CombineAndSavePulsesBatch(filePrefix, countTimeSec, maxFileSizeMb, applyFilters, active,
                passive);
        }

        public List<AppliedPulseFilters> GetFilterOrder()
        {
            return pulseManager.GetApplicableFilters();
        }

        public bool EnableBatchCombinePulses()
        {
            return pulseManager.GuiEnableBatchPulseCombine();
        }
    }
}
