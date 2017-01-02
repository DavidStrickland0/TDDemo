using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinTDDemo.UI.ViewModels;

namespace XamarinTDDUI.Views

{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
            BindingContext = new CalculatorViewModel();
        }

    }
}
