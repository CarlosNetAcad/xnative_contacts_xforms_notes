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
        readonly INoteService _noteService;

        readonly INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Note> OCNotes { get; private set; }

        public ICommand CmdStore    { get; private set; }
        public ICommand CmdCreate   { get; private set; }
        public ICommand CmdSelect   { get; private set; }
        public ICommand CmdShow     { get; private set; }
        public ICommand CmdDelete   { get; private set; }

        /// <summary>
        /// This is the constructor
        /// </summary>
        /// <param name="noteService"></param>
        public NoteVM( INoteService noteService, INavigation navigation )
		{
            _noteService = noteService;

            _navigation = navigation;

            var notes   = _noteService.GetNotes();

            OCNotes = new ObservableCollection<Note>( notes );

            CmdCreate      = new Command( OnCreateHandler );

            CmdStore    = new Command<Note>( OnStoreHandler );
            CmdShow     = new Command<Note>( OnShowHandler );
            CmdDelete   = new Command<Note>( OnDeleteHandler );
            CmdSelect   = new Command<Note>( OnSelectHandler );
		}

        private void OnCreateHandler()
        {
            //Console.WriteLine($"OnCreating...");

            var noteDetailPage = new NoteDetailPage( null );

            _navigation.PushAsync( noteDetailPage );
        }

        private void OnSelectHandler( Note note )
        {
            //Console.WriteLine( $"Selecting..." );
            var noteDetailPage = new NoteDetailPage( note, true );

            _navigation.PushAsync( noteDetailPage );
        }

        private void OnDeleteHandler( Note note )
        {
            Console.WriteLine($"OnDeleting...");
            OCNotes.Remove( note );
        }

        private void OnStoreHandler( Note note )
        {
            Console.WriteLine($"OnSaving...");
            OCNotes.Add( note );
            Connection.Instance.Insert( note );
        }

        private void OnShowHandler( Note note )
        {
            Console.WriteLine($"OnShowing...");
        }

        protected async override Task Refreshing()
        {
            IsRefreshing = true;

            OCNotes.Add( new Note()
            {
                Title = "Test",
            });

            await Task.Delay( TimeSpan.FromSeconds( 1.5 ) );

            IsRefreshing = false;
        }
    }
}

