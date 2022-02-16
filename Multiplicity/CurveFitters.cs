using System;
using System.Collections.Generic;
using System.Linq;

namespace Multiplicity
{
    public enum CurveFitType
    {
        SingleExponent,
        TwoExponent,
        Linear
    }

    public static class CurveFitHelper
    {
        public static CurveFitter GetFit(CurveFitType fitType, List<Tuple<double, double>> curve)
        {
            switch (fitType)
            {
                case CurveFitType.SingleExponent:
                    return new SingleExponentFit(curve);
                case CurveFitType.TwoExponent:
                    return new TwoExponentFit(curve);
                case CurveFitType.Linear:
                    return new LinearFit(curve);
                default:
                    throw new ArgumentOutOfRangeException(nameof(fitType), fitType, null);
            }
        }

        public static List<double> GetTimes(double startTime, double endTime, int InteriorPoints)
        {
            List<double> times = new List<double>();

            times.Add(startTime);
            double dTime = (endTime - startTime) / (InteriorPoints + 1);

            for (int i = 1; i <= InteriorPoints; i++)
            {
                times.Add(startTime + i * dTime);
            }

            times.Add(endTime);
            return times;
        }
    }

    public class LinearFit : CurveFitter
    {
        public LinearFit(List<Tuple<double, double>> curveToFit) : base(curveToFit)
        {
        }

        protected override List<double> MakeFit()
        {
            try
            {
                Tuple<double, double> fit = MathNet.Numerics.Fit.Line(X, Y);
                return new List<double>() {fit.Item1, fit.Item2};
            }
            catch
            {
                return GarbageFit(2);
            }
        }

        protected override double FitEvaluate(double xVal)
        {
            return fitParams[0] + xVal * fitParams[1];
        }
    }

    public class TwoExponentFit : CurveFitter
    {
        readonly Func<double, double, double, double, double> doubleExponent =
            (amp, exp1, exp2, x) =>
                amp * Math.Exp(x * exp1) * (1 - Math.Exp(x * exp2));

        public TwoExponentFit(List<Tuple<double, double>> intervalHistogram) : base(intervalHistogram)
        {
        }

        protected override List<double> MakeFit()
        {
            try
            {
                var fit = MathNet.Numerics.Fit.Curve(X, Y, doubleExponent, Y.Max(), 1.0, 1.0);
                return new List<double>() {fit.Item1, fit.Item2, fit.Item3};
            }
            catch
            {
                return GarbageFit(3);
            }
        }

        protected override double FitEvaluate(double xVal)
        {
            return doubleExponent(fitParams[0], fitParams[1], fitParams[2], xVal);
        }
    }


    public class SingleExponentFit : CurveFitter
    {
        public SingleExponentFit(List<Tuple<double, double>> intervalHistogram) : base(intervalHistogram)
        {
        }

        protected override List<double> MakeFit()
        {
            try
            {
                Tuple<double, double> fit = MathNet.Numerics.Fit.Exponential(X, Y);
                return new List<double>() {fit.Item1, fit.Item2};
            }
            catch
            {
                return GarbageFit(2);
            }
        }

        protected override double FitEvaluate(double xVal)
        {
            return fitParams[0] * Math.Exp(xVal * fitParams[1]);
        }
    }


    public abstract class CurveFitter
    {
        private const int DEFAULT_PLOT_POINTS = 100;

        protected double[] X;
        protected double[] Y;
        protected List<double> fitParams;
        private double rSquared;

        protected CurveFitter(List<Tuple<double, double>> curveToFit)
        {
            DoFitting(curveToFit);
        }

        private void DoFitting(List<Tuple<double, double>> curveToFit)
        {
            MakeXvsYarrays(curveToFit);
            fitParams = MakeFit();
            rSquared = MathNet.Numerics.GoodnessOfFit.RSquared(GetFitLineYPoints(curveToFit), Y);
        }

        private List<double> GetFitLineYPoints(List<Tuple<double, double>> curveToFit)
        {
            List<double> fitY = new List<double>();
            foreach (var x in X)
            {
                fitY.Add(EvaluateFitFunction(x));
            }

            return fitY;
        }

        public void FitNewCurve(List<Tuple<double, double>> curveToFit)
        {
            DoFitting(curveToFit);
        }

        public double GetRSquared()
        {
            return rSquared;
        }

        private void MakeXvsYarrays(List<Tuple<double, double>> curveToFit)
        {
            X = new double[curveToFit.Count];
            Y = new double[curveToFit.Count];
            int i = 0;
            foreach (var r in curveToFit)
            {
                X[i] = r.Item1;
                Y[i] = r.Item2;
                i++;
            }
        }

        public List<double> GetFitParameters()
        {
            return fitParams;
        }

        protected abstract List<double> MakeFit();

        protected double EvaluateFitFunction(double xEval)
        {
            try
            {
                return FitEvaluate(xEval);
            }
            catch
            {
                return 0;
            }
        }

        public List<Tuple<double, double>> GetLine(double startTime, double endTime)
        {
            List<Tuple<double, double>> line = new List<Tuple<double, double>>();
            foreach (var t in CurveFitHelper.GetTimes(startTime, endTime,
                DEFAULT_PLOT_POINTS))
            {
                line.Add(new Tuple<double, double>(t, EvaluateFitFunction(t)));
            }

            return line;
        }

        public void SetFitParameters(List<double> fitParameters)
        {
            fitParams = fitParameters;
        }

        protected List<double> GarbageFit(int nFitParams)
        {
            List<double> garbageFit = new List<double>();
            for (int i = 0; i < nFitParams; i++)
            {
                garbageFit.Add(double.NaN);
            }

            return garbageFit;
        }

        protected abstract double FitEvaluate(double xVal);
    }
}
