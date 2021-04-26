using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoltaireEquationCalculator.Equations
{
    class EquationOneMinusX: Equation
    {
        public override double Function(double x)
        {
            return 1 - x;
        }

        public override double Kernel(double x, double s)
        {
            return x * x + 2 * s;
        }
    }
}
