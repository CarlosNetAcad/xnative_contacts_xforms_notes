using System;
using System.Collections.Generic;
using ContactApp.Core.Entities;
using Moq;
using NotesForms.Services;
using NUnit.Framework;

namespace NUnitTest.Services
{
	public class NotesServices
	{
        #region Flds
        private INoteService _noteService;

        #endregion Flds

        #region Ctor
        #endregion Ctors

        #region + methods
        [SetUp]
        public void Setup()
        {
            //Arrange
            var mockService = new Mock<INoteService>();

            //<HappyPathReadAllRecords> return a empty note list
            mockService.Setup( m => m.GetNotes()).Returns( new List<Note>()
            {
                new Note
                {
                    Title   = "Fogo cae",
                    Content = "Caliente  e novo para um lugar bom"
                }
            });

            //<HappyPathInsert> Verify Mandatory Props
            mockService.Setup(m => m.SaveNote(It.IsAny<Note>())).Returns( (Note n) =>
            {
                if (!String.IsNullOrEmpty(n.Title) &&
                    !String.IsNullOrEmpty(n.Content)
                ) return true;
                
                  return false;
            });

            //<HappyPathUpdate>
            mockService.Setup(m => m.UpdateNote(It.IsAny<Note>())).Returns((Note n) =>
            {
                if (!String.IsNullOrEmpty(n.Title) &&
                    !String.IsNullOrEmpty(n.Content)
                ) return true;

                return false;
            });

            //<HappyPathDelete>
            mockService.Setup(m => m.DeleteNote(It.IsAny<Note>())).Returns((Note n) =>
            {
                if (String.IsNullOrEmpty( n.ID )) return false;

                return true;
            });

            //<HappyPathGetOneNote>
           
            //<CurrentSource>
            _noteService = mockService.Object;
        }

        //->QUESTION: What kind of typos accept the [TestCase]? 
        [Test]
        public void GetNotes_NoArgs_ReturnNoteList()
        {
            //<arrange>
            const int ExpectedResult = 1;
            //<act>
            IList<Note> notes = _noteService.GetNotes();
            //<assert>
            Assert.GreaterOrEqual( notes.Count, ExpectedResult);
        }

        [Test]
        public void SaveNote_NoteMandatoryProps_ReturnTrue()
        {
            //<arrange>
            //const bool ExpectedResult = false;
            Note note =  new Note
            {
                Title   = "15245",
                Content = "dferhwthgnn"
            };

            //<act>

            bool result = _noteService.SaveNote( note);

            //assert

            Assert.IsTrue( result, "A Prop is missing..." );

        }

        [Test]
        public void SaveNote_EmptyNote_ReturnFalse()
        {
            //<arrange>
            //const bool ExpectedResult = false;
            Note note = new Note
            {
                Title = "",
                Content = ""
            };

            //<act>

            bool result = _noteService.SaveNote(note);

            //assert

            Assert.IsFalse(result, "Mandatories properties values are missing...");

        }

        [Test]
        public void UpdateNote_ExistingNote_ReturnTrue()
        {
            //<arrange>

            Note note = new Note
            {
                Title = "15245",
                Content = "dferhwthgnn"
            };

            //<act>

            bool result = _noteService.UpdateNote( note );

            //<assert>

            Assert.IsTrue( result, "Was not able to update the note." );
        }

        [Test]
        public void UpdateNote_MissingData_ReturnFalse()
        {
            //<arrange>

            Note note = new Note
            {
                Title = "",
                Content = "dferhwthgnn"
            };

            //<act>

            bool result = _noteService.UpdateNote(note);

            //<assert>

            Assert.IsFalse( result, "Was not able to update the note because is missing a mandatory data.");

        }

        [Test]
        public void DeleteNote_ExistingNote_ReturnTrue()
        {
            //<arrange>

            Note note = new Note
            {
                Title = "12345",
                Content = "dferhwthgnn"
            };

            //<act>

            bool result = _noteService.DeleteNote(note);

            //<assert>

            Assert.IsTrue(result, "Was not able to delete the note.");

        }
        #endregion + methods
    }
}