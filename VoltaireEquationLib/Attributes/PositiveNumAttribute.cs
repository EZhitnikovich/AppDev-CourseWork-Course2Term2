using System.ComponentModel.DataAnnotations;

namespace VoltaireEquationLib.Attributes
{
    internal class PositiveNumAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is double d)
            {
                return d >= 0;
            }

            return false;
        }
    }
}