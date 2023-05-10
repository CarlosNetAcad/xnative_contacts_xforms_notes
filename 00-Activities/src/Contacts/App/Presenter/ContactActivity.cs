
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
using Newtonsoft.Json;
using AndroidX.RecyclerView.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using SQLite;
using static Android.Icu.Text.Transliterator;
using Environment = System.Environment;
using Google.Android.Material.FloatingActionButton;

using _00_Activities.src.Contacts.Domain.Entity;
using _00_Activities.src.Contacts.Domain.Service;
using _00_Activities.src.Contacts.Domain.Repository;

namespace _00_Activities.src.Contacts.App.Presenter
{
	[Activity (
		Label        = "ContactsActivity",
		MainLauncher = true
    )]			
	public class ContactsActivity : AppCompatActivity
	{
        const string DatabaseName = "contacts.db3";

        SQLiteConnection _database;

        ContactAdapter _adapter;

		private List<Contact> _contacts = null;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//-> Render the layout
			SetContentView( Resource.Layout.contact_index_layout );

            var btnAddContact = FindViewById<FloatingActionButton>( Resource.Id.fab_contacts);
            var recyclerView  = FindViewById<RecyclerView>( Resource.Id.contacts_recyclerView );
            var layoutManager = new LinearLayoutManager(this);

			recyclerView.AddItemDecoration( new DividerItemDecoration( this, DividerItemDecoration.Horizontal ) );
			recyclerView.SetLayoutManager( layoutManager );

            _contacts               = Connection.Instance.Table<Contact>().ToList();

            _adapter			    = new ContactAdapter( _contacts );

			_adapter.ItemClicked   += OnItemClicked;
            btnAddContact.Click += GoToDetailActivity;

			recyclerView.SetAdapter( _adapter );

        }

        protected override void OnResume()
        {
            base.OnResume();

            _contacts = Connection.Instance.Table<Contact>().ToList();

            if(_contacts != null)
                _adapter.SetData( _contacts );
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_new)
            {
                var intent = new Intent(this, typeof(ContactDetailActivity));
                StartActivity(intent);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        private void OnItemClicked(int position)
        {
            var contactSelected = _contacts[position];

            Console.WriteLine($"Contact FN: {contactSelected?.FullName}");
            Console.WriteLine($"Contact PH: {contactSelected?.Phone}");

            var json = JsonConvert.SerializeObject(contactSelected);
            var intent = new Intent(this, typeof(ContactDetailActivity));

            intent.PutExtra("contact_json", json);

            StartActivity(intent);
        }

        private void GoToDetailActivity( object sender, EventArgs e )
        {
            var intent = new Intent( this, typeof( ContactDetailActivity ) );
            StartActivity( intent );
        }
    }
}