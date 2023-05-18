
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
using NotesForms.Pages;

namespace NotesForms.Droid
{
    [Activity(
        Label           = "SplashActivity",
        MainLauncher    = true,
        NoHistory       = true,
        Theme           = "@style/AppTheme.NoActionBar"
    )]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView( Resource.Layout.splash_louncher );
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => { SimulateStartup(); });

            startupWork.Start();
        }

        async void SimulateStartup()
        {
            await Task.Delay(3000);
            StartActivity(new Intent(Application.Context, typeof( MainActivity )));
        }
    }
}

