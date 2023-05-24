using System;
using System.Collections.Generic;
using ContactApp.Core.Entities;
using NotesForms.Services;
namespace NotesForms.Repository
{
	public class MockNoteRepository : INoteService
	{
        #region attributes
        IList<Note> _notes;
        #endregion attributes

        public void DeleteNote(Note note)
        {
            _notes.Remove( note );
        }

        public IList<Note> GetNotes()
        {
            _notes = new List<Note>();

            for ( int i = 0; i<11; i++)
            {
                _notes.Add(new Note
                {
                    Title = $"Note {i}",
                    Content = $"Content {i}"
                });
            }

            return _notes;
        }

        public void SaveNote(Note note)
        {
            _notes.Add( note );
        }
    }
}

