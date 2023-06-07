using System;
using ContactApp.Core.Entities;
using NotesForms.Services.CRUD;

namespace NotesForms.Services
{
	public interface IUserService:IRead<User>,IUpdate<User>,ICreate<User>
	{
		//->FIXME: Create CRUD Async to separate methods.
	}
}