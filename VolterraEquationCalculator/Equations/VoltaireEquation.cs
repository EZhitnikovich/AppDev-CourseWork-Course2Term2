﻿using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using VoltaireEquationCalculator.Exceptions;

namespace VoltaireEquationCalculator.Equations
{
    public class VoltaireEquation
    {
        public Equation Equation { get; set; }

        private double h;
        public double H
        {
            get
            {
                return h;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Step must be greater then 0");
                }

                h = value;
            }
        }
        public double LowerLimit { get; set; }
        public double UpperLimit { get; set; }
        public double[] Result { get; private set; }

        public VoltaireEquation(double h,
                                double loverLimit,
                                double upperLimit,
                                Equation equation)
        {
            H = h;
            LowerLimit = loverLimit;
            UpperLimit = upperLimit;
            Equation = equation;
        }

        public void Calculate()
        {
            if (Equation.Kernel(LowerLimit, LowerLimit) == 0 || Equation.Function(LowerLimit) != 0)
            {
                throw new EquationNotSolvableException("This equation is not solvable");
            }

            var n = Convert.ToInt32((UpperLimit - LowerLimit) / H + 1);

            Result = new double[n];

            Result[0] = Equation.Function(LowerLimit);

            for (int i = 2; i <= n; i++)
            {
                var x = LowerLimit + (i - 1) * H; // вычисление xi
                var g = Equation.Function(x) / H;
                for (int j = 1; j <= i - 1; j++) // вычисление выражения в скобках
                {
                    var k1 = Equation.Kernel(x, LowerLimit + (j - 1) * H); // вычисление K(xi,xj)
                    if (j == 1)
                    {
                        k1 /= 2; // Ai = 0.5
                    }

                    g -= k1 * Result[j-1];
                }

                Result[i-1] = (2 * g) / Equation.Kernel(x, x); // вычисление yi
            }
        }

        public void DrawChart(Chart chart, Color color, int seriesIndex)
        {
            chart.Series[seriesIndex].Color = color;
            chart.Series[seriesIndex].Points.Clear();
            chart.Series[seriesIndex].ChartType = SeriesChartType.Spline;

            for (int i = 0; i < Result.Length; i++)
            {
                chart.Series[seriesIndex].Points.AddXY((i + 1) * H, Result[i]);
            }
        }
    }
}
