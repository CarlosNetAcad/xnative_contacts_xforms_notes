using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesForms;
using NotesForms.Pages;

namespace NotesForms
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new SignInPage() );
        }

        protected override void OnStart ()
        {
            if (this.Properties.ContainsKey("isLoggedIn"))
            {
                var isLoggedIn = (bool)this.Properties["isLoggedIn"];

                if (isLoggedIn)
                    SignIn();
                else
                    SignOut();
            }
            else
                SignOut();
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }

        void SetIsLogin( bool isLoggedIn)
        {
            if (this.Properties.ContainsKey("isLoggedIn"))
            {
                this.Properties["isLoggedIn"] = isLoggedIn;
            }
            else
            {
                this.Properties.Add("isLoggedIn", isLoggedIn);
            }
        }

        public void SetUsername(string username)
        {
            if (this.Properties.ContainsKey("username"))
            {
                this.Properties["username"] = username;
            }
            else
            {
                this.Properties.Add("username", username);
            }
        }

        public string GetUsername()
        {
            if (this.Properties.ContainsKey("username"))
            {
                var username = (string)this.Properties["username"];
                return username;
            }

            return string.Empty;
        }

        public void SignIn()
        {
            SetIsLogin(true);
            MainPage = new MenuTabbedPage();
        }


        public void SignOut()
        {
            SetIsLogin(false);
            MainPage = new NavigationPage( new SignInPage() );
        }
    }
}

