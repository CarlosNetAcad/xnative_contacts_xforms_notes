
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

namespace _00_Activities
{
	[Activity (
		Label = "NavigationByExplicitIntent"
	)]			
	public class NavigationByExplicitIntent : Activity
	{
        /**
		* Text View Element 
		*/
        TextView _lblCountClickUI;

		/**
        * Text View Element 
        */
        EditText _txtMessageUI;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

            //->Layout to render
            SetContentView(Resource.Layout.second_navigation);

			_lblCountClickUI = ( TextView )FindViewById( Resource.Id.lbl_clickCounts_ui );
			_txtMessageUI    = ( EditText )FindViewById( Resource.Id.txt_message_ui );

			//-> Get inputs
			string message = Intent.GetStringExtra( "message" );
			int clickCounts= Intent.GetIntExtra( "clickCounts",0 );

			_txtMessageUI.Text    = message;
            _lblCountClickUI.Text = clickCounts.ToString();
        }
	}
}

