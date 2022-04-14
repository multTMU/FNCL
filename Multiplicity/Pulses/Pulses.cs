using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalHelpersDefaults;
using Multiplicity.PulseFilters;

namespace Multiplicity
{
    /// <summary>
    /// Interface Hierarchy for Pulse streams
    /// </summary>
    public interface IPulse
    {
        double GetTime();
        int GetDetector();
        Particle GetParticle();
        void ShiftTime(double timeOffset);
    }

    public interface IPulseHeight : IPulse
    {
        double GetPulseHeightKeVee();
    }

    public interface IPulseWaveform : IPulseHeight
    {
        double GetAdcIntegral();
        List<int> GetAdcWaveform();
        double GetAdcPulseMin();
        double GetAdcPulseMax();
        double GetTimeDurationOfWaveform();
        double IntegratePulseByIndex(int startIndex, int endIndex);
        double IntegratePulseByTimes(double startTime, double endTime);
        double DurationOfPulsePeak(double flatTopRelativeTolerance);
        int GetAdcPulseTimeOffSetFromPeak(int TimeOffset);
        int GetAdCPulseTimeFromPeakHeightFraction(double PulseHeightFraction);
        double GetTimeOfIndex(int index);
        void SetParticle(Particle particle);
    }

    public enum PulseFileType
    {
        Undefined,
        PoliMi,
        FnclFlat,
        FnclBinary,
        NGamSnl
    }

    public enum Interaction
    {
        ElasticScatter = -99,
        ComptonScatter = 1
    }

    public class Pulse : IPulse
    {
        private readonly int Cell;
        private double TimeNanoSec;
        protected Particle PulseParticleType;

        public Pulse(int cell, double time, Particle particle)
        {
            Cell = cell;
            TimeNanoSec = Math.Abs(time);
            if (particle == Particle.NeutronAndPhoton)
            {
                throw new Exception("Cannot set particle pulse as neutron and photon ");
            }

            PulseParticleType = particle;
        }

        public double GetTime()
        {
            return TimeNanoSec;
        }

        public int GetDetector()
        {
            return Cell;
        }

        public Particle GetParticle()
        {
            return PulseParticleType;
        }

        public void ShiftTime(double timeOffset)
        {
            TimeNanoSec += timeOffset;
        }

        public void SetPulseTime(double pulseTime)
        {
            TimeNanoSec = pulseTime;
        }
    }

    public class FnclPulse : Pulse, IPulseWaveform
    {
        public const int SampleTimeNanoSec = 2;
        public const int NSAMPLES = 127;
        public readonly int BaseLine;
        private readonly List<int> WaveFormBaselineSubtracted;
        private double PulseMax;
        private double PulseMin;
        private double ADCintegral;

        private int maxPulseIndex;
        private int minPulseIndex;

        public FnclPulse(int cell, double time, int baseLine, List<int> waveForm,
            Particle particle = Particle.Undetermined)
            : base(cell, time, particle)
        {
            BaseLine = baseLine;
            WaveFormBaselineSubtracted = new List<int>();
            foreach (var w in waveForm)
            {
                int pulse = w - BaseLine;
                WaveFormBaselineSubtracted.Add(pulse);
            }

            SetAdcPulseMin();
            SetAdcPulseMax();
            SetAdcIntegral();
        }

        private void SetAdcIntegral()
        {
            ADCintegral = 0;
            foreach (var w in WaveFormBaselineSubtracted)
            {
                ADCintegral += FlipSign(w);
            }

            //  ADCintegral *= SampleTimeNanoSec;
        }

        private void SetAdcPulseMax()
        {
            int max = int.MinValue;
            int pIndex = 0;
            foreach (var w in WaveFormBaselineSubtracted)
            {
                int wFlip = FlipSign(w);
                if (wFlip > max)
                {
                    max = wFlip;
                    maxPulseIndex = pIndex;
                }

                pIndex++;
            }

            PulseMax = (double)max;
        }

        public double GetAdcIntegral()
        {
            return ADCintegral;
        }

        public List<int> GetAdcWaveform()
        {
            return WaveFormBaselineSubtracted;
        }

