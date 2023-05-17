using System;
using System.Collections.Generic;
using ContactApp.Core.Entities;
using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class NoteDetailPage : ContentPage
	{
        public Note NoteSelected { get; set; }

        public NoteDetailPage (ContactApp.Core.Entities.Note note)
		{
			InitializeComponent ();

            NoteSelected = note;
            titleEntry.Text = NoteSelected?.Title;
            contentEditor.Text = NoteSelected?.Content;
        }
	}
}

