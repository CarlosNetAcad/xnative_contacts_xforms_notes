using System;
namespace NotesForms.Services
{
	public interface IPreferenceService
	{
		void Set( string key, string value );
		string Get( string key );
		void UnSet( string key );
	}
}

