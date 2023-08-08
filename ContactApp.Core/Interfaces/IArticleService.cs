using System;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using ContactApp.Core.Interfaces.CRUD;

namespace ContactApp.Core.Interfaces
{
	public interface IArticleService:IReadAsync<Article>
	{ 
	}
}