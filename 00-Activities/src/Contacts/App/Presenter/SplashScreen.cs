
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _00_Activities.src.Contacts.App.Presenter
{
	[Activity (
		Label = "SplashScreen",
		NoHistory = true,
		MainLauncher = false,
		Theme = "@style/AppTheme.NoActionBar"
    )]			
	public class SplashScreen : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
		}
	}
}

