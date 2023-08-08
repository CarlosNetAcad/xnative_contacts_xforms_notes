using System;
using System.Threading.Tasks;

namespace ContactApp.Core.Interfaces.CRUD
{
	public interface IUpdate<T>
	{
		bool Update( T entity );
	}
}