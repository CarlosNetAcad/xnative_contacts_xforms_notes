using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository.SQLite;
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

			BindingContext = _vMNote = new NoteVM();
		}

        void OnNoteTapped( System.Object sender, Xamarin.Forms.ItemTappedEventArgs e )
        {
            _vMNote.CmdSelect.Execute( e.Item );
        }
    }
}

