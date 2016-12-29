using System;

namespace XamarinTDDemo.Babysitter
{
    public class Times
    {
        public DateTime BedTime { get; set; }
        public DateTime End { get; set; }
        public DateTime Start { get; set; }

        public bool IsValid
        {
            get
            {
                return Start >= DateTime.Parse("5:00 pm") &&
                    End <= DateTime.Parse("4:00 am");
            }
        }
    }
}