using System;
using System.Collections.Generic;
using GlobalHelpersDefaults;
using Multiplicity;

namespace GuiInterface
{
    public class UndefinedPulsesForGui : IGuiInterface
    {
        private const int GARBAGE = -1;

        public PsdSpecification GetPsdSpecs()
        {
            return new PsdSpecification(GARBAGE, GARBAGE, new List<PsdComponent>(), PsdTriggerTypes.NotDefined,
                GARBAGE, GARBAGE);
        }

        public void SetPsdParameters(DetectorKey detector, PsdSpecification psdSpecs)
        {
            // do nothing
        }

        public List<PsdComponent> GetPsdForPulses(DetectorKey detectorKey, int numberPulses)
        {
            return new List<PsdComponent>();
        }

        public void SavePsdFile(string file)
        {
            // Do nothing
        }

        public void LoadPsdFile(string file)
        {
            // Do nothing
        }

        public void SetMultiplicityGate(IMultiplicityViewer multViewer)
        {
            // Do nothing
        }

        public List<int> GetReals()
        {
            return new List<int>();
        }

        public List<int> GetRealsAndAccidentals()
        {
            return new List<int>();
        }

        public MultiplicityRates GetMultipletRates()
        {
            return new MultiplicityRates();
        }

        public PulseFileType GetPulseType()
        {
            return PulseFileType.Undefined;
        }

        public int GetNumberUnFilteredPulses()
        {
            return GARBAGE;
        }

        public void CombineAndSavePulsesBatch(string filePrefix, double countTimeSec, double maxFileSizeMb,
            bool applyFilters, bool active, bool passive)
        {
            // do nothing
        }

        public double GetCountTime()
        {
            return GARBAGE;
        }

        public bool GuiPoliMiSpecs()
        {
            return false;
        }

        public bool GuiPulseHeight()
        {
            return false;
        }

        public bool GuiPSD()
        {
            return false;
        }

        public List<int> GetPulseWaveForm(int pulseIndex)
        {
            return new List<int>();
        }

        public int GetNumberFilteredPulses()
        {
            return GARBAGE;
        }

        public double GetCountTimeFiltered()
        {
            return GARBAGE;
        }

        public int GetStartingDetectorIndex()
        {
            return GARBAGE;
        }

        public void SetPsd(PsdTriggerTypes psdTriggerType, double trigger, double fast,
            double slow, int nPulses)
        {
            // do nothing
        }

        public void ResetFilteredPulses()
        {
            //do nothing
        }

        public void FilterByDetectors(List<int> detectors)
        {
            //do nothing
        }

        public void FilterCrossTalk(int vetoGate, CrossTalk crossTalkDictionary)
        {
            //do nothing
        }

        public void FilterPulseHeightKeVee(double pulseHeightLLD, double pulseHeightULD)
        {
            // do nothing
        }

        public void FilterByAdcTrigger(int adcLLD, int adcULD)
        {
            //do nothing
        }

        public void FilterPulseHeightKeVee(double pulseHeightLLD)
        {
            //do nothing
        }

        public void TimeShiftDetectors(List<Multiplicity.PulseFilters.DetectorTimeShift> timeShiftsForPanel)
        {
            //do nothing
        }

        public List<PulsesHelper.PoliMiSimulations> GetPoliMiProblems()
        {
            return new List<PulsesHelper.PoliMiSimulations>();
        }

        public void SaveCurrentFilteredPulsesToFile(string saveFile)
        {
            // do nothing
        }

        public void SetPad(PulseAmplitudeType amplitudeType)
        {
            // do nothing
        }

        public List<double> GetPAD()
        {
            return new List<double>();
        }

        public bool GuiEnableParticleSelect()
        {
            return false;
        }

        public bool GuiEnablePileUpRejector()
        {
            return false;
        }

        public List<AppliedPulseFilters> GetApplicableFilters()
        {
            return new List<AppliedPulseFilters>();
        }

        public bool GuiEnableBatchPulseCombine()
        {
            return false;
        }

        public void UpdateFitParameters(List<double> fitParameters)
        {
            // do nothing
        }

        public List<double> CalculateDieAway(double minTime, double maxTime)
        {
            return new List<double>();
        }

        public List<Tuple<double, double>> GetDieAwayLine()
        {
            return new List<Tuple<double, double>>();
        }

        public List<Tuple<double, double>> GetDieAwayFitLine()
        {
            return new List<Tuple<double, double>>();
        }

        public void CalculateDieAwayFit(CurveFitType fitType, List<Tuple<double, double>> dieAwayHistogram)
        {
            // do nothing
        }

        public void FilterByParticle(Particle particle)
        {
            // do nothing
        }

        public double[] GetDieAwayGatesPlot()
        {
            return new double[0];
        }

        public double[] GetDieAwayFitGatesPlot()
        {
            return new double[0];
        }

        public void CalculateDieAwayFit(CurveFitType fitType)
        {
            // do nothing
        }

        public List<double> GetDieAwayFitParameters()
        {
            return new List<double>();
        }

        public double GetDieAwayGoodnessOfFit()
        {
            return Double.NaN;
        }

        public void UpdateSelectedDetector(DetectorType selectedDetectorType)
        {
            // do nothing
        }

        public List<double> GetPulseTimes()
        {
            return new List<double>();
        }

        public double GetFirstPulseTime()
        {
            return GARBAGE;
        }

        public double GetLastPulseTime()
        {
            return GARBAGE;
        }

        public void SaveCurrentFilteredPulses(List<string> pulseFiles, string saveFile, bool applyFilters,
            bool applyEcal)
        {
            // do nothing
        }

        public void FilterTimeWindow(double startTime, double endTime)
        {
            // do nothing
        }

        public DateTime GetFileCreationTime()
        {
            return DateTime.MaxValue;
        }

        public int GetFileSize()
        {
            return GARBAGE;
        }

        public void SetPsdParameters(PsdTriggerTypes psdTriggerType, double trigger,
            int fast, int slow, int nPulses)
        {
            // do nothing
        }

        public void CorrelatedPulseSelector(int maxTimeBetweenPulses)
        {
            // do nothing
        }

        public bool GuiEnableCorrelatedPulseTime()
        {
            return false;
        }

        public void PulseShapeDiscrimination(Particle filterParticle, string psdFile = "")
        {
            // do nothing
        }

        public string GetPsdFile()
        {
            return string.Empty;
        }

        public void SavePsdToFile(string saveFile, PsdSpecification psdSpecification)
        {
            // do nothing
        }

        public Dictionary<int, double> CalculateDrf(double drfSourceRate)
        {
            return new Dictionary<int, double>();
        }

        public void LoadPsdFromFnclSettings()
        {
            // do nothing
        }

        public PsdSpecification GetPsdSpecs(DetectorKey detectorKey)
        {
            return new PsdSpecification();
        }

        public int GetNumberFilteredPulses(DetectorKey detectorKey)
        {
            return 0;
        }

        public PsdWaveformGui GetPsdPulseWaveform(int pulseIndex, PsdSpecification psdSpecification,
            DetectorKey detector)
        {
            return new PsdWaveformGui();
        }

        public void RejectPileUp(double scalar, double interval)
        {
            // do nothing
        }

        public bool GetIsPileUp(int pulseIndex, double scalar, double interval)
        {
            return false;
        }

        public void FilterFlatTop(double duration, double peakMaxTolerancePercent)
        {
            // do nothing
        }

        public void ResetSavedFilters()
        {
            throw new NotImplementedException();
        }
    }
}
