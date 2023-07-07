using System;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Contacts.MvvmCross.Core.ViewModels
{
    public class ContactsViewModel : MvxNavigationViewModel
    {
        public ContactsViewModel(
            ILoggerFactory logFactory,
            IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }
    }
}

