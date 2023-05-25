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
        readonly ISMS _sMS;
        readonly IEmail _eMail;

        #endregion attributes

        #region Properties
        public ICommand SignOutCommand { get; private set; }

        public ICommand MakeCallCommand { get; private set; }

        public ICommand ReadAndSpeakCommand { get; private set; }

        public ICommand SendSMSCommand { get; private set; }

        public ICommand SendEmailCommand { get; private set; }

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
        public ProfileViewModel(
            IPhoneDialer phoneDialer,
            ISMS sMS,
            IEmail eMail
        )
		{
            _phoneDialer = phoneDialer;
            _sMS = sMS;
            _eMail = eMail;

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

        void SendingSMS()
        {
            try
            {
                string message = Text;
                string phoneNumber = PhoneNumber;

                _sMS.SendSMSAsync( message, phoneNumber );
                
            }
            catch( FeatureNotSupportedException FNSex) { }
            catch( Exception ex ) { }
        }

        #endregion private methods


    }
}

