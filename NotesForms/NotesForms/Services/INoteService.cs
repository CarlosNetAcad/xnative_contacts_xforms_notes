using System;
using System.Collections.Generic;
using ContactApp.Core.Entities;

namespace NotesForms.Services
{
	public interface INoteService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		IList<Note> GetNotes();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="note"></param>
		void SaveNote( Note note );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="note"></param>
		void DeleteNote( Note note);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="note"></param>
		void UpdateNote( Note note);
	}
}

