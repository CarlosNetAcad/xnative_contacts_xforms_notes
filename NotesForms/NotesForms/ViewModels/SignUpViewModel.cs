using System;
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
        public SignUpViewModel()
		{
		}
        #endregion __constructors

        #region methods

        #endregion methods
    }
}

