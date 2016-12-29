using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTDDemo.Babysitter
{
    public static class Calculator
    {

        public static decimal Calculate(IEnumerable<HourlyRate> rates, IEnumerable<Timing> timings)
        {
            decimal charge = 0;

            var totalChargeableTime = timings.Aggregate(TimeSpan.Zero, (total, timing) => total + timing.Time);

            var remainingTimings = timings;
            var hoursCharged = new TimeSpan();
            //Assumes After Midnight Time is more valuable then Prebedtime which is more valuable then post bedtime.
            while (hoursCharged < totalChargeableTime)
            {
                charge = charge + chargeHighestValueHour(rates,remainingTimings);
                hoursCharged= hoursCharged.Add(new TimeSpan(1,0,0));
            }
            return charge;
        }

        public static decimal Calculate(IEnumerable<HourlyRate> rates, Times times)
        {
            return Calculate(rates, toTimings(times));
        }

        private static IEnumerable<Timing> toTimings(Times times)
        {
            var timings = new List<Timing>();
            timings.Add(new Timing() { Catagory = PricingCatagories.BedtimeToMidnight,
                Time = extractTiming(PricingCatagories.BedtimeToMidnight, times)
            });
            timings.Add(new Timing()
            {
                Catagory = PricingCatagories.MidnightToEndOfJob,
                Time = extractTiming(PricingCatagories.MidnightToEndOfJob, times)
            });
            timings.Add(new Timing()
            {
                Catagory = PricingCatagories.PreBedTime,
                Time = extractTiming(PricingCatagories.PreBedTime, times)
            });
            return timings;
        }

        /// <summary>
        /// Extracts the given time catagory from the list of times. 
        /// </summary>
        /// <param name="catagory"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        private static TimeSpan extractTiming(PricingCatagories catagory, Times times)
        {
            var result = TimeSpan.Zero;

            switch (catagory)
            {
                case PricingCatagories.PreBedTime:
                    if(times.BedTime>CalculatorSettings.StartOfWorkDay)
                        result = times.BedTime.Subtract(times.Start);
                    if (times.BedTime == CalculatorSettings.StartOfDay)
                        result = CalculatorSettings.EndOfDay.Subtract(times.Start);
                    break;
                case PricingCatagories.BedtimeToMidnight:
                    if (times.BedTime > CalculatorSettings.StartOfWorkDay)
                        result = CalculatorSettings.EndOfDay.Subtract(times.BedTime);
                    break;
                case PricingCatagories.MidnightToEndOfJob:
                    if (times.End <= CalculatorSettings.EndOfWorkDay)
                        result = times.End.Subtract(CalculatorSettings.StartOfDay);
                    break;
            };
            return result;
        }

        private static decimal chargeHighestValueHour(IEnumerable<HourlyRate> rates, IEnumerable<Timing> remainingTimings)
        {
            //Concat the two Collections so we can work with Time and rate together
            var appendedRates = remainingTimings
                .Join(rates, t => t.Catagory, r => r.Catagory,
                (timing, rate) => new { timing.Catagory, timing.Time, rate.Rate });

            //Finds which of the remaining Hours have the highest value
            var hourToCharge = appendedRates.Where(aR => aR.Time > TimeSpan.Zero).OrderBy(ar => ar.Rate).Last();

            //Updated the remainingTimings collection removing the hour we are charging
            var timingToChange = remainingTimings.Where(rT => rT.Catagory == hourToCharge.Catagory).First();
            timingToChange.Time = timingToChange.Time.Subtract(new TimeSpan(1, 0, 0));
            return hourToCharge.Rate;
        }
    }
}
