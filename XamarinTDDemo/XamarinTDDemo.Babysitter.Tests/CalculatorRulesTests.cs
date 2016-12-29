using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XamarinTDDemo.Babysitter.Tests
{
    /// <summary>
    /// Summary description for CalculatorRules
    /// </summary>
    [TestClass]
    public class CalculatorRulesTests
    {
        [TestMethod]
        public void paid_for_full_hours_no_fractional_hours()
        {
            //Setup
            Timings timings = Data.Defaults.Timings();
            Rates rates = Data.Defaults.Rates();
            decimal expected =
                timings.PreBedtime.Hours * rates.PreBedtime +
                timings.BedtimeToMidnight.Hours * rates.BedtimeToMidnight +
                timings.MidnightToEndOfJob.Hours * rates.MidnightToEndOfJob;
            
            //Modify
            timings.BedtimeToMidnight = timings.BedtimeToMidnight.Subtract(new TimeSpan(0, 15, 0));

            //Assert
            decimal actual = Calculator.Calulate(rates, timings);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void cant_be_paid_for_more_hours_then_they_worked()
        {
            //Setup
            Timings timings = Data.Defaults.Timings();
            Rates rates = Data.Defaults.Rates();
            decimal expected =
                timings.PreBedtime.Hours * rates.PreBedtime +
                timings.BedtimeToMidnight.Hours * rates.BedtimeToMidnight +
                timings.MidnightToEndOfJob.Hours * rates.MidnightToEndOfJob;

            //Modify
            timings.PreBedtime = timings.PreBedtime.Subtract(new TimeSpan(0, 15, 0));
            timings.BedtimeToMidnight = timings.BedtimeToMidnight.Add(new TimeSpan(0, 15, 0));

            //Assert
            decimal actual = Calculator.Calulate(rates, timings);
            Assert.AreEqual(expected, actual);
        }

    }
}
