using System;
using System.Threading.Tasks;
using NotesCarlos.Core.Models.API;
using NotesForms.Services.CRUD;

namespace NotesForms.Services
{
	public interface IArticleService:IReadAsync<Article>
	{ 
	}
}