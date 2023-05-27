using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ContactApp.Core.Entities;
using NotesForms.ViewModels;

namespace NotesForms.Pages
{	
	public partial class SignUpPage : ContentPage
	{
		public User User { get; set; }

		public SignUpPage ()
		{
			InitializeComponent ();

			BindingContext = new SignUpViewModel( Navigation );
		}
    }
}