        public double GetAdcPulseMin()
        {
            return PulseMin;
        }

        private void SetAdcPulseMin()
        {
            int min = int.MaxValue;
            int pIndex = 0;
            foreach (var w in WaveFormBaselineSubtracted)
            {
                int wFlip = FlipSign(w);
                if (wFlip < min)
                {
                    min = wFlip;
                    minPulseIndex = pIndex;
                }

                pIndex++;
            }

            PulseMin = min;
        }

        private static int FlipSign(int w)
        {
            return -1 * w;
        }

        private static double FlipSign(double w)
        {
            return -1.0 * w;
        }

        public double GetAdcPulseMax()
        {
            return PulseMax;
        }

        public double GetTimeDurationOfWaveform()
        {
            return (double)(NSAMPLES * SampleTimeNanoSec);
        }

        public double IntegratePulseByIndex(int startIndex, int endIndex)
        {
            return integratePulseOverIndices(startIndex, endIndex);
        }

        private double integratePulseOverIndices(int startIndex, int endIndex)
        {
            int integral = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (ValidIndex(i))
                {
                    integral += WaveFormBaselineSubtracted[i] * SampleTimeNanoSec;
                }
            }

            return Math.Abs(integral);
        }

        public double IntegratePulseByTimes(double startTime, double endTime)
        {
            int startIndex = (int)(startTime / SampleTimeNanoSec);
            int endIndex = (int)(endTime / SampleTimeNanoSec);
            return integratePulseOverIndices(startIndex, endIndex);
        }

        private bool ValidIndex(int index)
        {
            return (index < NSAMPLES) && (index >= 0);
        }

        public int GetAdcPulseTimeOffSetFromPeak(int TimeOffset)
        {
            return maxPulseIndex * SampleTimeNanoSec + TimeOffset;
        }

        public int GetAdCPulseTimeFromPeakHeightFraction(double PulseHeightFraction)
        {
            double pulseHeight = Math.Abs((PulseHeightFraction / 100.0) * PulseMax);
            int pIndex = 0;
            int triggerIndex = 0;
            foreach (int w in WaveFormBaselineSubtracted)
            {
                if (Math.Abs(w) >= pulseHeight)
                {
                    triggerIndex = pIndex;
                    break;
                }

                pIndex++;
            }

            return triggerIndex * SampleTimeNanoSec;
        }

        public double GetPulseHeightKeVee()
        {
            return
                DetectorEnergyCalibration.GetEnergyKeVee(GetDetector(),
                    PulseMax); // may need to integrate pulse if we don't want to base it on height
        }

        public double GetTimeOfIndex(int index)
        {
            if (ValidIndex(index))
            {
                return index * SampleTimeNanoSec;
            }
            else
            {
                return double.NaN;
            }
        }

        public void SetParticle(Particle particle)
        {
            PulseParticleType = particle;
        }

