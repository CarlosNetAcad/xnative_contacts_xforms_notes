﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ContactApp.Core.Entities;
using ContactApp.Core.Interfaces;
using ContactApp.Core.Repository.SQLite;

namespace NotesForms.Repository
{
	public class SQLiteRepository:INoteService
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        public void DeleteNote(Note note)
        {
            Connection.Instance.Delete( note );
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
        public void SaveNote(Note note)
        {
            Connection.Instance.Insert( note );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        public void UpdateNote(Note note)
        {
            Connection.Instance.Update( note );
        }
    }
}

