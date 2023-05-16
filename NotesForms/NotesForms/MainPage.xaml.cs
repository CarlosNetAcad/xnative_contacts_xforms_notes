using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesForms.Pages;
using Xamarin.Forms;

namespace NotesForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void GoToProfilePage( System.Object sender, System.EventArgs e )
        {
            Navigation.PushAsync( new ProfilesPage() );
        }

        void GoToNotesPage( System.Object sender, System.EventArgs e )
        {
            Navigation.PushAsync( new NotesPage() );
        }
    }
}

