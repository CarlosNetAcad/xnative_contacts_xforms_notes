using System;
using System.ComponentModel;
using System.Windows.Input;
using NotesForms.ViewModels.Base;
using NotesForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
	public class SignInVM : BaseVM
	{
        #region Attributes

        string _username;

        string _password;

        //->Declared in parent
        //public event PropertyChangedEventHandler PropertyChanged;
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
        
        public SignInVM()
        {
            SignInCommand = new Command(SignInPlus);
        }
        #endregion constructors

        #region private methods
        void OnSignInCommand()
        {
            var app = App.Current as App;

            app.SignIn();
        }

        void OnSignUpCommand()
        {

        }

        #endregion private methods

        #region public methods
        public void SignIn()

        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password: {Password}");
        }

        public void SignInPlus()
        {
            var app = App.Current as App;
            app.SetUsername(Username);
            app.SignIn();
        }
        #endregion public methods
    }
}

