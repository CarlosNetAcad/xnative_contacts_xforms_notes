using System;
using System.Collections.Generic;
using NotesCarlos.Core.Models.API;

namespace ContactApp.Core.Interfaces.CRUD
{
	public interface IRead<T>
	{
		IList<T> GetAll();
		T GetByID( string profileID );
	}
}