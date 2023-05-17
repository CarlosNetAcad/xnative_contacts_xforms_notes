using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class ProfilesPage : ContentPage
	{	
		public ProfilesPage ()
		{
			InitializeComponent ();

			var app = App.Current as App;

			lblProfile.Text = app.GetUsername();
		}

        void OnBack(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();

        }

        void OnSignOut(System.Object sender, System.EventArgs e)
        {
            var app = App.Current as App;
            app.SignOut();
        }
    }
}

