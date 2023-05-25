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

        public void DeleteNote(Note note)
        {
            _notes.Remove( note );
        }

        public IList<Note> GetNotes()
        {
            return _notes;
        }

        public void SaveNote(Note note)
        {
            Console.WriteLine($"inserting in repo { note.Title }");
            _notes.Add( note );
        }
    }
}

