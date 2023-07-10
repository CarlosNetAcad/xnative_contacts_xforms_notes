
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using ContactApp.Core.Repository;
using ContactApp.Core.Entities;
using Contacts.MvvmCross.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;
using ContactApp.Core.Repository.SQLite;

namespace _00_Activities
{
	[Activity (Label = "ContactDetailActivity")]			
	public class XContactDetailActivity : MvxActivity<ContactDetailViewModel>
	{
		EditText _fullName		= null;
		EditText _phoneNumber	= null;
		Contact  _contact		= null;
		bool	 _exist			= false;
		
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView( Resource.Layout.contact_detail_layout);

			SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.Title = "Details";

			_phoneNumber = FindViewById<EditText>( Resource.Id.txt_contactPhone_ui);
			_fullName	 = FindViewById<EditText>( Resource.Id.txt_contactFullName_ui);

			var contactJson = Intent?.GetStringExtra("contact");

			if( contactJson != null )
			{
				_exist		= true;
				_contact = JsonConvert.DeserializeObject<Contact>( contactJson );
			}
			else
			{
				_contact = new Contact();
			}
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
			MenuInflater.Inflate( Resource.Menu._nav_contact_detail, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //return base.OnOptionsItemSelected(item);

			switch( item.ItemId )
			{
				case Resource.Id.contact_save:
					return true;
				case Resource.Id.contact_delete:
					return true;
				case Android.Resource.Id.Home:
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
        }

		private void DeleteContact()
		{
			if(_exist)
			{
				Connection.Instance.Delete(_contact);
			}
		}

		private void SaveContact()
		{
			try
			{
				if (_exist)
				{
					_contact.FullName	= _fullName.Text;
					_contact.Phone		= _phoneNumber.Text;
					Connection.Instance.Update( _contact );
				}
				else
				{
					Connection.Instance.Insert(new Contact()
					{
						FullName = _fullName.Text,
						Phone = _phoneNumber.Text,
					});
				}
			}
			catch ( SQLite.SQLiteException liteEx)
			{
				if( liteEx.Message.Contains("UNIQUE"))
				{
					Toast.MakeText(this, "Contact phone already exist", ToastLength.Long).Show();
				}
			}
			catch( Exception ex)
			{
				Toast.MakeText(this, $"Ops something went wrong{ex.Message}", ToastLength.Long).Show();
			}
		}
    }
}

