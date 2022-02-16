using System;
using System.Collections.Generic;

namespace Multiplicity
{
    public struct FactorialMoments
    {
        public double Mean;
        public double Second;
        public double SecondExcess;
        public double Third;
        public double ThirdExcess;
        public double FeynmanY;
    }

    public static class FactorialMomentsHelper
    {
        public static FactorialMoments GetFactorialMoments(MultiplicityDistribution distribution)
        {
            List<double> dist = distribution.NormalizedDistribution;
            FactorialMoments moments;

            moments.Mean = getMean(dist);
            moments.Second = getSecond(dist);
            moments.Third = getThird(dist);

            moments.SecondExcess = getSecondExcess(moments.Mean, moments.Second);
            moments.ThirdExcess = getThirdExcess(moments.Mean, moments.SecondExcess, moments.Third);

            moments.FeynmanY = getFeynmanY(moments.Mean, moments.SecondExcess);

            return moments;
        }

        private static double getFeynmanY(in double momentsMean, in double momentsSecondExcess)
        {
            return momentsSecondExcess / momentsMean;
        }

        private static double getThirdExcess(double mean, double secondExcess, double third)
        {
            return third - 3.0 * mean * secondExcess - Math.Pow(mean, 3);
        }

        private static double getSecondExcess(in double momentsMean, in double momentsSecond)
        {
            return momentsSecond - (momentsMean * momentsMean);
        }

        private static double getMean(List<double> dist)
        {
            double mean = 0;
            int n = 0;
            foreach (var d in dist)
            {
                mean += n * d;
                n++;
            }

            return mean;
        }

        private static double getSecond(List<double> dist)
        {
            double second = 0;
            int n = 0;
            foreach (var d in dist)
            {
                second += n * (n - 1) * d;
                n++;
            }

            return second;
        }

        private static double getThird(List<double> dist)
        {
            double third = 0;
            int n = 0;
            foreach (var d in dist)
            {
                third += n * (n - 1) * (n - 2) * d;
                n++;
            }

            return third;
        }
    }


    //public class PoissonDistribution
    //{
    //    private readonly Poisson distribution;

    //    public PoissonDistribution(double lambda)
    //    {
    //        distribution = new Poisson(lambda);
    //    }

    //    public int GetSample()
    //    {
    //        return distribution.Sample();
    //    }

    //    public List<int> GetSamples(int nSamples)
    //    {
    //        List<int> samples = new List<int>();
    //        for (int i = 0; i < nSamples; i++)
    //        {
    //            samples.Add(distribution.Sample());
    //        }

    //        return samples;
    //    }
    //}
}
