using System;
using NotesForms.Services;
using NotesForms.iOS.Services;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials;

namespace NotesForms.iOS
{
    public class IOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPhoneDialer, PhoneDialerService>();
        }
    }
}