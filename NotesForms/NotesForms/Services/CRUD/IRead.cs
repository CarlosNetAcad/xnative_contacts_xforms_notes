using System;
using System.Collections.Generic;
using NotesCarlos.Core.Models.API;

namespace NotesForms.Services.CRUD
{
	public interface IRead<T>
	{
		IList<T> GetAllAsync();
		T GetByID( string profileID );
	}
}

