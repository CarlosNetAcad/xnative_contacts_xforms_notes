
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
using AndroidX.RecyclerView.Widget;
using Google.Android.Material.FloatingActionButton;
using MvvmCross.DroidX.RecyclerView;

namespace _00_Activities
{
	[Activity (Label = "ContactDetailActivity")]			
	public class XContactsActivity : MvxActivity<ContactsViewModel>
	{

        private void OnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ContactDetailActivity));
            StartActivity(intent);
        }

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView( Resource.Layout.contact_index_layout);

            var floatingBtn = FindViewById<FloatingActionButton>(Resource.Id.fab_contacts);
            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.contacts_recyclerView);
            recyclerView.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Horizontal));
            var layoutManager = new LinearLayoutManager(this);
            //var layoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            floatingBtn.Click += OnClick;
            recyclerView.SetLayoutManager(layoutManager);
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
                ViewModel.ContactSelectedCommand.Execute(null);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void OnItemClicked(int position)
        {
            /*
			var contactSelected = _contacts[position];
			var json = JsonConvert.SerializeObject(contactSelected);
			Console.WriteLine($"Contact selcted: {contactSelected?.Fullname}");
			var intent = new Intent(this, typeof(ContactDetailActivity));
			intent.PutExtra("contact", json);
			StartActivity(intent);
            */
        }
    }
}

