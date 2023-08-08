using System;
namespace ContactApp.Core.Interfaces
{
	public interface IPreferenceService
	{
		void Set( string key, string value );
		string Get( string key );
		void UnSet( string key );
	}
}

