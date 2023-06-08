using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesForms;
using NotesForms.Pages;
using NotesForms.Services;
using NotesForms.Repository;
using System.Diagnostics;

namespace NotesForms
{
    public partial class App : Application, IPreferenceService
    {
        #region __constructor
        /// <summary>
        /// This is the constructor
        /// ID string generated is "M:NotesForms.App.#ctor"
        /// </summary>
        public App ()
        {
            InitializeComponent();

            //-> Register services
            DependencyService.RegisterSingleton<INoteService>( new SQLiteRepository() );
            DependencyService.RegisterSingleton<IArticleService>( new APIRepository() );
            DependencyService.RegisterSingleton<IAuthService>( new AuthService() );
            DependencyService.RegisterSingleton<IUserService>( new UserService() );
            DependencyService.RegisterSingleton<IGeolocation>( new GeoLocationService() );

            MainPage = new NavigationPage( new SignInPage() );
        }
        #endregion __constructor

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
        /// <summary>
        /// App lifecycle, used when the app starts.
        /// ID string generated is "M:NotesForms.App.OnStart"
        /// </summary>
        protected override void OnStart ()
        {
            var isLoggedIn = GetUsername();
            Console.WriteLine( "OnStart...." );
            Debug.WriteLine( isLoggedIn );
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
        
        public void __Set(string key, string value)
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

        public string __Get(string key)
        {
            var existKey = Properties.TryGetValue( key, out object value );

            if (existKey) return value as string;

            return string.Empty;
        }

        public void __UnSet(string key)
        {
            Properties.Remove( key );
        }

        public void SetUsername(string username)
        {
            __Set("username", username);
        }

        public string GetUsername()
        {
            return __Get("username");
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

