using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository.SQLite;
using NotesForms.Pages;
using NotesForms.ViewModels.Base;
using NotesForms.Services;
using Xamarin.Forms;

namespace NotesForms.ViewModels
{
	public class NoteVM :BaseVM
	{
        #region Flds
        /// <summary>
        /// @field {Note} Used when we select a single note from the Collection View
        /// ID string generated is "F:NotesForms.ViewModels._selectedNote"
        /// </summary>
        Note _selectedNote;

        /// <summary>
        /// @field {INoteService} _noteService
        /// ID string generated is "F:NotesForms.ViewModels._noteService"
        /// </summary>
        readonly INoteService _noteService;

        /// <summary>
        /// @field {INavigation} _navigation
        /// ID string generated is "F:NotesForms.ViewModels._navigation"
        /// </summary>
        readonly INavigation _navigation;

        /// <summary>
        /// PropertyChanged declared in parent class
        /// </summary>
        //public event PropertyChangedEventHandler PropertyChanged;

        #endregion Flds

        #region Props
        
        public ObservableCollection<Note> OCNotes { get; private set; }

        public ICommand CmdStore    { get; private set; }
        public ICommand CmdCreate   { get; private set; }
        public ICommand CmdSelect   { get; private set; }
        public ICommand CmdShow     { get; private set; }
        public ICommand CmdDelete   { get; private set; }
        public ICommand CmdLogOut   { get; private set; }

        //->MARK: Commands to Collection View
        public ICommand CmdDeleteAll{ get; private set; }
        public ICommand CmdSelectionNoteChanged { get; private set; }

        public ObservableCollection<object> OCNotesSelected { get; private set; }

        public Note SelectedNote
        {
            get => _selectedNote;
            set => SetProperty( ref _selectedNote,value );
        }

        #endregion Props

        #region __constructor

        /// <summary>
        /// This is the constructor
        /// </summary>
        /// <param name="noteService">{INoteService}</param>
        /// <param name="navigation">{INavigation}</param>
        public NoteVM( INoteService noteService, INavigation navigation )
		{
            _noteService = noteService;

            _navigation = navigation;

            var notes   = _noteService.GetNotes();

            OCNotes         = new ObservableCollection<Note>( notes );
            OCNotesSelected = new ObservableCollection<object>();

            CmdDeleteAll    = new Command( DeletingAll );
            CmdCreate       = new Command( OnCreateHandler );
            CmdLogOut       = new Command( LogginOut );
            CmdStore        = new Command<Note>( OnStoreHandler );
            CmdShow         = new Command<Note>( OnShowHandler );
            CmdDelete       = new Command<Note>( OnDeleteHandler );
            CmdSelect       = new Command<Note>( OnSelectHandler );
            
            MessagingCenter.Instance.Subscribe<NoteDetailPage,Note>(this,"upsert",OnUpsertHandler);
		}
        #endregion __constructor

        #region - methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="note"></param>
        void OnUpsertHandler(NoteDetailPage sender, Note note)
        {
            OnStoreHandler( note );
        }

        /// <summary>
        /// 
        /// </summary>
        void OnCreateHandler()
        {
            //Console.WriteLine($"OnCreating...");

            var noteDetailPage = new NoteDetailPage( null );

            _navigation.PushAsync( noteDetailPage );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        void OnSelectHandler( Note note )
        {
            //Console.WriteLine( $"Selecting..." );
            var noteDetailPage = new NoteDetailPage( note, true );

            _navigation.PushAsync( noteDetailPage );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        void OnDeleteHandler( Note note )
        {
            Console.WriteLine($"OnDeleting...");
            OCNotes.Remove( note );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        void OnStoreHandler( Note note )
        {
            //_noteService.SaveNote(note);
            OCNotes.Add( note );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        void OnShowHandler( Note note )
        {
            Console.WriteLine($"OnShowing...");
        }

        /// <summary>
        /// 
        /// </summary>
        void LogginOut()
        {
            var app = App.Current as App;
            app.SignOut();
        }

        void DeletingAll()
        {
            foreach ( var selected in OCNotesSelected)
            {
                var note = selected as Note;

                _noteService.DeleteNote(note);

                OCNotes.Remove(note);

                Console.WriteLine($"Deleted: {note.Title}");
            }
        }

        void OnSelectionNoteChanged()
        {
            // var noteDetailPage = new NoteDetailPage(SelectedNote);
            //_navigation.PushAsync(noteDetailPage);
        }

        #endregion - methods

        #region # methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async override Task Refreshing()
        {
            IsRefreshing = true;

            /*
            OCNotes.Add( new Note()
            {
                Title = "Test",
            });*/

            var notes = _noteService.GetNotes();

            OCNotes.Clear();

            foreach (var note in notes)
            {
                OCNotes.Add(note);
            }


            await Task.Delay( TimeSpan.FromSeconds( 1.5 ) );

            IsRefreshing = false;
        }
        #endregion #methods
    }
}

