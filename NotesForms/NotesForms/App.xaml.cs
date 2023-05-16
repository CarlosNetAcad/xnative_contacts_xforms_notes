using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesForms;
namespace NotesForms
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new MenuTabbedPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

