using System;
using System.Collections.Generic;
using System.Linq;

namespace Multiplicity
{
    public struct GateSettings
    {
        public double GateWidth;
        public double PreDelay;
        public double LongDelay;

        public GateSettings(double gateWidth, double preDelay, double longDelay)
        {
            GateWidth = gateWidth;
            PreDelay = preDelay;
            LongDelay = longDelay;
        }

        public GateSettings(int gateWidth)
        {
            GateWidth = gateWidth;
            PreDelay = 0;
            LongDelay = 0;
        }
    }


    public class DieAwayTime<TPulse> where TPulse : IPulse
    {
        private CurveFitter fitter;
        private double MinTime;
        private double MaxTime;

        private double actualMinTime;
        private double actualMaxTime;

        public DieAwayTime()
        {
            MinTime = 0;
            MaxTime = 0;
            actualMinTime = 0;
            actualMaxTime = 0;
        }

        public List<double> CalculateIntervals(Pulses<TPulse> Pulses, double minTime, double maxTime)
        {
            MinTime = minTime;
            MaxTime = maxTime;
            return TimeDistributions<TPulse>.GetIntervalDistribution(Pulses, minTime, maxTime);
        }

        public void CalculateDieAwayFit(CurveFitType FitType, List<Tuple<double, double>> intervalHistogram)
        {
            try
            {
                actualMinTime = intervalHistogram.First().Item1;
                actualMaxTime = intervalHistogram.Last().Item1;
            }
            catch
            {
                actualMinTime = 0;
                actualMaxTime = 0;
            }

            fitter = CurveFitHelper.GetFit(FitType, intervalHistogram);
        }

        public List<double> GetFitParameters()
        {
            return fitter.GetFitParameters();
        }

        public void UpdateFitParameters(List<double> fitParameters)
        {
            fitter.SetFitParameters(fitParameters);
        }

        public double GetGoodnessOfFit()
        {
            return fitter.GetRSquared();
        }

        public List<Tuple<double, double>> GetFitLine()
        {
            double minTime = ((int)MinTime == TimeDistributions<TPulse>.NO_TIME_CONSTRAINT) ? actualMinTime : MinTime;
            double maxTime = ((int)MaxTime == TimeDistributions<TPulse>.NO_TIME_CONSTRAINT) ? actualMaxTime : MaxTime;
            return fitter.GetLine(minTime, maxTime);
        }
    }
}
