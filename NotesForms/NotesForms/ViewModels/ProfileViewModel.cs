using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NotesForms.Services;
using NotesForms.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
	public class ProfileViewModel:BaseVM
	{
        #region attributes
        string _username;
        string _text;
        string _phoneNumber;
        readonly IPhoneDialer _phoneDialer;
        #endregion attributes

        #region Properties
        public ICommand SignOutCommand { get; private set; }

        public ICommand MakeCallCommand { get; private set; }

        public ICommand ReadAndSpeakCommand { get; private set; }

        public string Username
        {
            get => _username;
            set => SetProperty( ref _username, value );
        }

        public string Text
        {
            get => _text;
            set => SetProperty( ref _text, value );
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty( ref _phoneNumber, value );
        }
        #endregion Properties

        #region constructor
        public ProfileViewModel( IPhoneDialer phoneDialer )
		{
            _phoneDialer = phoneDialer;
            SignOutCommand = new Command( OnSignOutCommand );
            MakeCallCommand = new Command( OnMakeCallCommand );
            ReadAndSpeakCommand = new Command(async () => await OnSpeakCommand());
        }
        #endregion constructor

        #region private methods

        void OnSignOutCommand()
        {
            var app = App.Current as App;

            app.SignOut();
        }

        void OnMakeCallCommand()
        {
            //-> 2378838888
            Console.WriteLine($"Dialing to: {PhoneNumber}");
            _phoneDialer.MakeCall(PhoneNumber);
        }

        async Task OnSpeakCommand()
        {
            await TextToSpeech.SpeakAsync(Text);
        }
        #endregion private methods


    }
}

