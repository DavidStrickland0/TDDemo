using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamarinTDDemo.UI;

namespace XamarinTDDUI.Droid
{
	[Activity (Label = "XamarinTDDUI.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
		}
	}
}


