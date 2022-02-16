using GeometrySampling;
using System;
using System.Collections.Generic;
using GlobalHelpersDefaults;

namespace Multiplicity.PulseFilters
{
    public interface IPulseFilter<TPulse> where TPulse : IPulse
    {
        List<TPulse> GetFilteredPulses(List<TPulse> unfilteredPulses);
    }

    public abstract class PulseFilter<TPulse> : IPulseFilter<TPulse> where TPulse : IPulse
    {
        protected List<TPulse> filteredPulses;

        public List<TPulse> GetFilteredPulses(List<TPulse> unfilteredPulses)
        {
            filteredPulses = new List<TPulse>();
            filterPulses(unfilteredPulses);
            return filteredPulses;
        }

        protected abstract void filterPulses(List<TPulse> unfilteredPulses);
    }

    public class FilterByDetector<TPulse> : PulseFilter<TPulse> where TPulse : IPulse
    {
        private readonly List<int> detectors;

        public FilterByDetector(List<int> detectorsToKeep)
        {
            detectors = detectorsToKeep;
        }

        public FilterByDetector(int detectorToKeep)
        {
            detectors = new List<int>() {detectorToKeep};
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (detectors.Contains(p.GetDetector()))
                {
                    filteredPulses.Add(p);
                }
            }
        }
    }

    public abstract class TimeFilterDetectorEvents<TKey, TValue, TPulse> : PulseFilter<TPulse> where TPulse : IPulse
    {
        protected readonly double vetoGate;
        protected Dictionary<TKey, TimeBufferedQueue<TPulse>> detectorPulsesBuffer;
        protected Dictionary<TKey, TValue> vetoDetectors;

        protected TimeFilterDetectorEvents(double VetoGate, Dictionary<TKey, TValue> VetoDetectors)
        {
            vetoGate = VetoGate;
            vetoDetectors = VetoDetectors;
            InitializeTimeVetoDictionaryQueues();
        }

        private void InitializeTimeVetoDictionaryQueues()
        {
            detectorPulsesBuffer = new Dictionary<TKey, TimeBufferedQueue<TPulse>>();
            foreach (KeyValuePair<TKey, TValue> det in vetoDetectors)
            {
                detectorPulsesBuffer.Add(det.Key, new TimeBufferedQueue<TPulse>(vetoGate));
            }
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            if (vetoDetectors.Count > 0)
            {
                ApplyTimeBufferToGroups(unfilteredPulses);
                RecombineTimeBufferedGroups();
            }
            else
            {
                filteredPulses = unfilteredPulses;
            }

            EnsureRecombinationIsTimeSorted();
        }

        private void EnsureRecombinationIsTimeSorted()
        {
            IPulseFilter<TPulse> timeFileFilter = new TimeOrderFilter<TPulse>();
            filteredPulses = timeFileFilter.GetFilteredPulses(filteredPulses);
        }

        private void RecombineTimeBufferedGroups()
        {
            foreach (KeyValuePair<TKey, TimeBufferedQueue<TPulse>> keyPulse in detectorPulsesBuffer)
            {
                filteredPulses.AddRange(keyPulse.Value);
            }
        }

        private void ApplyTimeBufferToGroups(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                var key = GetKey(p.GetDetector());
                if (key == null)
                {
                    filteredPulses.Add(p);
                }
                else
                {
                    if (detectorPulsesBuffer.ContainsKey(key))
                    {
                        detectorPulsesBuffer[key].Enqueue(p);
                    }
                    else
                    {
                        // key is not found, we shouldn't filter on it, so add it into the stream, we time sort at the end
                        filteredPulses.Add(p);
                    }
                }
            }
        }

        protected abstract TKey GetKey(in int detector);
    }

    public class FilterMultipleEventsInOneDetector<TPulse> : TimeFilterDetectorEvents<int, int, TPulse>
        where TPulse : IPulse
    {
        public FilterMultipleEventsInOneDetector(double VetoGate, List<int> detectors) : base(VetoGate,
            getOneToOneDictionary(detectors))
        {
        }

        private static Dictionary<int, int> getOneToOneDictionary(List<int> single)
        {
            Dictionary<int, int> oneToOne = new Dictionary<int, int>();
            foreach (int v in single)
            {
                oneToOne.Add(v, v);
            }

            return oneToOne;
        }

        protected override int GetKey(in int detector)
        {
            return detector;
        }
    }

    public class FilterCrossTalk<TKey, TPulse> : TimeFilterDetectorEvents<TKey, List<int>, TPulse>
        where TPulse : IPulse
    {
        public FilterCrossTalk(double VetoGate, Dictionary<TKey, List<int>> VetoDetectors) : base(VetoGate,
            VetoDetectors)
        {
        }

        protected override TKey GetKey(in int detector)
        {
#if DEBUG
            KeyValuePair<TKey, List<int>> debugKey;
#endif
            foreach (KeyValuePair<TKey, List<int>> k in vetoDetectors)
            {
#if DEBUG
                debugKey = k;
#endif

                foreach (int d in k.Value)
                {
                    if (detector == d)
                    {
                        return k.Key;
                    }
                }
            }

            return default;
            //throw new Exception("Detector: " + detector.ToString() + ", encountered does not belong to a key");
        }
    }

    public class ParticleFilter<TPulse> : PulseFilter<TPulse> where TPulse : IPulse
    {
        private readonly Particle particle;

        public ParticleFilter(Particle particleToSelect)
        {
            particle = particleToSelect;
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (p.GetParticle() == particle)
                {
                    filteredPulses.Add(p);
                }
            }
        }
    }

    public class TimeOrderFilter<TPulse> : PulseFilter<TPulse> where TPulse : IPulse
    {
        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            unfilteredPulses.Sort((x, y) => x.GetTime().CompareTo(y.GetTime()));
            filteredPulses = unfilteredPulses;
        }
    }

    public class TimeGapFilter<TPulse> : PulseFilter<TPulse> where TPulse : IPulse
    {
        private readonly double maxTimeGap;

        public TimeGapFilter(double MaxTimeGapBetweenPulses)
        {
            maxTimeGap = MaxTimeGapBetweenPulses;
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            for (int i = 0; i < unfilteredPulses.Count; i++)
            {
                if (pulsePassesMaxTimeBetweenPulses(i, unfilteredPulses))
                {
                    filteredPulses.Add(unfilteredPulses[i]);
                }
            }
        }

        private bool pulsePassesMaxTimeBetweenPulses(int pulseIndex, List<TPulse> unfilteredPulses)
        {
            if (pulseIndex == 0)
            {
                return pulsesCloserThanMaxTimeGap(unfilteredPulses[0].GetTime(), unfilteredPulses[1].GetTime());
            }
            else if (pulseIndex == unfilteredPulses.Count - 1)
            {
                return pulsesCloserThanMaxTimeGap(unfilteredPulses[pulseIndex - 1].GetTime(),
                    unfilteredPulses[pulseIndex].GetTime());
            }
            else
            {
                return pulsesCloserThanMaxTimeGap(unfilteredPulses[pulseIndex].GetTime(),
                           unfilteredPulses[pulseIndex + 1].GetTime()) ||
                       pulsesCloserThanMaxTimeGap(unfilteredPulses[pulseIndex - 1].GetTime(),
                           unfilteredPulses[pulseIndex].GetTime());
            }
        }

        private bool pulsesCloserThanMaxTimeGap(double firstPulse, double nextPulse)
        {
            return (nextPulse - firstPulse) <= maxTimeGap;
        }
    }

    public class TimeCutFilter<TPulse> : PulseFilter<TPulse> where TPulse : IPulse
    {
        private readonly List<Bounds<double>> timeBounds;

        public TimeCutFilter(List<Bounds<double>> TimeBounds)
        {
            timeBounds = TimeBounds;
        }

        public TimeCutFilter(Bounds<double> TimeBound)
        {
            timeBounds = new List<Bounds<double>>() {TimeBound};
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (pulseIsBounded(p.GetTime()))
                {
                    filteredPulses.Add(p);
                }
            }
        }

        private bool pulseIsBounded(double pulseTime)
        {
            foreach (var b in timeBounds)
            {
                if (b.BoundsValue(pulseTime))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public struct DetectorTimeShift
    {
        public int Detector;
        public int TimeShift;

        public DetectorTimeShift(int detector, int timeShiftNanoSec)
        {
            Detector = detector;
            TimeShift = timeShiftNanoSec;
        }
    }

    public class TimeShiftDetectors<TPulse> : PulseFilter<TPulse> where TPulse : IPulse
    {
        private Dictionary<int, double> shiftDic;

        public TimeShiftDetectors(List<DetectorTimeShift> detectorTimeShifts)
        {
            MakeDictionary(detectorTimeShifts);
        }

        private void MakeDictionary(List<DetectorTimeShift> detectorTimeShifts)
        {
            shiftDic = new Dictionary<int, double>();
            foreach (var s in detectorTimeShifts)
            {
                shiftDic.Add(s.Detector, s.TimeShift);
            }
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (shiftDic.ContainsKey(p.GetDetector()))
                {
                    p.ShiftTime(shiftDic[p.GetDetector()]);
                }

                filteredPulses.Add(p);
            }

            ReorderByTime();
        }

        private void ReorderByTime()
        {
            TimeOrderFilter<TPulse> timeFilter = new TimeOrderFilter<TPulse>();
            filteredPulses = timeFilter.GetFilteredPulses(filteredPulses);
        }
    }

    public class SelectTimeWindow<TPulse> : PulseFilter<TPulse> where TPulse : IPulse
    {
        private readonly double startTime;
        private readonly double endTime;

        public SelectTimeWindow(double StartTime, double EndTime)
        {
            startTime = StartTime;
            endTime = EndTime;
        }

        protected override void filterPulses(List<TPulse> unfilteredPulses)
        {
            foreach (var p in unfilteredPulses)
            {
                if (PulseTimeBound(p.GetTime()))
                {
                    filteredPulses.Add(p);
                }
            }
        }

        private bool PulseTimeBound(double time)
        {
            return time >= startTime && time <= endTime;
        }
    }
}
