using System;
using System.Threading.Tasks;

namespace NotesForms.Services
{
	public interface ISMS
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="messageText"></param>
		/// <param name="recipient"></param>
		Task SendSMSAsync( string messageText, string recipient );
	}
}

