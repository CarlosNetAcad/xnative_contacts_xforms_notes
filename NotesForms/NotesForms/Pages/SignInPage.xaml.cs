using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository.SQLite;

namespace NotesForms.Pages
{	
	public partial class SignInPage : ContentPage
	{	
		public SignInPage ()
		{
            InitializeComponent();

            MessagingCenter.Instance.Subscribe<SignUpPage, User>(this, "storeUser", storeUser);

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

        void storeUser( SignUpPage sender, User User )
        {
            try
            {
                var AlreadyExistUser = Connection.Instance.Find<User>( User.UserName );

                if (AlreadyExistUser != null)
                    throw new Exception( "User already exist" );

                var stored = Connection.Instance.Insert( User );

                Console.WriteLine( $"User stored successfuly {stored.ToString()}");
            }
            catch ( Exception Ex)
            {
                Console.WriteLine( Ex.Message);
            }
        }
    }
}

