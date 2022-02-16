using System;
using System.Collections.Generic;
using System.IO;
using GlobalHelpersDefaults;
using Multiplicity;
using Multiplicity.PulseFilters;

namespace GuiInterface
{
    public interface IDetectorResponse
    {
        double GetSourceRate();
        void SetDrf(Dictionary<int, double> calculatedDrf);
    }

    public interface IDieAwayFitGui
    {
        void UpdateFitParameters(List<double> fitParameters);
    }

    public interface IDieAwayCalculations
    {
        List<double> CalculateDieAway(double minTime, double maxTime);
        List<Tuple<double, double>> GetDieAwayLine();
        List<Tuple<double, double>> GetDieAwayFitLine();
        void CalculateDieAwayFit(CurveFitType fitType, List<Tuple<double, double>> dieAwayHistogram);
        List<double> GetDieAwayFitParameters();
        double GetDieAwayGoodnessOfFit();
    }

    public interface IMultiplicityViewer
    {
        int GetGate();
        int GetPreDelay();
        int GetLongDelay();
        MultiplicityGateType GetGateType();
    }

    public struct FilterParameters
    {
        public double StartTime;
        public double EndTime;
        public List<int> Detectors;
        public int VetoGate;
        public CrossTalk CrossTalk;
        public double PulseHeightLLD;
        public double PulseHeightULD;
        public int AdcLLD;
        public List<Multiplicity.PulseFilters.DetectorTimeShift> TimeShiftsForPanel;
        public Particle ParticleType;
        public int AdcULD;
    }

    public interface IPulseShapeDiscrimination
    {
        PsdSpecification GetPsdSpecs(DetectorKey detectorKey);
        void SetPsdParameters(DetectorKey detectorKey, PsdSpecification psd);
        List<PsdComponent> GetPsdForPulses(DetectorKey detectorKey, int numberPulses);
        void LoadPsdFile(string file);
        void PulseShapeDiscrimination(Particle filterParticle, string psdFile = "");
        string GetPsdFile();
        void LoadPsdFromFnclSettings();
        void SavePsdToFile(string saveFile, PsdSpecification psdSpecification);
    }

    public interface IEnableFilters
    {
        bool GuiPSD();
        bool GuiPulseHeight();
        bool GuiEnableCorrelatedPulseTime();
        bool GuiEnableParticleSelect();
        bool GuiEnablePileUpRejector();
        List<AppliedPulseFilters> GetApplicableFilters();
        bool GuiEnableBatchPulseCombine();
    }

    public interface IPulseFilters : IPulseShapeDiscrimination, IEnableFilters
    {
        void ResetSavedFilters();
        void FilterTimeWindow(double startTime, double endTime);
        void ResetFilteredPulses();
        void FilterByDetectors(List<int> detectors);
        void FilterCrossTalk(int vetoGate, CrossTalk crossTalk);
        void FilterPulseHeightKeVee(double pulseHeightLLD, double pulseHeightULD);
        void FilterByAdcTrigger(int adcLLD, int adcULD);
        void TimeShiftDetectors(List<Multiplicity.PulseFilters.DetectorTimeShift> timeShiftsForPanel);
        void FilterByParticle(Particle particle);
        void CorrelatedPulseSelector(int maxTimeBetweenPulses);
        double GetCountTimeFiltered();
        void SetPad(PulseAmplitudeType amplitudeType);
        void FilterFlatTop(double duration, double peakMaxTolerancePercent);
    }

    public interface IPulsesGui
    {
        List<double> GetPAD();
        int GetStartingDetectorIndex();
        PulseFileType GetPulseType();
        double GetCountTime();
        List<double> GetPulseTimes();
        double GetFirstPulseTime();
        double GetLastPulseTime();
        void SaveCurrentFilteredPulsesToFile(string saveFile);
        int GetNumberFilteredPulses(DetectorKey detectorKey);
        int GetNumberFilteredPulses();
        int GetNumberUnFilteredPulses();

        void CombineAndSavePulsesBatch(string filePrefix, double countTimeSec, double maxFileSizeMb, bool applyFilters,
            bool active, bool passive);
    }

    public interface IMultiplicityGui
    {
        void SetMultiplicityGate(IMultiplicityViewer multViewer);
        List<int> GetReals();
        List<int> GetRealsAndAccidentals();
        MultiplicityRates GetMultipletRates();
    }

