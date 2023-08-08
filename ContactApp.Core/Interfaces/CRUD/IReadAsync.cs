using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Core.Interfaces.CRUD
{
	public interface IReadAsync<T>
	{
        Task<IList<T>> GetAllAsync();
        //Task<T> GetByID( string ID );
    }
}

