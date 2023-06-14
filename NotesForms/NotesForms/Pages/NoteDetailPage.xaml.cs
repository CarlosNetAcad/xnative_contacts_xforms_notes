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
        public NoteDetailPage ( Note note, bool exist = false)
		{
			InitializeComponent ();
        }
	}
}