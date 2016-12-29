using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTDDemo.Babysitter
{
    public static class Calculator
    {

        public static decimal Calulate(Babysitter.Rates rates, Babysitter.Timings timings)
        {
            decimal charge =0 ;

            charge = charge + rates.PreBedtime * timings.PreBedtime.ToFullHours().Hours  ;
            charge = charge + rates.BedtimeToMidnight * timings.BedtimeToMidnight.ToFullHours().Hours;
            charge = charge + rates.MidnightToEndOfJob * timings.MidnightToEndOfJob.ToFullHours().Hours;

            return charge;
        }
        public static TimeSpan ToFullHours(this TimeSpan timespan)
        {
            if (timespan.Milliseconds > 0)
                timespan = timespan.Add(new TimeSpan(0, 0, 1));
            if (timespan.Seconds > 0)
                timespan = timespan.Add(new TimeSpan(0, 1, 0));
            if (timespan.Minutes > 0)
                timespan = timespan.Add(new TimeSpan(1, 0, 0));
            return timespan;
        }

    }
}
