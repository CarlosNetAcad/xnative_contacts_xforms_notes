using System;
using System.Threading.Tasks;

namespace ContactApp.Core.Interfaces.CRUD
{
	public interface ICreate<T>
	{
		bool Store(T Entity);
	}
}

