using System;

namespace VoltaireEquationCalculator.Exceptions
{
    internal class EquationNotSolvableException : Exception
    {
        public EquationNotSolvableException() : base()
        {
        }

        public EquationNotSolvableException(string message) : base(message)
        {
        }
    }
}