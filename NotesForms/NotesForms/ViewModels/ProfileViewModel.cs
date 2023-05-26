using System;
using System.Collections.Generic;
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
        string _emailAddress;
        string _welcomeText;

        readonly IPhoneDialer _phoneDialer;
        readonly ISMS _sMS;
        readonly IEmail _eMail;
        readonly ITextToSpeech _textToSpeech;

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

        public string EmailAddress
        {
            get => _emailAddress;
            set => SetProperty( ref _emailAddress, value );
        }

        public string WelcomeText
        {
            get => _welcomeText;
            set => SetProperty( ref _welcomeText, value);
        }

        #endregion Properties

        #region constructor
        public ProfileViewModel(
            IPhoneDialer phoneDialer,
            ISMS sMS,
            IEmail eMail,
            ITextToSpeech textToSpeech
        )
		{
            _phoneDialer    = phoneDialer;
            _sMS            = sMS;
            _eMail          = eMail;
            _textToSpeech   = textToSpeech;

            var app = App.Current as App;
            Username = app.GetUsername();

            WelcomeText = $"Welcome {Username}";

            SignOutCommand      = new Command( OnSignOutCommand );
            MakeCallCommand     = new Command( OnMakeCallCommand );
            ReadAndSpeakCommand = new Command( SpeakingText );
            SendSMSCommand      = new Command( SendingSMS );
            SendEmailCommand    = new Command( SendingEmail );
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
        /// <summary>
        /// @recommended by Xamarin use a concrete class to implement a essential feature
        /// </summary>
        /// <returns></returns>
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

        void SpeakingText()
        {
            string textToSpeak = Text;

            _textToSpeech.SpeakAsync( textToSpeak );

        }

        void SendingEmail()
        {
            string subject  = "This is a test";
            string body     = Text;
            List<string> to = new List<string>() { EmailAddress } ;

            _eMail.SendEmailMessage( subject, body, to );
        }
        #endregion private methods


    }
}

