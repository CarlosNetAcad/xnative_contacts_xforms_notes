using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class SignInPage : ContentPage
	{	
		public SignInPage ()
		{
			InitializeComponent ();
		}

        void SignInHandler(System.Object sender, System.EventArgs e)
        {
            // Navigation.PushAsync(new MenuPage());
            var app = App.Current as App;
            app.SetUsername(usernameEntry.Text);
            app.SignIn();
        }

        void SignUpHandler(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}

