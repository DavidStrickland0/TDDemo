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
            Timings timings = Data.Defaults.Timings();
            Rates rates = Data.Defaults.Rates();

            decimal expected =
                timings.PreBedtime.Hours * rates.PreBedtime +
                timings.BedtimeToMidnight.Hours * rates.BedtimeToMidnight +
                timings.MidnightToEndOfJob.Hours * rates.MidnightToEndOfJob;

            //Assert
            decimal actual = Calculator.Calulate(rates, timings);
            Assert.AreEqual(expected, actual);
        }

    }
}
