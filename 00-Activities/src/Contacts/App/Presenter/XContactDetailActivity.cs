
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
	public class XContactDetailActivity : MvxActivity<ContactDetailViewModel>
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView( Resource.Layout.contact_detail_layout);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.Title = "Details";
		}

        protected override void OnResume()
        {
            base.OnResume();
			_contacts = Connection.Instance.Table<Contact>().ToList();
			_adapter.SetData( _contacts );
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.contact_save:
                    ViewModel.SaveCommand.Execute();
                    return true;
                case Resource.Id.contact_delete:
                    ViewModel.DeleteCommand.Execute();
                    return true;
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}

