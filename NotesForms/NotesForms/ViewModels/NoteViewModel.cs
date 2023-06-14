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
using Xamarin.Essentials;
using System.Diagnostics;
using NotesForms.Constants;
using System.Collections.Generic;
using Prism.Events;
using Prism.Navigation;
using NotesForms.Events;
using NavigationMode = Prism.Navigation.NavigationMode;
using Prism.Commands;

namespace NotesForms.ViewModels
{
	public class NoteViewModel :BaseVM
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
        readonly INavigationService _navigation;

        /// <summary>
        /// PropertyChanged declared in parent class
        /// </summary>
        readonly IEventAggregator _eventAggregator;

        #endregion Flds

        #region Props
        
        public ObservableCollection<Note> OCNotes { get; private set; }

        public ICommand CmdSave     { get; private set; }
        public ICommand CmdCreate   { get; private set; }
        public ICommand CmdSelect   { get; private set; }
        public ICommand CmdUpdate   { get; private set; }
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

        #region Ctors

        /// <summary>
        /// This is the constructor
        /// </summary>
        /// <param name="noteService">{INoteService}</param>
        /// <param name="navigation">{INavigation}</param>
        public NoteViewModel( INoteService noteService,
            INavigationService navigation,
            IEventAggregator eventAggregator)
		{
            _noteService    = noteService;
            _navigation     = navigation;
            _eventAggregator= eventAggregator;
            PageTitle       = "My Notes";

            var notes   = _noteService.GetNotes();

            OCNotes         = new ObservableCollection<Note>( notes );
            OCNotesSelected = new ObservableCollection<object>();

            //->FIXME: Why uses a delegate here?

            //CmdDeleteAll    = new Command( DeletingAll );
            CmdDeleteAll    = new DelegateCommand( DeletingAll );

            //CmdCreate       = new Command( CreatingNote );
            CmdCreate       = new DelegateCommand( CreatingNote );

            //CmdLogOut       = new Command( LogginOut );
            //CmdSave         = new Command<Note>( SavingNote );
            //CmdUpdate       = new Command<Note>( UpdatingNote );

            //CmdDelete       = new Command<Note>( DeletingNote );
            CmdDelete       = new DelegateCommand<Note>( DeletingNote );
           
            //CmdSelect       = new Command<Note>( SelectingNote );
            CmdSelect       = new DelegateCommand<Note>( SelectingNote );

            //MessagingCenter.Instance.Subscribe<NoteDetailViewModel,Note>(this, Messages.NoteSaved, OnSaveNote );
            //MessagingCenter.Instance.Subscribe<NoteDetailViewModel,Note>(this, Messages.NoteUpdated, OnUpdateNote );
            _eventAggregator.GetEvent<NoteEvent>().Subscribe(SavingNoteEvent);
		}
        #endregion Ctors

        #region - methods
        private void SavingNoteEvent(NoteEventPayload payload)
        {
            switch (payload.Action)
            {
                case NoteEventAction.Save:
                    SavingNote( payload.Note );
                break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void CreatingNote()
        {
            var noteDetailPage = new NoteDetailPage( null );
            _navigation.NavigateAsync(nameof(NoteDetailViewModel));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        void SelectingNote( Note note )
        {
            var parameters = new NavigationParameters();
            parameters.Add("SelectedNote", SelectedNote);
            _navigation.NavigateAsync(nameof(NoteDetailViewModel), parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        void DeletingNote( Note note )
        {
            _noteService.DeleteNote(note);
            OCNotes.Remove( note );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        void SavingNote( Note note )
        {
            _noteService.SaveNote(note);
            OCNotes.Add( note );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        void UpdatingNote( Note note )
        {
            _noteService.UpdateNote(note);
            var position        = OCNotes.IndexOf(note);
            OCNotes[position]   = note;
        }

        /// <summary>
        /// 
        /// </summary>
        void LogginOut()
        {
            //var app = App.Current as App;
            //app.SignOut();
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

        void debug(IList<Note> obj, string title = "BP")
        {
            Console.WriteLine(title);

            foreach (var item in obj)
                Debug.WriteLine($"{item.Latitude} {item.Longitude}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="note"></param>
        void OnSaveNote(NoteDetailViewModel sender, Note note)
        {
            SavingNote(note);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnUpdateNote(NoteDetailViewModel sender, Note note)
        {
            UpdatingNote(note);
        }

        private void OnShowCommand(Note note)
        {
            Debug.WriteLine( $"note: {note.Title}" );
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

            await Task.Delay( TimeSpan.FromSeconds( 1.6 ) );

            /*
            OCNotes.Add( new Note()
            {
                Title = "Test",
            });*/

            var notes = _noteService.GetNotes();

            OCNotes.Clear();

            foreach (var note in notes) { 

                Debug.WriteLine(note);

                OCNotes.Add(note);
            }


            

            IsRefreshing = false;
        }
        #endregion #methods

        #region + methods
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                var action  = parameters.GetValue<String>("Action");
                var note    = parameters.GetValue<Note>("Note");

                Console.WriteLine($"Action: {action}");
                Console.WriteLine($"Note: {note.ID}");
            }
        }
        #endregion + methods
    }
}

