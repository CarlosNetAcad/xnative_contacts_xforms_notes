using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using NotesForms.Services;
using Xamarin.Essentials;

namespace NotesForms.Droid.Services
{
    public class EmailService : IEmail
    {
        public Context Context;

        public async Task SendEmailMessage(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    }
}

