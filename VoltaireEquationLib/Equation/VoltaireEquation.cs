﻿using System;
using VoltaireEquationLib.Exceptions;

namespace VoltaireEquationLib.Equation
{
    public class VoltaireEquation
    {
        public Func<double, double> F { get; set; }
        public Func<double, double, double> K { get; set; }
        public double Step { get; set; }
        public double LowerLimit { get; set; }
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
                throw new EquationNotSolvable("This equation is not solvable");
            }
            return 0;
        }
    }
}