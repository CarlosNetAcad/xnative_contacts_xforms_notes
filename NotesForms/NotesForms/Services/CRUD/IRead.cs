using System;
using System.Collections.Generic;
using NotesCarlos.Core.Models.API;

namespace NotesForms.Services.CRUD
{
	public interface IRead<T>
	{
		IList<T> GetAll();
		T GetByID( string profileID );
	}
}