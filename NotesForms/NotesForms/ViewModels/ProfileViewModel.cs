using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Core.Entities;
using NotesForms.Services;
using NotesForms.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
	public class ProfileViewModel:BaseVM
	{
        #region attributes
        string _userName;
        string _password;
        string _fullName;
        string _text;
        string _phoneNumber;
        string _emailAddress;
        string _welcomeText;
        //string _user;
        User   _user;

        readonly IPhoneDialer _phoneDialer;
        readonly ISMS _sMS;
        readonly IEmail _eMail;
        readonly ITextToSpeech _textToSpeech;
        readonly IAuthService _authService;
        readonly IUserService _userService;
        readonly INavigationService _navigationService;
        #endregion attributes

        #region Properties
        public ICommand SignOutCommand { get; private set; }

        public ICommand MakeCallCommand { get; private set; }

        public ICommand ReadAndSpeakCommand { get; private set; }

        public ICommand SendSMSCommand { get; private set; }

        public ICommand SendEmailCommand { get; private set; }

        public ICommand UpdateUserCmd { get; private set; }

        public string UserName
        {
            get => _userName;
            set => SetProperty( ref _userName, value );
        }

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
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
            ITextToSpeech textToSpeech,
            IAuthService authService,
            IUserService userService,
            INavigationService navigationService)
		{
            //-> Init props
            _phoneDialer        = phoneDialer;
            _sMS                = sMS;
            _eMail              = eMail;
            _textToSpeech       = textToSpeech;
            _authService        = authService;
            _userService        = userService;
            _navigationService  = navigationService;

            SetUser( _user );
            WelcomeText = $"Welcome {UserName}";

            //-> Auth Cmds
            //SignOutCommand      = new Command( async () => await SigningOutAsync() );
            SignOutCommand = new DelegateCommand( async () => await SigningOutAsync() );

            //-> App Essentials services Cmds
            //MakeCallCommand     = new Command( OnMakeCallCommand );
            MakeCallCommand     = new DelegateCommand( OnMakeCallCommand );

            //ReadAndSpeakCommand = new Command( SpeakingText );
            ReadAndSpeakCommand = new DelegateCommand( async () => await OnSpeakCommand() );

            //SendSMSCommand      = new Command( SendingSMS );
            SendSMSCommand      = new DelegateCommand( SendingSMS );

            //SendEmailCommand    = new Command( SendingEmail );
            SendEmailCommand    = new DelegateCommand( SendingEmail );

            //-> Manage User Cmds
            //UpdateUserCmd       = new Command( UpdatingUser );
            UpdateUserCmd       = new DelegateCommand( UpdatingUser );
        }
        #endregion constructor

        #region private methods
        /// <summary>
        /// @deprecated by async method
        /// </summary>
        void OnSignOutCommand()
        {
            //var app = App.Current as App;
            //app.SignOut();
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

        void UpdatingUser()
        {
            _user.UserName = UserName;
            _user.PassWord = Password;
            _user.FullName = FullName;

            _userService.Update( _user );
        }

        void SetUser( User user )
        {
            UserName = user?.UserName;
            Password = user?.PassWord;
            FullName = user?.FullName;
        }

        async Task SigningOutAsync()
        {
            /*
            var app = App.Current as App;
            await _authService.SignOutAsync();
            app.UnSet("username");
            app.SignOut();
            */
            await _authService.SignOutAsync();
            await _navigationService.NavigateAsync($"root:///NavigationPage/{nameof(SignInViewModel)}");
        }
        #endregion private methods


    }
}

