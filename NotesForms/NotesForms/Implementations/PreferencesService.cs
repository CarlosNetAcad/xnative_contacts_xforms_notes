using System;
using ContactApp.Core.Interfaces;
using Xamarin.Essentials;

namespace NotesForms.Implementations
{
	public class PreferencesService : IPreferenceService
	{
		public PreferencesService()
		{
		}

        public string Get(string key)
        {
            return Preferences.Get(key,string.Empty);
        }

        public void Set(string key, string value)
        {
            Preferences.Set( key, value );
        }

        public void UnSet(string key)
        {
            Preferences.Remove( key);
        }
    }
}

