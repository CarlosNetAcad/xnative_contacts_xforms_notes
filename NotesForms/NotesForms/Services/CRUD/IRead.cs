using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotesCarlos.Core.Models.API;

namespace NotesForms.Services.CRUD
{
	public interface IRead
	{
		Task<IList<Article>> GetAllAsync();
	}
}

