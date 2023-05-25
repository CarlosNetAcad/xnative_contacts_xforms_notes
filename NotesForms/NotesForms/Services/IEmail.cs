using System;
using System.Collections.Generic;

namespace NotesForms.Services
{
	public interface IEmail
	{
		void SendEmailMessage( string subject, string body, List<string> recipients);
	}
}