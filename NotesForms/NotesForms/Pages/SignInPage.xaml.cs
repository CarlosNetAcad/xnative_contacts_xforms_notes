using System;
using System.Collections.Generic;

using Xamarin.Forms;
using NotesForms.Services;
using NotesForms.ViewModels;

namespace NotesForms.Pages
{	
	public partial class SignInPage : ContentPage
	{
        SignInViewModel _viewModel;

		public SignInPage ()
		{
            InitializeComponent();

            var authService = DependencyService.Resolve<IAuthService>();

            _viewModel = new SignInViewModel( Navigation,authService );

            BindingContext = _viewModel;

            //MessagingCenter.Instance.Subscribe<SignUpPage, User>(this, "storeUser", storeUser);

        }
    }
}

