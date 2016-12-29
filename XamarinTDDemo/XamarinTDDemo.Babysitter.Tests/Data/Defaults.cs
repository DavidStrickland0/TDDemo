using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTDDemo.Babysitter.Tests.Data
{
    public static class Defaults
    {

        public static int ExpectedCharge = 136; 
        public static IEnumerable<Timing> Timings()
        {
            //Starts at 5 pm
            int hoursBeforeBedtime = 4;
            //Bedtime 9 pm
            int hoursAfterBedtime = 3;
            //Job ends at 4 am
            int hoursToEndOfJob = 4;
            var timings = new List<Timing>()
            {
                new Timing()
                {
                    Catagory=PricingCatagories.PreBedTime,
                    Time= new TimeSpan(hoursBeforeBedtime,0,0)
                },
                new Timing()
                {
                    Catagory=PricingCatagories.BedtimeToMidnight,
                    Time= new TimeSpan(hoursAfterBedtime,0,0)
                },
                new Timing()
                {
                    Catagory=PricingCatagories.MidnightToEndOfJob,
                    Time= new TimeSpan(hoursToEndOfJob,0,0)
                },

            };
            return timings;
        }

        public static IEnumerable<HourlyRate> Rates()
        {
            int rateForPreBedtime = 12;
            int rateBedTimeToMidnight = 8;
            int rateMidnightToEndOfJob = 16;
            var rates = new List<HourlyRate>()
            {
                new HourlyRate()
                {
                    Catagory = PricingCatagories.PreBedTime,
                    Rate = rateForPreBedtime
                },
                new HourlyRate()
                {
                    Catagory = PricingCatagories.BedtimeToMidnight,
                    Rate = rateBedTimeToMidnight
                },
                new HourlyRate()
                {
                    Catagory = PricingCatagories.MidnightToEndOfJob,
                    Rate = rateMidnightToEndOfJob
                }

            };
            return rates;
        }
        public static Times Times()
        {
            Times times = new Times();
            times.Start = DateTime.Parse("5:00 pm");
            times.End = DateTime.Parse("4:00 am");
            times.BedTime = DateTime.Parse("9:00 pm");
            return times;
        }
    }
}
