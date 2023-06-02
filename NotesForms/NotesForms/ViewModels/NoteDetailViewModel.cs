using System;
using System.Collections.Generic;
using System.Windows.Input;
using ContactApp.Core.Entities;
using NotesForms.Services;
using NotesForms.ViewModels.Base;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
	public class NoteDetailViewModel:BaseVM
	{
        #region Flds;
        string _title;

        string _content;

        NoteType _selectedNoteType;

        readonly INoteService _noteService;

        readonly INavigation _navigation;
        #endregion Flds

        #region Prop

        public Note NoteSelected { get; set; }

        public IList<NoteType> NoteTypes { get; set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public NoteType SelectedNoteType
        {
            get => _selectedNoteType;
            set => SetProperty( ref _selectedNoteType, value );
        }
        #endregion Prop

        #region __constructor
        public NoteDetailViewModel(Note note, INoteService noteService, INavigation navigation)
		{
            _noteService    = noteService;
            _navigation     = navigation;
            NoteSelected    = note;

            SetNoteTypesOptions();

            Title  = note?.Title;
            Content = note?.Content;
            SelectedNoteType = note?.NoteType ?? NoteType.Default;


            SaveCommand     = new Command( OnSaveCommand );
            DeleteCommand   = new Command( OnDeleteCommand );
		}
        #endregion __constructor

        #region - methods
        void OnSaveCommand()
        {
            NoteSelected = NoteSelected ?? new Note();

            NoteSelected.Title      = Title;
            NoteSelected.Content    = Content;
            NoteSelected.CreatedAt  = DateTime.Now;
            NoteSelected.iNoteType  = (int)SelectedNoteType;

            _noteService.SaveNote( NoteSelected );

            MessagingCenter.Instance.Send( this,"upsert",NoteSelected );

            _navigation.PopAsync();
        }

        void OnDeleteCommand()
        {
            _noteService.DeleteNote( NoteSelected );
            _navigation.PopAsync();
        }

        void SetNoteTypesOptions()
        {
            NoteTypes = new List<NoteType>();

            NoteTypes.Add(NoteType.Default);
            NoteTypes.Add(NoteType.Image);
            NoteTypes.Add(NoteType.Music);
            NoteTypes.Add(NoteType.Video);
        }
        #endregion - methods

        #region #methods

        #endregion #methods

        #region +methods

        #endregion +methods

    }
}