    // TODO: Break up into smaller interfaces
    public interface IGuiInterface : IPulseFilters, IDieAwayFitGui, IPulsesGui, IMultiplicityGui, IDieAwayCalculations
    {
        bool GuiPoliMiSpecs();
        List<int> GetPulseWaveForm(int pulseIndex);
        List<PulsesHelper.PoliMiSimulations> GetPoliMiProblems();
        void UpdateSelectedDetector(DetectorType selectedDetectorType);

        DateTime GetFileCreationTime();
        int GetFileSize();
        Dictionary<int, double> CalculateDrf(double drfSourceRate);

        PsdWaveformGui GetPsdPulseWaveform(int pulseIndex, PsdSpecification psdSpecification, DetectorKey detector);
        void RejectPileUp(double scalar, double interval);

        bool GetIsPileUp(int pulseIndex, double scalar, double interval);
    }

    public abstract class BaseMultiplicityGuiInterface<TPulse> : IGuiInterface where TPulse : IPulse
    {
        protected int gateWidth;
        protected int preDelay;
        protected int longDelay;
        protected string pulseFile;
        protected IMultiplicityGate multGate;
        protected Pulses<TPulse> pulses;
        protected Pulses<TPulse> filteredPulses;
        protected FilterParameters filterParameters;
        protected PulseAmplitudeType amplitudeType;

        private string psdFile;
        private readonly FileInfo fileInfo;
        private DieAwayTime<TPulse> dieAway;

        private DetectorType currentDetector;
        private const double MIN_LOG_THRESHOLD = 1e-5;

        protected BaseMultiplicityGuiInterface(string PulseFile)
        {
            pulseFile = PulseFile;
            fileInfo = new FileInfo(pulseFile);
            pulses = GetPulsesFromFile();
            dieAway = new DieAwayTime<TPulse>();
            currentDetector = DetectorType.None;
            ClonePulses();
        }

        protected void ClonePulses()
        {
            filteredPulses = pulses.Clone();
        }

        protected abstract Pulses<TPulse> GetPulsesFromFile();

        public void SetMultiplicityGate(int GateWidth, int PreDelay, int LongDelay)
        {
            gateWidth = GateWidth;
            preDelay = PreDelay;
            longDelay = LongDelay;

            multGate = MultiplicityGatesHelper.GetMultiplicityGate(filteredPulses, preDelay, longDelay);
        }

        private void SetMultiplicityGate(MultiplicityGateType GateType, int GateWidth, int PreDelay, int LongDelay)
        {
            gateWidth = GateWidth;
            preDelay = PreDelay;
            longDelay = LongDelay;

            multGate = MultiplicityGatesHelper.GetMultiplicityGate(GateType, filteredPulses, preDelay, longDelay);
        }

        public void SetMultiplicityGate(IMultiplicityViewer multViewer)
        {
            SetMultiplicityGate(multViewer.GetGateType(), multViewer.GetGate(), multViewer.GetPreDelay(),
                multViewer.GetLongDelay());
        }

        public List<int> GetReals()
        {
            MultiplicityDistribution reals = multGate.GetReals();
            return reals.NonNormalizedDistribution;
        }

        public List<int> GetRealsAndAccidentals()
        {
            var realsAndAs = multGate.GetRealsAccidentals();
            return realsAndAs.NonNormalizedDistribution;
        }

        public MultiplicityRates GetMultipletRates()
        {
            return MultiplicityRatesHelper<TPulse>.GetMultiplicityRates(multGate, gateWidth);
        }

        public abstract PulseFileType GetPulseType();

        public int GetNumberUnFilteredPulses()
        {
            return pulses.NumberOfPulses;
        }

        public virtual void CombineAndSavePulsesBatch(string filePrefix, double countTimeSec, double maxFileSizeMb,
            bool applyFilters,
            bool active, bool passive)
        {
            // do nothing
        }


        //public void CombineAndSavePulsesBatch(string filePrefix, double countTimeSec, double maxFileSizeMb,
        //    bool applyFilters, bool active, bool passive)
        //{
        //  List<IPulseFilter<TPulse>> filters = new List<IPulseFilter<TPulse>>();
        //  if (applyFilters)
        //  {

        //  }

        //  GuiInterface.CombineBinaryPulsesToSave combine = new CombineBinaryPulsesToSave(pulseFile, filePrefix, countTimeSec,maxFileSizeMb, filters, active, passive);
        //}

