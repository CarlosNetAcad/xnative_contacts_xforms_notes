using System;
using System.Linq;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using ContactApp.Core.Interfaces;
using ContactApp.Core.Services;
using NotesForms.ViewModels;
using Prism;
using Prism.Ioc;
using Prism.DryIoc;

namespace NotesForms
{
    public partial class App : PrismApplication
    {
        #region Ctors
        /// <summary>
        /// This is the constructor
        /// ID string generated is "M:NotesForms.App.#ctor"
        /// </summary>
        public App () : this(null) {}

        public App( IPlatformInitializer initializer)
            : this(initializer, true) {}

        public App( IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver) { }
        #endregion Ctors

        #region - methods
        /// <summary>
        /// The <c>isLoggedIn</c> is ised to know the logged user state and the data persist on the app
        /// ID string
        /// </summary>
        /// <param  name="isLoggedIn"></param>
        /*void SetIsLogin(bool isLoggedIn)
        {
            if (this.Properties.ContainsKey("isLoggedIn"))
            {
                this.Properties["isLoggedIn"] = isLoggedIn;
            }
            else
            {
                this.Properties.Add("isLoggedIn", isLoggedIn);
            }
        }*/
        #endregion - methods

        #region # methods
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"NavigationPage/{nameof(AppL)}");
        }

        /// <summary>
        /// App lifecycle, used when the app starts.
        /// ID string generated is "M:NotesForms.App.OnStart"
        /// </summary>
        protected override void OnStart ()
        {
            var isLoggedIn = GetUsername();
            if (String.IsNullOrEmpty(isLoggedIn)) SignOut();
            else SignIn();

        }

        /// <summary>
        /// App lifecycle, used when the app go to the background.
        /// ID string generated is "M:NotesForms.App.OnSleep"
        /// </summary>
        protected override void OnSleep () {}

        /// <summary>
        /// App lifecycle, used when the app return from de background
        /// ID string generated is "M:NotesForms.App.OnResume"
        /// </summary>
        protected override void OnResume() {}
        #endregion # methods

        #region + methods
        
        public void Set(string key, string value)
        {
            if (this.Properties.ContainsKey( key ))
            {
                this.Properties[key] = value;
            }
            else
            {
                this.Properties.Add( key, value );
            }
        }

        public string Get(string key)
        {
            var existKey = Properties.TryGetValue( key, out object value );

            if (existKey) return value as string;

            return string.Empty;
        }

        public void UnSet(string key)
        {
            Properties.Remove( key );
        }

        public void SetUsername(string username)
        {
            Set("username", username);
        }

        public string GetUsername()
        {
            return Get("username");
        }

        public void SignIn()
        {
            MainPage = new MenuTabbedPage();
        }

        public void SignOut()
        {
            MainPage = new NavigationPage(new SignInPage());
        }

        #endregion + methods
    }
}

