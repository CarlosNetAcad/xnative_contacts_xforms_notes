using System;
using System.ComponentModel;
using System.Windows.Input;
using NotesForms.ViewModels.Base;
using NotesForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using NotesForms.Pages;
using System.Threading.Tasks;
using Prism.Services;
using Prism.Navigation;

namespace NotesForms.ViewModels
{
	public class SignInViewModel : BaseVM
	{
        #region Attributes

        string _username;
        string _password;

        readonly INavigationService _navigation;
        readonly IAuthService _auth;
        readonly IPageDialogService _pageDialogService;

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
        
        public SignInViewModel(
            INavigationService navigation,
            IAuthService auth,
            IPageDialogService dialogPageService)
        {
            _navigation         = navigation;
            _auth               = auth;
            _pageDialogService  = dialogPageService;

            PageTitle = "Notes App";

            SignInCommand = new Command( async () => await OnSignInCommand() );

            SignUpCommand = new Command( async () => await OnSignUpCommand() );
        }
        #endregion constructors

        #region private methods
        async Task OnSignInCommand()
        {
            var isLogin = await _auth.SignInAsync(Username,Password);

            if( isLogin )
            {
                await _navigation.NavigateAsync(
                                     $"root:///{nameof(MenuViewModel)}" +
                                     $"?createTab=NavigationPage|{nameof(NoteViewModel)}" +
                                     $"&createTab=NavigationPage|{nameof(MapViewModel)}" +
                                     $"&createTab=NavigationPage|{nameof(ArticleViewModel)}" +
                                     $"&createTab=NavigationPage|{nameof(ProfileViewModel)}" +
                                     $"&createTab=NavigationPage|{nameof(SettingsViewModel)}");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Ops","Error de auth","OK");
            }
        }

        async Task OnSignUpCommand()
        {
            await _navigation.NavigateAsync( nameof(SignUpViewModel) );
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
            /*var app = App.Current as App;
            app.SetUsername(Username);
            app.SignIn();*/
        }
        #endregion public methods
    }
}

