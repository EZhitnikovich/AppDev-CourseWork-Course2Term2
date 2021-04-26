namespace VoltaireEquationCalculator.Equations
{
    public class Equation
    {
        public virtual double Kernel(double x, double s)
        {
            return 2 + (x - s) * (x + s);
        }

        public virtual double Function(double x)
        {
            return x * x;
        }
    }
}
