using System;
using System.Threading.Tasks;
using Android.Content;
using NotesForms.Services;
using Xamarin.Essentials;

namespace NotesForms.Droid.Services
{
	public class TextToSpeechService:ITextToSpeech
	{
        public Context Context { get; set; }

        public  async Task SpeakAsync(string TextIntoVoice)
        {
            await TextToSpeech.SpeakAsync( TextIntoVoice );
        }
    }
}

