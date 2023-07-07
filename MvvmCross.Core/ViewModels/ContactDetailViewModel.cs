using System;
using MvvmCross.ViewModels;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;

namespace Contacts.MvvmCross.Core.ViewModels
{
	public class ContactDetailViewModel: MvxNavigationViewModel
    {
		public ContactDetailViewModel(
			ILoggerFactory logFactory,
			IMvxNavigationService navigationService
		) :base( logFactory, navigationService)
		{
		}
	}
}

