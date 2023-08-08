using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Core.Interfaces
{
	public interface IEmail
	{
		Task SendEmailMessage( string subject, string body, List<string> recipients);
	}
}