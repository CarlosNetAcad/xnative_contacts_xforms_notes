using System;
using System.Collections.Generic;
using ContactApp.Core.Entities;
using NotesForms.Services;
using NotesForms.ViewModels;
using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class NoteDetailPage : ContentPage
	{
        public Note NoteSelected { get; set; }

        public bool Exist { get; set; } = false;

        public NoteDetailPage ( Note note, bool exist = false)
		{
			InitializeComponent ();

            //->Resolve Dependency
            var noteService = DependencyService.Resolve<INoteService>();
            var geoLocation = DependencyService.Resolve<IGeolocation>();

            BindingContext = new NoteDetailViewModel(
                note,
                noteService,
                Navigation,
                geoLocation);
        }
	}
}