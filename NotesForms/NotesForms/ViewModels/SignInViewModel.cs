using System;
using System.ComponentModel;
using System.Windows.Input;
using NotesForms.ViewModels.Base;
using NotesForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using NotesForms.Pages;
using System.Threading.Tasks;

namespace NotesForms.ViewModels
{
	public class SignInViewModel : BaseVM
	{
        #region Attributes

        string _username;
        string _password;

        readonly INavigation _navigation;
        readonly IAuthService _auth;

        #endregion attributes

        #region Properties
        public ICommand SignInCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }
        
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        #endregion Properties

        #region constructors
        
        public SignInViewModel( INavigation navigation, IAuthService auth )
        {
            _navigation = navigation;
            _auth       = auth;

            SignInCommand = new Command( async () => await OnSignInCommand() );

            SignUpCommand = new Command(OnSignUpCommand);
        }
        #endregion constructors

        #region private methods
        async Task OnSignInCommand()
        {
            Console.WriteLine($"Params: {Username} {Password}");

            var isLogin = await _auth.SignInAsync(Username,Password);

            Console.WriteLine($"Log resutl: {isLogin}");

            if (isLogin)
            {
                var app = App.Current as App;
                app.SetUsername( Username );
                app.SignIn();
            }
            else Console.WriteLine("Err ");
        }

        void OnSignUpCommand()
        {
            var signUpPage = new SignUpPage();
            _navigation.PushAsync( signUpPage );
        }

        #endregion private methods

        #region public methods
        public void SignIn()

        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password: {Password}");
        }
        /// <summary>
        /// @deprecated by async method
        /// </summary>
        public void SignInPlus()
        {
            var app = App.Current as App;
            app.SetUsername(Username);
            app.SignIn();
        }
        #endregion public methods
    }
}

