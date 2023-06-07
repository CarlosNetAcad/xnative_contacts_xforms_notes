using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesForms.Services.CRUD
{
	public interface IReadAsync<T>
	{
        Task<IList<T>> GetAllAsync();
        //Task<T> GetByID( string ID );
    }
}

