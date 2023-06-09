using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesForms;
using NotesForms.Pages;
using NotesForms.Services;
using NotesForms.Repository;
using System.Diagnostics;
using Prism;
using Prism.Ioc;
using Prism.DryIoc;


namespace NotesForms
{
    public partial class App : PrismApplication
    {
        #region Ctors
        /// <summary>
        /// This is the constructor
        /// ID string generated is "M:NotesForms.App.#ctor"
        /// </summary>
        public App()
        { 
        }

        public App( IPlatformInitializer initializer,
            bool setFormsDependencyResolver)
            :base( initializer,setFormsDependencyResolver)
        {
        }
        #endregion Ctors

        #region - methods
        #endregion - methods

        #region - events
        #endregion - events

        #region # method
        #endregion # methods

        #region # events
        #endregion # events

        #region + methods       
        #endregion + methods

        #region + events       
        #endregion + events
    }
}

