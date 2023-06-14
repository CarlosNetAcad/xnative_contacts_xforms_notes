using System;
using Android.App;
using Android.Content;
using NotesForms.Services;
using NotesForms.Droid.Services;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace NotesFormsCarlos.Droid
{
    public class DroidInitializer : IPlatformInitializer
    {
        Context _context;

        public DroidInitializer(Context context)
        {
            _context = context;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPhoneDialer>(() => new PhoneDialerService( _context ));
        }
    }
}
