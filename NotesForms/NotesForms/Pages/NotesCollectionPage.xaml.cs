using System;
using System.Collections.Generic;
using NotesForms.Services;
using NotesForms.ViewModels;
using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class NotesCollectionPage : ContentPage
	{
        #region Attr
        NoteViewModel _noteVM = null;
        #endregion Attr

        #region Props
        #endregion Props

        #region __constructor
        public NotesCollectionPage ()
		{
			InitializeComponent ();

            var noteService = DependencyService.Resolve<INoteService>();

            BindingContext = _noteVM = new NoteViewModel( noteService, Navigation);
		}
        #endregion __constructor
    }
}

