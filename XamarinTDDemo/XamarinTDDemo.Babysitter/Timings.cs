using System;

namespace XamarinTDDemo.Babysitter
{
    public class Timings
    {
        public Timings()
        {
        }

        public TimeSpan BedtimeToMidnight { get; set; }
        public TimeSpan MidnightToEndOfJob { get; set; }
        public TimeSpan PreBedtime { get; set; }
    }
}