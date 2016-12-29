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
            Timings timings = Data.Defaults.Timings();
            Rates rates = Data.Defaults.Rates();

            decimal actual = Calculator.Calulate(rates, timings);

            decimal expected =
                timings.PreBedtime.Hours * rates.PreBedtime +
                timings.BedtimeToMidnight.Hours * rates.BedtimeToMidnight +
                timings.MidnightToEndOfJob.Hours * rates.MidnightToEndOfJob;


            Assert.AreEqual(expected, actual);
        }

    }
}
