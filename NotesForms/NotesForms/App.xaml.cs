using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesForms;
using NotesForms.Pages;
using NotesForms.Services;
using NotesForms.Repository;

namespace NotesForms
{
    public partial class App : Application
    {
        /// <summary>
        /// The <c>isLoggedIn</c> is ised to know the logged user state and the data persist on the app
        /// ID string
        /// </summary>
        /// <param  name="isLoggedIn"></param>
        void SetIsLogin(bool isLoggedIn)
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

        /// <summary>
        /// This is the constructor
        /// ID string generated is "M:NotesForms.App.#ctor"
        /// </summary>
        public App ()
        {
            InitializeComponent();

            //-> Register services
            DependencyService.RegisterSingleton<INoteService>( new MockNoteRepository() );

            MainPage = new NavigationPage( new SignInPage() );
        }

        /// <summary>
        /// App lifecycle, used when the app starts.
        /// ID string generated is "M:NotesForms.App.OnStart"
        /// </summary>
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

        /// <summary>
        /// App lifecycle, used when the app go to the background.
        /// ID string generated is "M:NotesForms.App.OnSleep"
        /// </summary>
        protected override void OnSleep ()
        {
        }

        /// <summary>
        /// App lifecycle, used when the app return from de background
        /// ID string generated is "M:NotesForms.App.OnResume"
        /// </summary>
        protected override void OnResume()
        {
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

