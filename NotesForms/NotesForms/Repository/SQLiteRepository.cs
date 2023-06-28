using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository.SQLite;
using NotesForms.Services;

namespace NotesForms.Repository
{
	public class SQLiteRepository:INoteService
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        public bool DeleteNote(Note note)
        {
            int rowAffected = Connection.Instance.Delete( note );

            return rowAffected != 0 ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>{List<Note>} notes</returns>
        public IList<Note> GetNotes()
        {
            var notes = Connection.Instance.Table<Note>().ToList();

            return notes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        public bool SaveNote(Note note)
        {
            Connection.Instance.Insert( note );
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        public bool UpdateNote(Note note)
        {
            Connection.Instance.Update( note );
            return true;
        }
    }
}

