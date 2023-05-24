using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ContactApp.Core.Entities;

namespace NotesForms.Pages
{	
	public partial class SignUpPage : ContentPage
	{
		public User User { get; set; }

		public SignUpPage ()
		{
			InitializeComponent ();
		}

		void StoreUserHandler( System.Object sender, System.EventArgs e )
		{
			User = new User();

			User.UserName = txtUserName.Text;
			User.PassWord = txtPassword.Text;
			User.FullName = txtFullName.Text;

			MessagingCenter.Instance.Send(this, "storeUser", User);

			Navigation.PopAsync();
		}

    }
}

