using System;
using Android.Content;
using NotesForms.Services;

namespace NotesForms.Droid.Services
{
	public class PhoneDialerService:IPhoneDialer
	{
        public Context Context { get; private set; }

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

