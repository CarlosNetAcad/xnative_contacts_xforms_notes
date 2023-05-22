using System;
using System.Collections.Generic;
using ContactApp.Core.Entities;
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

            NoteSelected        = note;
            Exist               = exist;
            titleEntry.Text     = NoteSelected?.Title;
            contentEditor.Text  = NoteSelected?.Content;
        }

        void UpdateNoteHandler( System.Object sender, System.EventArgs e )
        {
            try
            {
                LoadEntity();

                MessagingCenter.Instance.Send( this, "update", NoteSelected );

                Navigation.PopAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        void DeleteNoteHandler( System.Object sender, System.EventArgs e )
        {
            try
            {
                if (NoteSelected == null)
                    throw new Exception( "Sorry, we cannot find the Note to delete." );

                MessagingCenter.Instance.Send(this, "delete", NoteSelected);
                Navigation.PopAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }

        void StoreNoteHandler(System.Object sender, System.EventArgs e)
        {
            try
            {
                LoadEntity();

                MessagingCenter.Instance.Send(this, "store", NoteSelected);

                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void UpsertNoteHandler(System.Object sender, System.EventArgs e)
        {
            try
            {
                LoadEntity();

                MessagingCenter.Instance.Send( this, "upsert", NoteSelected );
                
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void LoadEntity()
        {
            NoteSelected = NoteSelected ?? new Note();

            NoteSelected.Title = titleEntry.Text;
            NoteSelected.Content = contentEditor.Text;
        }
	}
}