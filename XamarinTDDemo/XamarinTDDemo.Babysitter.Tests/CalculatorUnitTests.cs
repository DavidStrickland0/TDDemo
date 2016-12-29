using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XamarinTDDemo.Babysitter.Tests
{
    [TestClass]
    public class CalculatorUnitTests
    {
        [TestMethod]
        public void Calculate_my_nightly_charge_using_dateTimes()
        {
            //Setup
            var times = Data.Defaults.Times();
            var rates = Data.Defaults.Rates();

            decimal expected = Data.Defaults.ExpectedCharge;

            //Assert
            decimal actual = Calculator.Calculate(rates, times);
            Assert.AreEqual(expected, actual);
        }
    }
}
