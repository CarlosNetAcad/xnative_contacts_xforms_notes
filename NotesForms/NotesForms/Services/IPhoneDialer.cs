using System;
namespace NotesForms.Services
{
	public interface IPhoneDialer
	{
		/// <summary>
		/// Method to implement
		/// </summary>
		/// <param name="phoneNumber"></param>
		void MakeCall( string phoneNumber );
	}
}

