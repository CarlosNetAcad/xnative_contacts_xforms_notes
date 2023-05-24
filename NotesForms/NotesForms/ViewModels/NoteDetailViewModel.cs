using System;
using System.Windows.Input;
using ContactApp.Core.Entities;
using NotesForms.Services;
using NotesForms.ViewModels.Base;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
	public class NoteDetailViewModel:BaseVM
	{
        #region constructor
        public NoteDetailViewModel(Note note, INoteService noteService, INavigation navigation)
		{
            _noteService    = noteService;
            _navigation     = navigation;
            NoteSelected    = note;

            Console.WriteLine($"Title {note.Title}");
            Console.WriteLine($"Content {note.Content}");

            SaveCommand     = new Command( OnSaveCommand );
            DeleteCommand   = new Command( OnDeleteCommand );
		}
        #endregion constructor

        #region -methods
        void OnSaveCommand()
        {
            NoteSelected = NoteSelected ?? new Note();

            NoteSelected.Title      = Title;
            NoteSelected.Content    = Content;

            _noteService.SaveNote( NoteSelected );
            _navigation.PopAsync();
        }

        void OnDeleteCommand()
        {
            _noteService.DeleteNote( NoteSelected );
            _navigation.PopAsync();
        }


        #endregion -methods

        #region #methods

        #endregion #methods

        #region +methods

        #endregion +methods

        #region properties

        public Note NoteSelected { get; set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public string Title
        {
            get => _title;
            set => SetProperty( ref _title, value );
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        #endregion properties

        #region attributes;
        string _title;

        string _content;

        readonly INoteService _noteService;

        readonly INavigation _navigation;
        #endregion attributes
    }
}

