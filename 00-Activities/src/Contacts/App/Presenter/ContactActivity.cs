
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using AndroidX.RecyclerView.Widget;
using _00_Activities.src.Contacts.Domain.Entity;
using _00_Activities.src.Contacts.Domain.Service;
using static Android.Icu.Text.Transliterator;


namespace _00_Activities.src.Contacts.App.Presenter
{
	[Activity (
		Label        = "ContactsActivity",
		MainLauncher = true
	)]			
	public class ContactsActivity : Activity
	{
		private List<Contact> _contacts = null;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//-> Render the layout
			SetContentView( Resource.Layout.contact_index_layout );

			var recyclerView  = FindViewById<RecyclerView>( Resource.Id.frg_contact_list );
			var layoutManager = new LinearLayoutManager(this);

			recyclerView.AddItemDecoration( new DividerItemDecoration( this, DividerItemDecoration.Horizontal ) );
			recyclerView.SetLayoutManager( layoutManager );

			_contacts = new List<Contact>();

            for (var i = 0; i < 100; i++)
            {
                _contacts.Add(new Contact
                {
                    FullName = $"Carlos Test {i}",
                    Phone    = $"982-233-33-3{i}"
                });
            }
            
            var adapter			 = new ContactAdapter( _contacts );

			adapter.ItemClicked += OnItemClicked;

			recyclerView.SetAdapter( adapter );

        }

		private void OnItemClicked( int position )
		{
            var contactSelected = _contacts[ position ];

            Console.WriteLine($"Contact FN: {contactSelected?.FullName}");
            Console.WriteLine($"Contact PH: {contactSelected?.Phone}");

            var json			= JsonConvert.SerializeObject( contactSelected );
            var intent			= new Intent( this, typeof( ContactDetailActivity ) );

            intent.PutExtra( "contact_json", json );

			StartActivity( intent );
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
    }
}

