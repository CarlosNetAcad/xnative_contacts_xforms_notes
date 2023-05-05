
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
		Label			= "Home",
		MainLauncher	= true
	)]			
	public class Home : Activity
	{
		/**
		* Text View Element 
		*/
		TextView _txtViewUI;

		/**
		 * Button Element 
		**/ 
		Button _btnIncrementClickUI;

        /**
		 * Button Element 
		**/
        Button _btnResetCountUI;

		/** 
		 * @summary To acummulate number of clicks
		 * @attribute int   
		*/
		private int _clicksAccumulator = 0;


		/**
		* @summary App life cycle
		* @param {Bundle} savedInstanceState
		**/
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//->Lounch packages
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

			//->Layout to render
            SetContentView(Resource.Layout.home);

			//->Binding UI elements
            _btnIncrementClickUI= FindViewById<Button>( Resource.Id.btnIncrementClickUI );
			_btnResetCountUI	= FindViewById<Button>( Resource.Id.btn_reset_UI);
			_txtViewUI			= FindViewById<TextView>( Resource.Id.lblResultUI );

			//->Trigering events
			_btnIncrementClickUI.Click	+= IncrementingClicks;
			_btnResetCountUI.Click		+= ResetingCount;

        }

		/**
		 * @method to increment +1 each time the user clic the button
		 * @param {object} sender
		 * @param {EventArgs} e
		 */
		private void IncrementingClicks( object sender, EventArgs e)
		{
			_clicksAccumulator++;

			PrintingResult();
		}

        /**
		 * @method to increment +1 each time the user clic the button
		 * @param {object} sender
		 * @param {EventArgs} e
		 */
        private void ResetingCount( object sender, EventArgs e)
		{
			_clicksAccumulator = 0;

			PrintingResult();
		}

        /**
		 * @method print the current _clicksAccumulator value 
		 * in the textView UI element
		 */
        private void PrintingResult()
		{
            _txtViewUI.Text = $"Clicks count = {_clicksAccumulator}";
        }
	}
}

