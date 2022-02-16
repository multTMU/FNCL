using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace Multiplicity
{
    public static class EquationSolver
    {
        public static Complex[] SolveCubic(double a, double b, double c, double d)
        {
            return FindRoots.Polynomial(new double[] {a, b, c, d});
        }

        public static List<Complex> SolvePolynomial(List<double> ascendingCoefficients)
        {
            return FindRoots.Polynomial(ascendingCoefficients.ToArray()).ToList();
        }
    }
}
