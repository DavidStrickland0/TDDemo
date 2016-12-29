using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinTDDemo.Babysitter
{
    public static class CalculatorSettings
    {
        public static DateTime StartOfWorkDay = DateTime.Parse("5:00 pm");
        public static DateTime EndOfWorkDay = DateTime.Parse("4:00 am");
        public static DateTime StartOfDay = DateTime.Parse("12:00 am");
        public static DateTime EndOfDay = DateTime.Parse("11:59 pm");
    }
}
