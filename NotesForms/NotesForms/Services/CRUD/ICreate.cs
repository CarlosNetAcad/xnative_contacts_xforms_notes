using System;
using System.Threading.Tasks;

namespace NotesForms.Services.CRUD
{
	public interface ICreate<T>
	{
		bool Store(T Entity);
	}
}

