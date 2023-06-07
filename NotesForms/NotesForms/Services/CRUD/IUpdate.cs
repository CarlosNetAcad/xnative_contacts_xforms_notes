using System;
using System.Threading.Tasks;

namespace NotesForms.Services.CRUD
{
	public interface IUpdate<T>
	{
		bool Update( T entity );
	}
}