        public double GetCountTime()
        {
            return pulses.GetDuration();
        }

        public abstract bool GuiPoliMiSpecs();
        public abstract bool GuiPulseHeight();
        public abstract bool GuiPSD();

        public virtual List<int> GetPulseWaveForm(int pulseIndex)
        {
            return new List<int>();
        }

        public int GetNumberFilteredPulses()
        {
            return filteredPulses.NumberOfPulses;
        }

        public double GetCountTimeFiltered()
        {
            return filteredPulses.GetDuration();
        }

        public abstract int GetStartingDetectorIndex();

        public void ResetFilteredPulses()
        {
            filteredPulses = pulses.Clone();
        }

        public void FilterByDetectors(List<int> detectors)
        {
            filteredPulses.RunExternalFilter(new Multiplicity.PulseFilters.FilterByDetector<TPulse>(detectors));
            filterParameters.Detectors = detectors;
        }

        public void FilterCrossTalk(int vetoGate, CrossTalk crossTalk)
        {
            crossTalk.MakeDictionaries();
            filterParameters.CrossTalk = crossTalk;
            filterParameters.VetoGate = vetoGate;
            filteredPulses.RunExternalFilter(
                new FilterCrossTalk<string, TPulse>(vetoGate, crossTalk.GetCrossDictionary()));
            filteredPulses.RunExternalFilter(
                new FilterMultipleEventsInOneDetector<TPulse>(vetoGate, crossTalk.GetSelfTalk()));
        }

        public virtual void FilterPulseHeightKeVee(double pulseHeightLLD, double pulseHeightULD)
        {
            filterParameters.PulseHeightLLD = pulseHeightLLD;
            filterParameters.PulseHeightULD = pulseHeightULD;
        }

        public virtual void FilterByAdcTrigger(int adcLLD, int adcULD)
        {
            filterParameters.AdcLLD = adcLLD;
            filterParameters.AdcULD = adcULD;
        }

        public void TimeShiftDetectors(List<Multiplicity.PulseFilters.DetectorTimeShift> timeShiftsForPanel)
        {
            filteredPulses.RunExternalFilter(
                new Multiplicity.PulseFilters.TimeShiftDetectors<TPulse>(timeShiftsForPanel));
        }

        public void ResetSavedFilters()
        {
            filteredPulses.ResetSavedFilters();
            filteredPulses.SaveFilters();
        }

        public void FilterTimeWindow(double startTime, double endTime)
        {
            filteredPulses.RunExternalFilter(
                new Multiplicity.PulseFilters.SelectTimeWindow<TPulse>(startTime, endTime));
            filterParameters.StartTime = startTime;
            filterParameters.EndTime = endTime;
        }

        public void CorrelatedPulseSelector(int maxTimeBetweenPulses)
        {
            filteredPulses.RunExternalFilter(new Multiplicity.PulseFilters.TimeGapFilter<TPulse>(maxTimeBetweenPulses));
        }

        public virtual List<PulsesHelper.PoliMiSimulations> GetPoliMiProblems()
        {
            return new List<PulsesHelper.PoliMiSimulations>();
        }

        public virtual void SaveCurrentFilteredPulsesToFile(string saveFile)
        {
            WriteFlatFile.WritePulseStreamToFile(saveFile, filteredPulses);
        }

        public void SetPad(PulseAmplitudeType AmplitudeType)
        {
            amplitudeType = AmplitudeType;
        }

        public virtual List<double> GetPAD()
        {
            return new List<double>();
        }

        public virtual bool GuiEnableParticleSelect()
        {
            return false;
        }

        public virtual bool GuiEnablePileUpRejector()
        {
            return false;
        }

        public void UpdateFitParameters(List<double> fitParameters)
        {
            dieAway.UpdateFitParameters(fitParameters);
        }

        public List<double> CalculateDieAway(double minTime, double maxTime)
        {
            return dieAway.CalculateIntervals(filteredPulses, minTime, maxTime);
        }

        public virtual void FilterByParticle(Particle particle)
        {
            filterParameters.ParticleType = particle;
        }

        public List<Tuple<double, double>> GetDieAwayFitLine()
        {
            return dieAway.GetFitLine();
        }

        public void CalculateDieAwayFit(CurveFitType fitType, List<Tuple<double, double>> dieAwayHistogram)
        {
            dieAway.CalculateDieAwayFit(fitType, dieAwayHistogram);
        }

