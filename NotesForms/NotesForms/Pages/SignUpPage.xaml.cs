using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ContactApp.Core.Entities;
using NotesForms.ViewModels;
using NotesForms.Services;

namespace NotesForms.Pages
{	
	public partial class SignUpPage : ContentPage
	{
		public User User { get; set; }

		public SignUpPage ()
		{
			InitializeComponent ();

			var userService = DependencyService.Resolve<IUserService>();

			BindingContext = new SignUpViewModel( Navigation, userService );
		}
    }
}

