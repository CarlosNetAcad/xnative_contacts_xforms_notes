using System;
namespace NotesForms.Services
{
	public interface IPreferenceService
	{
		void __Set( string key, string value );
		string __Get( string key );
		void __UnSet( string key );
	}
}

