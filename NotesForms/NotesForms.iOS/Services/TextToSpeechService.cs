using System;
using System.Threading.Tasks;
using NotesForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency( typeof ( TextToSpeech ) )]
namespace NotesForms.iOS.Services
{
	public class TextToSpeechService:ITextToSpeech
	{
		
        public async Task SpeakAsync(string TextIntoVoice)
        {
            await TextToSpeech.SpeakAsync( TextIntoVoice );
        }
    }
}

