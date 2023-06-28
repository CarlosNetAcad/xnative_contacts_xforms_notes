using System;
using System.Collections.Generic;
using ContactApp.Core.Entities;
using NotesForms.Services;
namespace NotesForms.Repository
{
    public class MockNoteRepository : INoteService
    {
        #region attributes
        IList<Note> _notes = new List<Note>();
        #endregion attributes

        public MockNoteRepository()
        {
            for (int i = 0; i<11; i++)
            {
                _notes.Add(new Note
                {
                    Title = $"Note {i}",
                    Content = $"Content {i}",
                    CreatedAt = DateTime.Now.AddDays(i)
                });
            }
        }

        public bool DeleteNote(Note note)
        {
            _notes.Remove( note );
            return true;
        }

        public IList<Note> GetNotes()
        {
            return _notes;
        }

        public bool SaveNote(Note note)
        {
            _notes.Add( note );
            return true;
        }

        public bool UpdateNote(Note note)
        {
            var position        = _notes.IndexOf(note);
            _notes[position]    = note;
            return true;
        }
    }
}

