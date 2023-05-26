using System;
using System.Windows.Input;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository;
using NotesForms.ViewModels.Base;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
	public class SignUpViewModel:BaseVM
	{
        #region Attr
        string _userName;

        string _passWord;

        string _fullName;

        bool _canCreateAccount;

        readonly INavigation _navigation;
        #endregion Attr

        #region Prop
        public ICommand CmdStore { get; private set; }

        public string UserName
        {
            get => _userName;
            set => SetProperty( ref _userName,value );
        }

        public string PassWord
        {
            get => _passWord;
            set => SetProperty( ref _passWord,value );
        }

        public string FullName
        {
            get => _fullName;
            set => SetProperty( ref _fullName, value );
        }

        public bool CanCreateAccount
        {
            get => _canCreateAccount;
            set => SetProperty( ref _canCreateAccount,value );
        }

        
        #endregion Prop

        #region __constructors
        public SignUpViewModel( INavigation navigation )
		{
            _navigation = navigation;

            CmdStore = new Command( StoringUser );
		}
        #endregion __constructors

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
            Console.WriteLine( $"The user {UserName} was stored" );
            _navigation.PopAsync();
        }
        #endregion methods
    }
}

