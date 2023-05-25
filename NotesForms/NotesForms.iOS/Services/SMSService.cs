using System;
using System.Threading.Tasks;
using NotesForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly:Dependency(typeof( Sms ))]
namespace NotesForms.iOS.Services
{

	public class SMSService:ISMS
	{
        public async Task SendSMSAsync(string messageText, string recipient)
        {
            try {
                var message = new SmsMessage( messageText, new[] {recipient});
                await Sms.ComposeAsync( message );
            }
            catch ( FeatureNotSupportedException ex ) { }
            catch ( Exception ex ) { }
        }
    }
}

