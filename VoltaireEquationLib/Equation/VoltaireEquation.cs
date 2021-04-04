using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VoltaireEquationLib.Attributes;
using VoltaireEquationLib.Exceptions;

namespace VoltaireEquationLib.Equation
{
    public class VoltaireEquation
    {
        public Func<double, double> F { get; set; }
        public Func<double, double, double> K { get; set; }
        [PositiveNum(ErrorMessage = nameof(Step) + " must be greater than zero")]
        public double Step { get; set; }
        [PositiveNum(ErrorMessage = nameof(LowerLimit) + " must be greater than zero")]
        public double LowerLimit { get; set; }
        [PositiveNum(ErrorMessage = nameof(UpperLimit) + " must be greater than zero")]
        public double UpperLimit { get; set; }

        private VoltaireEquation() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f">Function</param>
        /// <param name="k">Core</param>
        /// <param name="step">Calculation step</param>
        /// <param name="lowerLimit">Lower limit of integral</param>
        /// <param name="upperLimit">Upper limit of integral</param>
        public VoltaireEquation(Func<double, double> f,
                                Func<double, double, double> k,
                                double step,
                                double lowerLimit,
                                double upperLimit)
        {
            F = f;
            K = k;
            Step = step;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public double Calculate()
        {
            if (K(LowerLimit, LowerLimit) == 0 || F(LowerLimit) !=0)
            {
                throw new EquationNotSolvableException("This equation is not solvable");
            }
            return 0;
        }
    }
}