using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesForms.Services
{
	public interface IEmail
	{
		Task SendEmailMessage( string subject, string body, List<string> recipients);
	}
}