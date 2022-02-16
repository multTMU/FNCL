namespace Multiplicity
{
    public struct MultiplicityRates
    {
        public static string HEADER = "GateWidth(s)" + SEP + "CountTime(s)" + SEP +
                                      "Singles(cps)" + SEP + "Doubles(cps)" + SEP + "Triples(cps)";

        private const char SEP = '\t';

        public double GateWidth;
        public double CountTime;
        public double Singles;
        public double Doubles;
        public double Triples;

        private const double CONVERTSEC = 1e-9;

        public override string ToString()
        {
            var inSeconds = ConvertToSeconds();
            return inSeconds.GateWidth.ToString() + SEP + inSeconds.CountTime.ToString() + SEP
                   + inSeconds.Singles.ToString() + SEP + inSeconds.Doubles.ToString() + SEP
                   + inSeconds.Triples.ToString();
        }

        public MultiplicityRates ConvertToSeconds()
        {
            MultiplicityRates B = this;
            B.GateWidth *= CONVERTSEC;
            B.CountTime *= CONVERTSEC;
            B.Singles /= CONVERTSEC;
            B.Doubles /= CONVERTSEC;
            B.Triples /= CONVERTSEC;
            return B;
        }

        public static MultiplicityRates operator -(MultiplicityRates A, MultiplicityRates B)
        {
            MultiplicityRates C = A;
            C.Singles = A.Singles - B.Singles;
            C.Doubles = A.Doubles - B.Doubles;
            C.Triples = A.Triples - B.Triples;
            return C;
        }

        public static MultiplicityRates operator *(double scalar, MultiplicityRates A)
        {
            MultiplicityRates B = A;
            B.Singles = scalar * A.Singles;
            B.Doubles = scalar * A.Doubles;
            B.Triples = scalar * A.Triples;
            return B;
        }

        public static MultiplicityRates operator *(MultiplicityRates A, double scalar)
        {
            return scalar * A;
        }

        public static MultiplicityRates operator /(MultiplicityRates A, double scalar)
        {
            return (1.0 / scalar) * A;
        }

        public static MultiplicityRates operator /(MultiplicityRates A, MultiplicityRates B)
        {
            MultiplicityRates C = A;
            C.Singles = A.Singles / B.Singles;
            C.Doubles = A.Doubles / B.Doubles;
            C.Triples = A.Triples / B.Triples;
            return C;
        }
    }

    public static class MultiplicityRatesHelper<TPulse> where TPulse : IPulse
    {
        public static MultiplicityRates GetMultiplicityRates(IMultiplicityGate multiplicityGate, double gateWidth)
        {
            MultiplicityRates rates = new MultiplicityRates();
            multiplicityGate.RunForGateWidth(gateWidth);
            rates.GateWidth = multiplicityGate.GetGateWidth();
            rates.CountTime = multiplicityGate.GetCountTime();

            rates.Singles = multiplicityGate.GetSinglesRate();
            rates.Doubles = multiplicityGate.GetDoublesRate();
            rates.Triples = multiplicityGate.GetTriplesRate();

            return rates;
        }

        private static double DoublesNotShift(IMultiplicityGate mult)
        {
            bool dumbWay = false;

            if (dumbWay)
            {
                try
                {
                    double d = 0;
                    for (int i = 2; i < mult.GetRealsAccidentals().NonNormalizedDistribution.Count; i++)
                    {
                        d += mult.GetRealsAccidentals().NonNormalizedDistribution[i];
                    }

                    double highDoubles = d / mult.GetCountTime();

                    return mult.GetRealsAccidentals().NonNormalizedDistribution[2] / mult.GetCountTime();
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                int i = 0;
                double sumRA = 0;
                foreach (var c in mult.GetRealsAccidentals().NonNormalizedDistribution)
                {
                    sumRA += (i * (i - 1)) * c / 2.0;
                    i++;
                }

                return sumRA / mult.GetCountTime();
            }
        }

        private static double TriplesNotShift(IMultiplicityGate mult, double singles, double doubles)
        {
            double sumTmi = 0;
            int i = 0;
            foreach (var c in mult.GetRealsAccidentals().NonNormalizedDistribution)
            {
                sumTmi += ((i * (i - 1) * (i - 2))) * c / 6.0;
                i++;
            }

            return (sumTmi / mult.GetCountTime()) - singles * doubles * mult.GetGateWidth();
        }

        //private static double SinglesNotShift(IMultiplicityGate mult)
        //{
        //    double sumQi = 0;
        //    int i = 0;
        //    foreach (var d in mult.GetRealsAccidentals().NonNormalizedDistribution)
        //    {
        //        sumQi += i * d;
        //        i++;
        //    }
        //    return sumQi / mult.GetCountTime();
        //}

        //private static double GetSinglesRate(IMultiplicityGate mult)
        //{
        //    return mult.GetSinglesRate();
        //}

        //private static double SinglesShift(IMultiplicityGate mult)
        //{
        //    double sumQi = mult.GetAccidentals().NonNormalizedDistribution.Sum(); // corresponds to Louise's notation
        //    return sumQi / mult.GetCountTime();
        //}

        //private static double DoublesShift(IMultiplicityGate mult)
        //{
        //    int i = 0;
        //    double sumA = 0;
        //    foreach (var c in mult.GetAccidentals().NonNormalizedDistribution)
        //    {
        //        sumA += i * c;
        //        i++;
        //    }

        //    i = 0;
        //    double sumRA = 0;
        //    foreach (var c in mult.GetRealsAccidentals().NonNormalizedDistribution)
        //    {
        //        sumRA += i * c;
        //        i++;
        //    }

        //    return (sumRA - sumA) / mult.GetCountTime();
        //}

        //private static double TriplesShift(IMultiplicityGate mult, double SinglesRate, double DoublesRate)
        //{
        //    double sumTmi = 0;
        //    int i = 0;
        //    foreach (var c in mult.GetReals().NonNormalizedDistribution)
        //    {
        //        sumTmi += ((i * (i - 1)) / 2) * c;
        //        i++;
        //    }

        //    return (sumTmi / mult.GetCountTime()) - SinglesRate * DoublesRate * mult.GetGateWidth();
        //}
    }
}
