using System;
using ContactApp.Core.Entities;
using ContactApp.Core.Interfaces.CRUD;

namespace ContactApp.Core.Interfaces
{
	public interface IUserService:IRead<User>,IUpdate<User>,ICreate<User>
	{
		//->FIXME: Create CRUD Async to separate methods.
	}
}