        public double DurationOfPulsePeak(double flatTopRelativeTolerance)
        {
            double flatTopTolerance = (1.0 - flatTopRelativeTolerance) * PulseMax;
            int maxIntervals = 0;
            foreach (var w in WaveFormBaselineSubtracted)
            {
                if ((Math.Abs(FlipSign(w) - PulseMax)) < flatTopTolerance)
                {
                    maxIntervals++;
                }
            }

            return maxIntervals * SampleTimeNanoSec;
        }
    }

    public class PoliMiPulse : Pulse, IPulseHeight
    {
        public int History;
        private readonly double PulseHeightKeVee;
        public Interaction EventType;
        public int ParticleNumber;
        public int NumberOfInteractions;
        public double Weight;

        public PoliMiPulse(int cell, double time, Particle particle, int history, double pulseHeightMeVee,
            Interaction eventType,
            int particleNumber, int interactions, double weight) : base(cell, time, particle)
        {
            History = history;
            PulseHeightKeVee = pulseHeightMeVee * 1000.0;
            EventType = eventType;
            ParticleNumber = particleNumber;
            NumberOfInteractions = interactions;
            Weight = weight;
        }

        public double GetPulseHeightKeVee()
        {
            return PulseHeightKeVee;
        }
    }

    public class NGamSnlPulse : Pulse, IPulseHeight
    {
        private readonly int board;
        private double energyKeV;
        private string flag;
        
        public NGamSnlPulse(int Board, int Channel, double TimeTag, double EnergyKeV, string Flag) : base(Channel, TimeTag, Particle.Photon)
        {
            board = Board;
            energyKeV = EnergyKeV;
            flag = Flag;
        }

        public double GetPulseHeightKeVee()
        {
            return energyKeV;
        }

    }

    /// <summary>
    /// Workhorse for multiplicity counting, controls how gates-types (e.g. Shift Register) interact with the pulse stream
    /// </summary>
    /// <typeparam name="TPulse"></typeparam>
    public abstract class Pulses<TPulse> where TPulse : IPulse
    {
        public readonly string PulseFile;
        public int NumberOfPulses => pulses.Count;
        public int CurrentIndex { get; protected set; } = INVALID_INITIAL;
        public List<int> DetectorsInFile { get; }

        protected int endOfPulses = INVALID_INITIAL;
        protected List<TPulse> pulses;

        private const int INVALID_INITIAL = -1;
        public List<PulseFilters.IPulseFilter<TPulse>> SavedFilters { get; }
        private bool saveFilters;
        private LongFileReader bigFileReader;

        // first time we access we index++, helps me extract canwecontinue method for derived classes, that use more than pulse height
        private const int REFRESH_INDEX = -1;

        protected Pulses(string file, bool bigFile, PulseFileType fileType)
        {
            PulseFile = file;
            pulses = new List<TPulse>();
            DetectorsInFile = new List<int>();
            SavedFilters = new List<IPulseFilter<TPulse>>();
            saveFilters = false;
            if (fileType != PulseFileType.FnclBinary) // turn off big file reader for now
            {
                ifFileIsTooBig(bigFile, fileType);
            }
        }

        public void ResetSavedFilters()
        {
            SavedFilters.Clear();
        }

        public void SaveFilters()
        {
            saveFilters = true;
        }

        public void DoNotSaveFilters()
        {
            saveFilters = false;
        }

        public void RunExternalFilters(List<PulseFilters.IPulseFilter<TPulse>> filters)
        {
            foreach (PulseFilters.IPulseFilter<TPulse> f in filters)
            {
                RunFilter(f);
            }

            //RunFilter(new PulseFilters.TimeOrderFilter<TPulse>());
        }

        public void RunExternalFilter(PulseFilters.IPulseFilter<TPulse> filter)
        {
            RunFilter(filter);
        }

        public Pulses<TPulse> Clone()
        {
            Pulses<TPulse> clonePulse = (Pulses<TPulse>)this.MemberwiseClone();
            return clonePulse;
        }

        private void RunFilters()
        {
            foreach (PulseFilters.IPulseFilter<TPulse> f in GetFilters())
            {
                RunFilter(f);
            }

            RunFilter(new PulseFilters.TimeOrderFilter<TPulse>());
        }

        private void RunFilter(PulseFilters.IPulseFilter<TPulse> filter)
        {
            if (saveFilters)
            {
                SavedFilters.Add(filter);
            }

            pulses = filter.GetFilteredPulses(pulses);
        }

        protected virtual List<PulseFilters.IPulseFilter<TPulse>> GetFilters()
        {
            return new List<PulseFilters.IPulseFilter<TPulse>>();
        }

        private void ifFileIsTooBig(bool fileTooBigToReadAtOnce, PulseFileType fileType)
        {
            if (fileTooBigToReadAtOnce)
            {
                switch (fileType)
                {
                    case PulseFileType.PoliMi:
                        bigFileReader = new PoliMiLongFileReader(PulseFile);
                        break;
                    case PulseFileType.FnclFlat:
                        bigFileReader = new FnclFlatLongFileReader(PulseFile);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
                }
            }
        }

        public void AddPulses(List<TPulse> newPulses)
        {
            foreach (var p in newPulses)
            {
                AddPulse(p);
            }
        }

        public void AddPulse(TPulse pulse)
        {
            CheckForNewDetector(pulse.GetDetector());
            pulses.Add(pulse);
        }

        private void AddPulsesFromBigFileReader()
        {
            if (bigFileReader != null)
            {
                pulses.Clear();
                foreach (TPulse p in bigFileReader.GetNextBatchOfPulses())
                {
                    AddPulse(p);
                }
            }

            RunFilters();
        }

        public void StartReadingPulseTrain(int endOfPulseFlag)
        {
            CurrentIndex = REFRESH_INDEX;
            endOfPulses = endOfPulseFlag;
            RunFilters();
        }

        public double GetNextPulseTime()
        {
            while (CanContinueReadingPulseTrain())
            {
                return pulses[CurrentIndex].GetTime();
            }

            return (double)endOfPulses;
        }

        private bool CanContinueReadingPulseTrain()
        {
            CurrentIndex++;
            if (bigFileReader == null)
            {
                return CurrentIndex < NumberOfPulses;
            }
            else
            {
                if (CurrentIndex < NumberOfPulses)
                {
                    return true;
                }
                else
                {
                    CurrentIndex = REFRESH_INDEX;
                    AddPulsesFromBigFileReader();
                    return CanContinueReadingPulseTrain();
                }
            }
        }

        private void CheckForNewDetector(int detector)
        {
            if (IsNewDetector(detector))
            {
                DetectorsInFile.Add(detector);
            }
        }

        private bool IsNewDetector(int detector)
        {
            foreach (var d in DetectorsInFile)
            {
                if (d == detector)
                {
                    return false;
                }
            }

            return true;
        }

        public double GetPulseTimeByIndex(in int pulseIndex)
        {
            try
            {
                return pulses[pulseIndex].GetTime();
            }
            catch
            {
                return (double)endOfPulses;
            }
        }

        public void SetCurrentPulseIndex(int newPulseIndex)
        {
            try
            {
                CurrentIndex = newPulseIndex;
            }
            catch
            {
                CurrentIndex = NumberOfPulses;
            }
        }

        public double GetTimeOfFirstPulse()
        {
            try
            {
                return pulses.First().GetTime();
            }
            catch
            {
                return 0;
            }
        }

        public double GetTimeOfLastPulse()
        {
            try
            {
                return pulses.Last().GetTime();
            }
            catch
            {
                return 0;
            }
        }

        public double GetDuration()
        {
            try
            {
                return pulses.Last().GetTime() - pulses.First().GetTime();
            }
            catch
            {
                return 0;
            }
        }

        public List<TPulse> GetPulses()
        {
            return pulses;
        }

        public TPulse GetPulseByIndex(int pulseIndex)
        {
            return pulses[pulseIndex];
        }

        /// <summary>
        /// Allow big files, particularly from PoliMI to be read in as chunks
        /// </summary>
        private abstract class LongFileReader
        {
            private const int NPULSES = 100000;

            private readonly string pulseFile;
            private readonly StreamReader sr;

            protected LongFileReader(string file)
            {
                pulseFile = file;
            }

            public List<IPulse> GetNextBatchOfPulses(int nPulses = NPULSES)
            {
                List<IPulse> pulseBatch = new List<IPulse>(nPulses);
                int i = 0;
                bool readFile = !sr.EndOfStream;
                while (readFile)
                {
                    pulseBatch.Add(GetPulse(sr.ReadLine()));
                    i++;
                    if (i >= nPulses || sr.EndOfStream)
                    {
                        readFile = false;
                    }
                }

                return pulseBatch;
            }

            protected abstract IPulse GetPulse(string line);
        }

        private class FnclFlatLongFileReader : LongFileReader
        {
            public FnclFlatLongFileReader(string file) : base(file)
            {
            }

            protected override IPulse GetPulse(string line)
            {
                return PulsesHelper.FlatFileHelper.GetPulse(line);
            }
        }

        private class PoliMiLongFileReader : LongFileReader
        {
            public PoliMiLongFileReader(string file) : base(file)
            {
            }

            protected override IPulse GetPulse(string line)
            {
                return PulsesHelper.PoliMiFileHelper.GetPulse(line);
            }
        }
    }
}
