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

        [TestMethod]
        public void Calculate_my_nightly_charge_using_dateTimes_when_there_is_no_bedtime()
        {
            //Setup
            var times = Data.Defaults.Times();
            var rates = Data.Defaults.Rates();

            times.BedTime = CalculatorSettings.StartOfDay; 

            decimal expected = 148;

            //Assert
            decimal actual = Calculator.Calculate(rates, times);
            Assert.AreEqual(expected, actual);
        }


    }
}
