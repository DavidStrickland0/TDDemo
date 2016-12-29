using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<Timing> timings = Data.Defaults.Timings();
            var rates = Data.Defaults.Rates();

            decimal expected = Data.Defaults.ExpectedCharge;

            //Modify
            var timingToChange = timings.Where(t => t.Catagory == PricingCatagories.BedtimeToMidnight).First();
            timingToChange.Time = timingToChange.Time.Subtract(new TimeSpan(0, 15, 0));

            //Assert
            decimal actual = Calculator.Calulate(rates, timings);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Adds 15 minutes to the lowest value time and subtracts 15 minutes to the highest value time 
        /// to ensure the higher value time gets charged.
        /// </summary>
        [TestMethod]
        public void cant_be_paid_for_more_hours_then_they_worked()
        {
            //Setup
            var timings = Data.Defaults.Timings();
            var rates = Data.Defaults.Rates();
            decimal expected = Data.Defaults.ExpectedCharge;

            //Modify
            var midnightOntiming = timings.Where(t => t.Catagory == PricingCatagories.MidnightToEndOfJob).First();
            midnightOntiming.Time = midnightOntiming.Time.Subtract(new TimeSpan(0, 15, 0));

            var bedToMidnightTimeing = timings.Where(t => t.Catagory == PricingCatagories.BedtimeToMidnight).First();
            bedToMidnightTimeing.Time = bedToMidnightTimeing.Time.Subtract(new TimeSpan(0, 15, 0));

            //Assert
            decimal actual = Calculator.Calulate(rates, timings);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void starts_no_earlier_than_5_00PM()
        {
            //Setup
            var times = Data.Defaults.Times();
            var rates = Data.Defaults.Rates();
            decimal expected = Data.Defaults.ExpectedCharge;

            //Modify
            times.Start = DateTime.Parse("4:00 pm");

            //Assert
            Assert.IsFalse(times.IsValid);
        }


    }
}
