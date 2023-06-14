using System;
using NotesForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
 
namespace NotesForms.Repository
{
    public class PreferencesService : IPreferenceService
    {
        public string Get(string key)
        {
            return Preferences.Get(key, string.Empty);
        }

        public void Set(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public void UnSet(string key)
        {
            Preferences.Remove(key);
        }
    }
}

