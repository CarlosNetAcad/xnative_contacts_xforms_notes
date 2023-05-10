
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
using _00_Activities.src.Contacts.Domain.Entity;
using _00_Activities.src.Contacts.Domain.Service;
using Google.Android.Material.FloatingActionButton;

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

            //-> Database connection
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(folderPath, DatabaseName);

            _database = new SQLiteConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);

            var tables = new Type[]
            {
                typeof(Contact),
                typeof(Profile)
            };

            _database.CreateTables( CreateFlags.None, tables );
            //database.CreateTables(CreateFlags.None, typeof(Contact), typeof(Profile));

            var btnAddContact = FindViewById<FloatingActionButton>( Resource.Id.fab_contacts);
            var recyclerView  = FindViewById<RecyclerView>( Resource.Id.contacts_recyclerView );
            //var toolBar       = FindViewById<Toolbar>( Resource.Id.toolbar );
            var layoutManager = new LinearLayoutManager(this);

			recyclerView.AddItemDecoration( new DividerItemDecoration( this, DividerItemDecoration.Horizontal ) );
			recyclerView.SetLayoutManager( layoutManager );

            //SetSupportActionBar(toolBar);

            _contacts = _database.Table<Contact>().ToList();

            /*
            _contacts = new List<Contact>(); 
            for (var i = 0; i < 100; i++)
            {
                _contacts.Add(new Contact
                {
                    FullName = $"Carlos Test {i}",
                    Phone    = $"982-233-33-3{i}"
                });
            }
            */

            _adapter			 = new ContactAdapter( _contacts );

			_adapter.ItemClicked += OnItemClicked;

			recyclerView.SetAdapter( _adapter );

        }

        protected override void OnResume()
        {
            base.OnResume();

            _contacts = _database.Table<Contact>().ToList();

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
    }
}