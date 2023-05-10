
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
using _00_Activities.src.Contacts.Domain.Entity;

namespace _00_Activities
{
	[Activity (
		Label = "ContactDetailActivity"
	)]			
	public class ContactDetailActivity : Activity
	{
		private EditText _txtContactFullNameUI,
						_txtContactPhoneUI;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView( Resource.Layout.contact_detail_layout );

			_txtContactFullNameUI  = FindViewById<EditText>( Resource.Id.txt_contactFullName_ui );
			_txtContactPhoneUI     = FindViewById<EditText>( Resource.Id.txt_contactPhone_ui );

			string contactJSON = Intent?.GetStringExtra( "contact_json" );
			
			var contact        =JsonConvert.DeserializeObject<Contact>( contactJSON );

			_txtContactFullNameUI.Text = contact?.FullName.ToString();
			_txtContactPhoneUI.Text    = contact?.Phone.ToString();
		}
	}
}

