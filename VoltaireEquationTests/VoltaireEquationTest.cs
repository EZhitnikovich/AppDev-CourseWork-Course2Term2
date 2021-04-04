using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using VoltaireEquationLib.Equation;

namespace VoltaireEquationTests
{
    [TestClass]
    public class VoltaireEquationTest
    {
        [TestMethod]
        public void StepLessThanZero()
        {
            var v = new VoltaireEquation(F, K, -4, 0, 1);
            Assert.ThrowsException<ValidationException>(() =>
            {
                Validator.ValidateObject(v, new ValidationContext(v), true);
            });
        }

        [TestMethod]
        public void LowerLimitLessThanZero()
        {
            var v = new VoltaireEquation(F, K, 0.512,-1, 1);
            Assert.ThrowsException<ValidationException>(() =>
            {
                Validator.ValidateObject(v, new ValidationContext(v), true);
            });
        }

        [TestMethod]
        public void UpperLimitLessThanZero()
        {
            var v = new VoltaireEquation(F, K, 0.512, 0, -11);
            Assert.ThrowsException<ValidationException>(() =>
            {
                Validator.ValidateObject(v, new ValidationContext(v), true);
            });
        }

        private double F(double x)
        {
            return x * x;
        }

        private double K(double x, double s)
        {
            return 2 + x * x - s * s;
        }
    }
}
