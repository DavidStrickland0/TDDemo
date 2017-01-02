using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinTDDemo.Babysitter;

namespace XamarinTDDemo.UI.ViewModels
{
    
    public class CalculatorViewModel:ViewModelBase    {

        public CalculatorViewModel()
        {
            ClickedCommand = new Command(() => calculate(),()=>validate());
            
        }



        public Command ClickedCommand { get; set; }

        string total= "0.00";
        public string Total
        {
            get {
                return total;
            }
            set {
                total = value;
            }
        }

        string startTime;
        public string StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                ClickedCommand.ChangeCanExecute();
            }
        }


        string bedTime;
        public string BedTime
        {
            get { return bedTime; }
            set
            {
                bedTime = value;
                ClickedCommand.ChangeCanExecute();
            }
        }
        string finishedTime;
        public string FinishedTime {
            get { return finishedTime; }
            set {
                finishedTime = value;
                ClickedCommand.ChangeCanExecute();
            }
        }

        Times times = null;
        private bool validate()
        {

            DateTime startDateTime = default(DateTime);
            DateTime bedDateTime = default(DateTime);
            DateTime finishedDateTime = default(DateTime);

            if (
                DateTime.TryParse(StartTime, out startDateTime) &&
                DateTime.TryParse(BedTime, out bedDateTime) &&
                DateTime.TryParse(FinishedTime, out finishedDateTime)) 
            {
                times = new Times()
                {
                    Start = startDateTime,
                    End = finishedDateTime,
                    BedTime = bedDateTime
                };
                return times.IsValid;
            }
            else
            {
                return false;
            }

        }
        private void calculate()
        {
            if (validate())
            {
                var Rates = new List<HourlyRate>();

                Rates.Add(new Babysitter.HourlyRate() { Catagory = PricingCatagories.BedtimeToMidnight, Rate = 8 });
                Rates.Add(new Babysitter.HourlyRate() { Catagory = PricingCatagories.PreBedTime, Rate = 12 });
                Rates.Add(new Babysitter.HourlyRate() { Catagory = PricingCatagories.MidnightToEndOfJob, Rate = 16 });

                Total = Calculator.Calculate(Rates, times).ToString();
            }
        }
    }
}
