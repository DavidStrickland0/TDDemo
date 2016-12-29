using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTDDemo.Babysitter.Tests.Data
{
    public static class Defaults
    {
        public static Timings Timings()
        {
            //Starts at 5 pm
            int hoursBeforeBedtime = 4;
            //Bedtime 9 pm
            int hoursAfterBedtime = 3;
            //Job ends at 4 am
            int hoursToEndOfJob = 4;
            var timings = new Timings()
            {

                PreBedtime = new TimeSpan(hoursBeforeBedtime, 0, 0),
                BedtimeToMidnight = new TimeSpan(hoursAfterBedtime, 0, 0),
                MidnightToEndOfJob = new TimeSpan(hoursToEndOfJob, 0, 0)
            };
            return timings;
        }

        public static Rates Rates()
        {
            int rateForPreBedtime = 12;
            int rateBedTimeToMidnight = 8;
            int rateMidnightToEndOfJob = 16;
            var rates = new Rates()
            {
                PreBedtime = rateForPreBedtime,
                BedtimeToMidnight = rateBedTimeToMidnight,
                MidnightToEndOfJob = rateMidnightToEndOfJob
            };
            return rates;
        }

    }
}
