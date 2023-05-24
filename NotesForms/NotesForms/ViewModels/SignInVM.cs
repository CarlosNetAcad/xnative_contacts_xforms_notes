using System;
using System.ComponentModel;
using System.Windows.Input;
using NotesForms.ViewModels.Base;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
	public class SignInVM : BaseVM
	{
        public event PropertyChangedEventHandler PropertyChanged;

        private string _username;

        private string _password;

        public ICommand SignInCommand { get; private set; }

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

        public SignInVM()
        {
            SignInCommand = new Command(SignInPlus);
        }

        private void OnSignInCommand()
        {
            Console.WriteLine($"OnSignInCommand...");
        }

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
    }
}

