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

            charge = charge + rates.PreBedtime * timings.PreBedtime.Hours  ;
            charge = charge + rates.BedtimeToMidnight * timings.BedtimeToMidnight.Hours;
            charge = charge + rates.MidnightToEndOfJob * timings.MidnightToEndOfJob.Hours;

            return charge;
        }
    }
}
