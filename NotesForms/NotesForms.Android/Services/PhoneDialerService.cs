using System;
using Android.Content;
using ContactApp.Core.Interfaces;

namespace NotesForms.Droid.Services
{
	public class PhoneDialerService:IPhoneDialer
	{
        public Context Context { get; set; }

        public PhoneDialerService(Context context)
        {
            Context = context;
        }

        public void MakeCall(string phoneNumber)
        {
            try
            {
                var intent = new Intent( Intent.ActionCall );

                intent.SetData( Android.Net.Uri.Parse( $"tel:{phoneNumber}" ) );

                Context.StartActivity( intent );
            }
            catch(Exception Ex)
            {
                Console.WriteLine( Ex.Message );
            }
        }
    }
}

