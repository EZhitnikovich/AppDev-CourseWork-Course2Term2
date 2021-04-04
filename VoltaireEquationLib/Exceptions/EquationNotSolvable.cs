using System;

namespace VoltaireEquationLib.Exceptions
{
    internal class EquationNotSolvable: Exception
    {
        public EquationNotSolvable():base()
        {
        }

        public EquationNotSolvable(string message) : base(message)
        {
        }
    }
}