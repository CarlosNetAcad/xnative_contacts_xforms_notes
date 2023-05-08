
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
	[Activity (Label = "ActivityTwo")]			
	public class ActivityTwo : Activity
	{
        EditText _editText = null;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

            //->Layout to render
            SetContentView(Resource.Layout.activity_two);

            //result
            _editText = FindViewById<EditText>(Resource.Id.txt_response_ui);

            var btnGoHomeUI = FindViewById<Button>( Resource.Id.btn_goHome_ui );
            btnGoHomeUI.Click += GoHomeHandler;
        }

        private void GoHomeHandler(object sender, EventArgs e)
        {
            var message = _editText.Text + " Activity 2";
            var intent = new Intent();
            intent.PutExtra("message", message);
            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}

