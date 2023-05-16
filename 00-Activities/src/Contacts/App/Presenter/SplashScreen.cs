
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace _00_Activities.src.Contacts.App.Presenter
{
	[Activity (
		Label = "SplashScreen",
		NoHistory = true,
		MainLauncher = true,
		Theme = "@style/AppTheme.NoActionBar"
    )]			
	public class SplashScreen : AppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView( Resource.Layout.splash_loucher );
		}

        protected override void OnResume()
        {
            base.OnResume();

			Task startupWork = new Task( () => { SimulateStartup(); } );

			startupWork.Start();
        }

        async void SimulateStartup()
        {
			await Task.Delay( 3000 );
			StartActivity( new Intent( Application.Context, typeof( ContactsActivity ) ) ); 
        }
    }
}

