
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
using Newtonsoft.Json;
using SQLite;
using AndroidX.AppCompat.App;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository;

namespace _00_Activities
{
	[Activity (
		Label = "ContactDetailActivity"
	)]			
	public class ContactDetailActivity : AppCompatActivity
	{
		const string DatabaseName = "contacts.db3";

		SQLiteConnection _database;

        Contact _contact;

        private bool exist = false;

		private EditText _txtContactFullNameUI,
						_txtContactPhoneUI;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView( Resource.Layout.contact_detail_layout );

            var folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(folderPath, DatabaseName);
            _database = new SQLiteConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

			var tables = new Type[]
            {
                typeof(Contact),
                typeof(Profile)
            };

            _database.CreateTables(CreateFlags.None, tables);

            _txtContactFullNameUI  = FindViewById<EditText>( Resource.Id.txt_contactFullName_ui );
			_txtContactPhoneUI     = FindViewById<EditText>( Resource.Id.txt_contactPhone_ui );

			string contactJSON = Intent?.GetStringExtra( "contact_json" );

            if (contactJSON != null)
            {
                _contact = JsonConvert.DeserializeObject<Contact>(contactJSON);
                exist = true;
            }
            else
                _contact = new Contact();

            _txtContactFullNameUI.Text = _contact.FullName;
			_txtContactPhoneUI.Text    = _contact.Phone;
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu._nav_contact_detail, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.contact_save:
                    SaveContact();
                    return true;
                case Resource.Id.contact_delete:
                    DeleteContact();
                    OnBackPressed();
                    return true;
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        [Obsolete]
        private void SaveContact()
        {
            try
            {
                if( exist )
                {
                    _contact.FullName   = _txtContactFullNameUI.Text;
                    _contact.Phone      = _txtContactPhoneUI.Text;

                    Connection.Instance.Update( _contact );
                }
                else
                {
                    Connection.Instance.Insert(new Contact()
                    {
                        FullName        = _txtContactFullNameUI.Text,
                        Phone           = _txtContactPhoneUI.Text,
                    });
                }

                OnBackPressed();
            }
            catch (SQLite.SQLiteException sql)
            {
                if (sql.Message.Contains("UNIQUE"))
                {
                    Toast.MakeText(this, "Contact Phone already exists", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Ops something went wrong {ex.Message}", ToastLength.Long).Show();
            }
        }

        private void DeleteContact()
        {
            try
            {
                if (!exist)
                    throw new Exception("Cannot find the contact to delete it.");

                Connection.Instance.Delete( _contact );

                OnBackPressed();
            }
            catch (SQLite.SQLiteException sql)
            {
                if (sql.Message.Contains("UNIQUE"))
                {
                    Toast.MakeText(this, "Contact Phone already exists", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, $"Ops something went wrong {ex.Message}", ToastLength.Long).Show();
            }
        }
    }
}