        public List<double> GetDieAwayFitParameters()
        {
            return dieAway.GetFitParameters();
        }

        public double GetDieAwayGoodnessOfFit()
        {
            return dieAway.GetGoodnessOfFit();
        }

        public void UpdateSelectedDetector(DetectorType selectedDetectorType)
        {
            currentDetector = selectedDetectorType;
        }

        public List<double> GetPulseTimes()
        {
            List<double> pulseTimes = new List<double>();
            foreach (var p in filteredPulses.GetPulses())
            {
                pulseTimes.Add(p.GetTime());
            }

            return pulseTimes;
        }

        public double GetFirstPulseTime()
        {
            return filteredPulses.GetTimeOfFirstPulse();
        }

        public double GetLastPulseTime()
        {
            return filteredPulses.GetTimeOfLastPulse();
        }

        public virtual DateTime GetFileCreationTime()
        {
            return fileInfo.CreationTime;
        }

        public virtual int GetFileSize()
        {
            return (int)(fileInfo.Length / 1000000);
        }


        public virtual void SetPsdParameters(DetectorKey detectorKey, PsdSpecification psd)
        {
            // do nothing, as not all pulses have waveforms
        }

        public PsdSpecification GetPsd(DetectorKey detectorKey)
        {
            return PulseShapeDiscriminationCalibration.GetCalibrationByDetector(detectorKey);
        }

        public bool GuiEnableCorrelatedPulseTime()
        {
            return true;
        }

        public virtual void PulseShapeDiscrimination(Particle filterParticle, string psdFile = "")
        {
            // do nothing;
        }

        public string GetPsdFile()
        {
            return psdFile;
        }

        public void SavePsdToFile(string saveFile, PsdSpecification psd)
        {
            psdFile = saveFile;
            PulseShapeDiscriminationCalibration.SaveCurrentPsdCalibration(saveFile);
        }

        public Dictionary<int, double> CalculateDrf(double drfSourceRate)
        {
            return DetectorResponses.GetDetectorResponses(filteredPulses, drfSourceRate);
        }

        public virtual void LoadPsdFromFnclSettings()
        {
            // do nothing
        }

        public virtual List<PsdComponent> GetPsdForPulses(DetectorKey detectorKey, int numberPulses)
        {
            return new List<PsdComponent>();
        }

        public void LoadPsdFile(string file)
        {
            psdFile = file;
            PulseShapeDiscriminationCalibration.LoadPsdCalibrationFromFile(file);
        }

        public List<Tuple<double, double>> GetDieAwayLine()
        {
            return dieAway.GetFitLine();
        }

        public virtual PsdSpecification GetPsdSpecs(DetectorKey detectorKey)
        {
            return new PsdSpecification();
        }

        public int GetNumberFilteredPulses(DetectorKey detectorKey)
        {
            return GetPulsesForDetector(detectorKey).NumberOfPulses;
        }

        protected Pulses<TPulse> GetPulsesForDetector(DetectorKey detectorKey)
        {
            Pulses<TPulse> detectorPulses = filteredPulses.Clone();
            detectorPulses.RunExternalFilter(
                new FilterByDetector<TPulse>(
                    DetectorDictionariesHelper.GetDetectorIndexByKey(detectorKey, currentDetector)));
            return detectorPulses;
        }

        public virtual PsdWaveformGui GetPsdPulseWaveform(int pulseIndex, PsdSpecification psdSpecification,
            DetectorKey detector)
        {
            return new PsdWaveformGui();
        }

        public virtual void RejectPileUp(double scalar, double interval)
        {
            // do nothing
        }

        public virtual bool GetIsPileUp(int pulseIndex, double scalar, double interval)
        {
            return false;
        }

        public abstract List<AppliedPulseFilters> GetApplicableFilters();

        public virtual void FilterFlatTop(double duration, double peakMaxTolerancePercent)
        {
            // do nothing
        }

        public virtual bool GuiEnableBatchPulseCombine()
        {
            return false;
        }

        private static class WriteFlatFile
        {
            private const string SEP = " ";

            public static void WritePulseStreamToFile(string saveFile, Pulses<TPulse> pulses)
            {
                using (StreamWriter sw = new StreamWriter(saveFile))
                {
                    foreach (var p in pulses.GetPulses())
                    {
                        sw.WriteLine(p.GetDetector() + SEP + p.GetTime());
                    }
                }
            }
        }
    }
}
