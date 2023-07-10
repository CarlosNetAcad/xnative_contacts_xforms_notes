using System;
using MvvmCross.ViewModels;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using ContactApp.Core.Entities;
using MvvmCross.Commands;
using System.Threading.Tasks;
using ContactApp.Core.Repository.SQLite;

namespace Contacts.MvvmCross.Core.ViewModels
{
	public class ContactDetailViewModel: MvxNavigationViewModel, IMvxViewModel<Contact>
    {
        private async Task OnDeleteHandler()
        {
            if( _exist)
            {
                Connection.Instance.Delete(_contact);
            }

            await NavigationService.Close(this);

        }

        private async Task OnSaveHandler()
        {
            try
            {
                if (_exist )
                {
                    _contact.FullName   = FullName;
                    _contact.Phone      = PhoneNumber;
                    Connection.Instance.Update(_contact);
                }
                else
                {
                    Connection.Instance.Insert(new Contact()
                    {
                        FullName= FullName,
                        Phone   = PhoneNumber
                    });
                }

                await NavigationService.Close(this);
            }
            catch (SQLite.SQLiteException sql)
            {
                if (sql.Message.Contains("UNIQUE"))
                {
                    //Toast.MakeText(this, "Contact Phone already exists", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                // Toast.MakeText(this, $"Ops something went wrong {ex.Message}", ToastLength.Long).Show();
            }
        }


        public ContactDetailViewModel(
			ILoggerFactory logFactory,
			IMvxNavigationService navigationService
		) :base( logFactory, navigationService)
		{
            SaveCommand     = new MvxAsyncCommand( OnSaveHandler );
            DeleteCommand   = new MvxAsyncCommand( OnDeleteHandler );
		}

        public void Prepare(Contact parameter)
        {
            if( parameter == null)
            {
                _exist      = false;
                _contact    = new Contact();
            }
            else
            {
                _exist      = true;
                _contact    = parameter;
            }
        }

        #region Props

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        public IMvxAsyncCommand SaveCommand { get; private set; }

        public IMvxAsyncCommand DeleteCommand { get; private set; }

        #endregion Props

        #region Flds
        Contact _contact;
        bool _exist = false;
        string _fullName;
        string _phoneNumber;
        #endregion Flds
    }
}

