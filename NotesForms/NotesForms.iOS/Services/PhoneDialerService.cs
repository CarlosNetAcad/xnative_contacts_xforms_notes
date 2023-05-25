using System;
using NotesForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency( typeof( PhoneDialer ) )]
namespace NotesForms.iOS.Services
{
	public class PhoneDialerService:IPhoneDialer
	{
        public void MakeCall(string phoneNumber)
        {
            Console.WriteLine($"Calling from ios: {phoneNumber}");
        }
    }
}

