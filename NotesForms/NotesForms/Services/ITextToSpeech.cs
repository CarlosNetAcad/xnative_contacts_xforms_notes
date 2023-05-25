using System;
using System.Threading.Tasks;

namespace NotesForms.Services
{
	public interface ITextToSpeech
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="TextToSpech"></param>
		/// <returns></returns>
		Task SpeakAsync( string TextIntoVoice );
	}
}

