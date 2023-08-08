using System;
using Android.App;
using Android.Content;
using ContactApp.Core.Interfaces;
using NotesForms.Droid.Services;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace NotesForms.Droid
{
	public class DroidInitializer : IPlatformInitializer
	{
		public DroidInitializer( Context context)
		{
            _context = context;
		}

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPhoneDialer>( () => new PhoneDialerService( _context ) );
        }

        #region Flds
        /// <summary>
        /// 
        /// </summary>
        Context _context;
        #endregion Flds
    }
}

