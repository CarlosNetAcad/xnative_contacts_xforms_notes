using System;
using System.Collections.Generic;
using NotesForms.Services;
using NotesForms.ViewModels;

using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class AppLoadingPage : ContentPage
	{	
		public AppLoadingPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is AppLoadingViewModel vm)
            {
                vm.CheckUserSessionCommand.Execute(null);
            }
        }
    }
}

