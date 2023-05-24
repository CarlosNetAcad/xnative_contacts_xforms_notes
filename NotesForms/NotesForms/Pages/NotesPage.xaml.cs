using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using NotesForms.Repository;
using NotesForms.Services;
using NotesForms.ViewModels;
using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class NotesPage : ContentPage
	{
		NoteVM _vMNote;

		public NotesPage()
		{
			InitializeComponent();

			var noteService = DependencyService.Resolve<INoteService>();
			
			BindingContext = _vMNote = new NoteVM( noteService, Navigation );
		}

        void OnNoteTapped( System.Object sender, Xamarin.Forms.ItemTappedEventArgs e )
        {
            _vMNote.CmdSelect.Execute( e.Item );
        }
    }
}

