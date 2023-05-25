using System;
using System.Threading.Tasks;
using Android.Content;
using NotesForms.Services;
using Xamarin.Essentials;

namespace NotesForms.Droid.Services
{
	public class SMSService : ISMS
	{
        public Context Context { get; set; }

        public async Task SendSMSAsync(string messageText, string recipient)
        {
            try {
                var message = new SmsMessage( messageText, new[] {recipient});
                await Sms.ComposeAsync( message );
            }
            catch ( FeatureNotSupportedException FNSEx) { }
            catch ( Exception Ex) { }
        }
    }
}