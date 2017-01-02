using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinTDDUI;
using XamarinTDDUI.Views;

namespace XamarinTDDemo.UI
{
    public class App : Application
    {

        public App()
        {
            this.Init();
        }

        public void Init()
        {

            this.MainPage = new CalculatorPage() { Title = "Baby Sitter Calculator" };
        }
        public string MainText { get; set; } = "MainText";
    }
}
