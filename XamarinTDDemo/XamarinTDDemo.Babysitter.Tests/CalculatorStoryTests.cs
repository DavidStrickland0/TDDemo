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
            //Starts at 5 pm
            int hoursBeforeBedtime = 4;
            //Bedtime 9 pm
            int hoursAfterBedtime = 3;
            //Job ends at 4 am
            int hoursToEndOfJob = 4;

            int rateForPreBedtime = 12;
            int rateBedTimeToMidnight = 8;
            int rateMidnightToEndOfJob = 16;


            var timings = new Timings()
            {

                PreBedtime = new TimeSpan(hoursBeforeBedtime, 0, 0),
                BedtimeToMidnight = new TimeSpan(hoursAfterBedtime, 0, 0),
                MidnightToEndOfJob = new TimeSpan(hoursToEndOfJob, 0, 0)
            };
            var rates = new Rates()
            {
                PreBedtime = rateForPreBedtime,
                BedtimeToMidnight = rateBedTimeToMidnight,
                MidnightToEndOfJob = rateMidnightToEndOfJob
            };
            decimal charge = Calculator.Calulate(rates, timings);
            Assert.IsTrue(charge ==
                hoursBeforeBedtime * rateForPreBedtime +
                hoursAfterBedtime * rateBedTimeToMidnight +
                hoursToEndOfJob * rateMidnightToEndOfJob
                );
        }
    }
}
