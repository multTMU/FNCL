using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Multiplicity
{
    // TODO: REFACTOR THIS MESS
    public class PointKineticsParameters
    {
        public class NukeParameters
        {
            public double Efficiency;
            public double DieAway;
            public double Single;
            public double Double;
            public double Triple;

            private double Gate;
            private double TGate;
            private double DGate;
            private NuMom IF;
            private NuMom SF;
            private double Mult;
            private double Fission;
            private double Mass;
            private double Alpha;

            public NukeParameters(double eff, double dieAway, double S, double D, double T, double gate)
            {
                Efficiency = eff;
                DieAway = dieAway;
                Single = S;
                Double = D;
                Triple = T;
                Gate = gate;
                DGate = GetDoublesGate();
                TGate = GetTriplesGate();
            }

            public static string GetHeader()
            {
                return "Mult  Mass  Alpha Singles Doubles Triples";
            }

            public string GetResult()
            {
                return Mult + " " + Mass + " " + Alpha + " " + GetSingles().ToString() + " " + GetDoubles().ToString() +
                       " " + GetTriples().ToString();
            }

            public double GetSingles()
            {
                return Fission * Efficiency * Mult * SF.Nu1 * (1 + Alpha);
            }

            public double GetDoubles()
            {
                return ((Fission * Efficiency * Efficiency * DGate * Mult * Mult) / 2.0) *
                       (SF.Nu2 + ((Mult - 1.0) / (IF.Nu1 - 1.0)) * (1.0 + Alpha) * IF.Nu2);
            }

            public double GetTriples()
            {
                return ((Fission * Efficiency * Efficiency * Efficiency * TGate * Mult * Mult * Mult) / 6.0) *
                       (SF.Nu3 + ((Mult - 1.0) / (IF.Nu1 - 1.0)) *
                           (3.0 * SF.Nu2 * IF.Nu2 + SF.Nu1 * (1.0 + Alpha) * IF.Nu3 +
                            3.0 * ((Mult - 1.0) / (IF.Nu1 - 1.0)) * ((Mult - 1.0) / (IF.Nu1 - 1.0))) * SF.Nu1 *
                           (1.0 + Alpha) * IF.Nu2 * IF.Nu2);
            }

            private double GetDoublesGate()
            {
                return (1.0 - Math.Exp(Gate / DieAway));
            }

            private double GetTriplesGate()
            {
                double dGate = GetDoublesGate();
                return dGate * dGate;
            }

            public void SolveForMultiplication(NuMom inducedFission, NuMom spontaneousFission)
            {
                IF = inducedFission;
                SF = spontaneousFission;

                List<double> coeffs = new List<double>();
                coeffs.Add(GetA());
                coeffs.Add(GetB());
                coeffs.Add(GetC());
                coeffs.Add(GetD());

                SetMultiplication(coeffs);
                Solve();
            }

            private void Solve()
            {
                Fission = ((2.0 * Double / (Efficiency * DGate)) -
                           (Mult * (Mult - 1.0) * IF.Nu2 * Single) / (IF.Nu1 - 1.0)) /
                          (Efficiency * Mult * Mult * SF.Nu2);

                Mass = (Fission / (473.5));
                Alpha = (Single / (Fission * Efficiency * SF.Nu1 * Mult)) - 1.0;
            }

            private void SetMultiplication(List<double> coeffs)
            {
                List<Complex> mults = EquationSolver.SolvePolynomial(coeffs);
                double maxDouble = double.MinValue;
                foreach (var m in mults)
                {
                    if (m.Real > maxDouble && m.Imaginary == 0)
                    {
                        maxDouble = m.Real;
                    }
                }

                Mult = maxDouble;
            }

            private double GetA()
            {
                return (-6.0 * Triple * SF.Nu2 * (IF.Nu1 - 1.0)) /
                       (Efficiency * Efficiency * TGate * Single * (SF.Nu2 * IF.Nu3 - SF.Nu3 * IF.Nu2));
            }

            private double GetB()
            {
                return (2.0 * Double * (SF.Nu3 * (IF.Nu1 - 1.0) - 3.0 * SF.Nu2 * IF.Nu2)) /
                       (Efficiency * DGate * Single * (SF.Nu2 * IF.Nu3 - SF.Nu3 * IF.Nu2));
            }

            private double GetC()
            {
                return ((6.0 * Double * SF.Nu2 * IF.Nu2) /
                        (Efficiency * DGate * Single * (SF.Nu2 * IF.Nu3 - SF.Nu3 * IF.Nu2))) - 1.0;
            }

            private double GetD()
            {
                return 1.0;
            }
        }

        public struct NuMom
        {
            public double Nu1;
            public double Nu2;
            public double Nu3;
        }

        private NuMom Pu240;
        private NuMom Pu239;
        private List<NukeParameters> nuke;

        private double Gate = 1e6;

        public PointKineticsParameters(string fileIn, string fileOut)
        {
            SetPuConstants();
            nuke = new List<NukeParameters>();
            using (StreamReader sr = new StreamReader(fileIn))
            {
                while (!sr.EndOfStream)
                {
                    string curLine = sr.ReadLine();
                    if (!curLine.Contains('#'))
                    {
                        var split = curLine.Split('\t');

                        NukeParameters n = new NukeParameters(double.Parse(split[0]), double.Parse(split[1]),
                            double.Parse(split[2]), double.Parse(split[3]), double.Parse(split[4]), Gate);
                        nuke.Add(n);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(fileOut))
            {
                sw.WriteLine(NukeParameters.GetHeader());
                foreach (var n in nuke)
                {
                    n.SolveForMultiplication(Pu239, Pu240);
                    sw.WriteLine(n.GetResult());
                }
            }
        }

        private void SetPuConstants()
        {
            Pu240 = new NuMom {Nu1 = 2.154, Nu2 = 3.788939, Nu3 = 5.210497};

            //Pu239 = new NuMom {Nu1 = 2.876, Nu2 = 2.7435, Nu3 = 12.5447};
            Pu239 = new NuMom {Nu1 = 2.876, Nu2 = 6.7435, Nu3 = 12.5447};
        }
    }
}
