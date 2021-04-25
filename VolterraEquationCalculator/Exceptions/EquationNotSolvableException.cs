using System;

namespace VolterraEquationCalculator.Exceptions
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