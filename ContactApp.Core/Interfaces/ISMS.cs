using System;
using System.Threading.Tasks;

namespace ContactApp.Core.Interfaces
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

