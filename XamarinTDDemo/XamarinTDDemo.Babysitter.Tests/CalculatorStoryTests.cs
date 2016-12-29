using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XamarinTDDemo.Babysitter.Tests
{
    [TestClass]
    public class CalculatorStoryTests
    {
        [TestMethod]
        public void Story_Test_calculate_my_nightly_charge()
        {
            //Setup
            var timings = Data.Defaults.Timings();
            var rates = Data.Defaults.Rates();

            decimal expected = Data.Defaults.ExpectedCharge;

            //Assert
            decimal actual = Calculator.Calculate(rates, timings);
            Assert.AreEqual(expected, actual);
        }

    }
}
