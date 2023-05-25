using System;
using System.Collections.Generic;
using NotesForms.Services;
using NotesForms.ViewModels;
using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class ProfilesPage : ContentPage
	{	
		public ProfilesPage ()
		{
			InitializeComponent ();

			var app = App.Current as App;

            var phoneDialer = DependencyService.Resolve<IPhoneDialer>();

            BindingContext = new ProfileViewModel( phoneDialer );
            //lblProfile.Text = $"Welcome {app.GetUsername()}";
		}

        void OnBack(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();

        }
    }
}

