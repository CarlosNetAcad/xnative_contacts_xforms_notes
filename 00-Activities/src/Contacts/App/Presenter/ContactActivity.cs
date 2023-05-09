
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
using AndroidX.RecyclerView.Widget;
using _00_Activities.src.Contacts.Domain.Entity;
using _00_Activities.src.Contacts.Domain.Service;

namespace _00_Activities
{
	[Activity (
		Label = "ContactsActivity",
		MainLauncher = true

	)]			
	public class ContactsActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//-> Render the layout
			SetContentView( Resource.Layout.contact_index_layout );

			var recyclerView  = FindViewById<RecyclerView>( Resource.Id.frg_contact_list );
			var layoutManager = new LinearLayoutManager(this);

			recyclerView.SetLayoutManager( layoutManager );

			var contacts = new List<Contact>();

            for (var i = 0; i < 100; i++)
            {
                contacts.Add(new Contact
                {
                    FullName = $"Carlos Test {i}",
                    Phone    = $"982-233-33-3{i}"
                });

            }

			var adapter = new ContactAdapter( contacts );

			recyclerView.SetAdapter( adapter );


        }


	}
}

