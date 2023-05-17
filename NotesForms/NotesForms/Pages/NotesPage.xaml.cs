﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using Xamarin.Forms;

namespace NotesForms.Pages
{	
	public partial class NotesPage : ContentPage
	{
		ObservableCollection<Note> Notes;

		IList<Note> notes = new List<Note>();

		public NotesPage ()
		{
			InitializeComponent ();

			Notes = new ObservableCollection<Note>();

			for( int i = 0; i < 20; i++)
			{
                Notes.Add(new Note
                {
                    Title = $"Title {i}",
                    Content = $"Content {i}",
                    CreatedAt = DateTime.Now.AddDays(-i)
                });
            }

			listView.ItemsSource = Notes;
		}

        async void listView_Refreshing(System.Object sender, System.EventArgs e)
        {
            listView.IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(1.6));
            Notes.Add(new Note
            {
                Title = $"Title xx",
                Content = $"Content xx",
                CreatedAt = DateTime.Now
            });
            listView.IsRefreshing = false;
        }

        void MenuItem_Clicked(System.Object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var item = menuItem.CommandParameter as Note;
            this.DisplayAlert("Selected", $"Item: {item.Title}", "OK");
        }

        void MenuItem_Clicked_1(System.Object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var item = menuItem.CommandParameter as Note;
            Notes.Remove(item);
        }

        void listView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var note = e.Item as Note;
            //Console.WriteLine($"item tapped: {item.Title}");
            //this.DisplayAlert("Selected", $"Item: {item.Title}", "OK");
            var noteDetailPage = new NoteDetailPage(note);
            //noteDetailPage.NoteSelected = note;
            Navigation.PushAsync(noteDetailPage);
        }

        void listView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Note;
            Console.WriteLine($"item selected: {item.Title}");

            //this.DisplayAlert("Selected", $"Item: {item.Title}", "OK");

        }
    }
}

