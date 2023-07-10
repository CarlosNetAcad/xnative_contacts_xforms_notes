
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Google.Android.Material.FloatingActionButton;
using MvvmCross.Platforms.Android.Views;
using Newtonsoft.Json;
using ContactApp.Core.Entities;
using Contacts.MvvmCross.Core.ViewModels;
using _00_Activities.src.Contacts.Domain.Service;
using ContactApp.Core.Repository.SQLite;

namespace _00_Activities
{
	[Activity (Label = "Contacts", MainLauncher = false) ]			
	public class XContactsActivity : MvxActivity<ContactsViewModel>
	{
		/// <summary>
		/// 
		/// </summary>
		private List<Contact> _contacts = null;

		/// <summary>
		/// 
		/// </summary>
		private ContactAdapter _adapter;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="savedInstanceState"></param>
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView( Resource.Layout.contact_index_layout);

			var btnFloating		= FindViewById<FloatingActionButton>( Resource.Id.fab_contacts );
			var recyclerView	= FindViewById<RecyclerView>( Resource.Id.contacts_recyclerView );
			recyclerView.AddItemDecoration( new DividerItemDecoration(this, DividerItemDecoration.Horizontal) );
			var layoutManager	= new LinearLayoutManager( this );
			//var layoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);

			btnFloating.Click += GoContactDetail;
			recyclerView.SetLayoutManager( layoutManager );

			_contacts	= Connection.Instance.Table<Contact>().ToList();
			_adapter	= new ContactAdapter( _contacts );
			_adapter.ItemClicked += OnItemClicked;
		}

        protected override void OnResume()
        {
            base.OnResume();
			_contacts = Connection.Instance.Table<Contact>().ToList();
			_adapter.SetData( _contacts );
        }

		private void GoContactDetail( object sender, EventArgs e)
		{
			var intent = new Intent( this, typeof( ContactDetailActivity ) );
			StartActivity(intent);
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.new_contact)
            {
                var intent = new Intent(this, typeof(ContactDetailActivity));
                StartActivity(intent);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void OnItemClicked(int position)
        {
            var contactSelected = _contacts[position];
            var json = JsonConvert.SerializeObject(contactSelected);
            Console.WriteLine($"Contact selcted: {contactSelected?.FullName}");
            var intent = new Intent(this, typeof(ContactDetailActivity));
            intent.PutExtra("contact", json);
            StartActivity(intent);
        }
    }
}

