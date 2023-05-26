using System;
using System.Collections.Generic;

using Xamarin.Forms;
using NotesForms.Services;
using NotesForms.ViewModels;

namespace NotesForms.Pages
{	
	public partial class SignInPage : ContentPage
	{
        SignInVM _viewModel;

		public SignInPage ()
		{
            InitializeComponent();

            BindingContext = new SignInVM( Navigation );

            //MessagingCenter.Instance.Subscribe<SignUpPage, User>(this, "storeUser", storeUser);

        }
    }
}

