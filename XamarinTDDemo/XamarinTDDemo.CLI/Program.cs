using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinTDDemo.Babysitter;

namespace XamarinTDDemo.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var times = new Babysitter.Times();


            try
            {
                DateTime startTime;
                DateTime bedTime;
                DateTime endTime;

                DateTime.TryParse(args[0], out startTime);
                DateTime.TryParse(args[1], out bedTime);
                DateTime.TryParse(args[2], out endTime);

                times.Start = startTime;
                times.BedTime = bedTime;
                times.End = endTime;

                if(times.IsValid)
                {
                    Console.WriteLine(XamarinTDDemo.Babysitter.Calculator.Calculate(Rates(),times));
                }
            }
            catch
            {
                error();
            }

        }
        static void error()
        {
            var errorMessage = new StringBuilder();
            errorMessage.AppendLine("Commandline arguments formatted incorrectly");
            errorMessage.AppendLine("Use: XamarinTDDemo.CLI \"Start Time\" \"Bed Time\" \"End Time\"");
            errorMessage.AppendLine("Exampe: XamarinTDDemo.CLI \"5:00 pm\" \"9:00 pm\" \"4:00 am\"");

            Console.Write(errorMessage.ToString());
        }

        static IEnumerable<HourlyRate> Rates()
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

    }
}
