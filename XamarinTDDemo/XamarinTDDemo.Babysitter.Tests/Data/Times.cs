using System;

namespace XamarinTDDemo.Babysitter.Tests.Data
{
    public class Times
    {
        public DateTime BedTime { get; internal set; }
        public DateTime End { get; internal set; }
        public DateTime Start { get; internal set; }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }
    }
}