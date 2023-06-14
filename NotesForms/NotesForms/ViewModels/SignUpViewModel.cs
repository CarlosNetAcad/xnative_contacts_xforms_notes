using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository;
using NotesForms.Services;
using NotesForms.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
    public class SignUpViewModel : BaseVM
    {
        #region Attr
        string _userName;

        string _passWord;

        string _fullName;

        bool _canCreateAccount;

        readonly INavigationService _navigation;
        readonly IUserService _userService;
        #endregion Attr

        #region Prop
        public ICommand CmdStore { get; private set; }
        public ICommand CmdLongPress { get; private set; }
        public ICommand CmdLong2Pres { get; private set; }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string PassWord
        {
            get => _passWord;
            set => SetProperty(ref _passWord, value);
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                SetProperty(ref _fullName, value);

                if (!string.IsNullOrEmpty(_fullName) && _fullName.Length >= 5)
                    CanCreateAccount = true;
                else
                    CanCreateAccount = false;
            }
        }

        public bool CanCreateAccount
        {
            get => _canCreateAccount;
            set => SetProperty(ref _canCreateAccount, value);
        }

        #endregion Prop

        #region Ctors
        public SignUpViewModel(
            INavigationService navigation,
            IUserService userService)
        {
            _navigation  = navigation;
            _userService = userService;

            CmdStore        = new DelegateCommand( async () => await OnCreateCommand() );
            CmdLongPress    = new DelegateCommand( PressingLong );
            CmdLong2Pres    = new DelegateCommand( PressingLongTwo );
        }
        #endregion Ctors

        #region methods
        void StoringUser()
        {
            var User = new User()
            {
                UserName = this.UserName,
                PassWord = this.PassWord,
                FullName = this.FullName
            };

            //-> Store in repo
            var result = _userService.Store(User);
            Console.WriteLine($"The user {UserName} was stored {result}");
            _navigation.GoBackAsync();
        }

        void PressingLong()
        {
            Console.WriteLine("Long press from view model");
        }

        void PressingLongTwo()
        {
            Console.WriteLine("Long press from view model 2");
        }

        private async Task OnCreateCommand()
        {
            var User = new User()
            {
                UserName = this.UserName,
                PassWord = this.PassWord,
                FullName = this.FullName
            };
            var result = _userService.Store(User);
            await _navigation.GoBackAsync();
        }
        #endregion methods
    }
}

