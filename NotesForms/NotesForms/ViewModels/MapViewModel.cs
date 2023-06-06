using System;
using Xamarin.Forms;
using NotesForms.ViewModels.Base;

namespace NotesForms.ViewModels
{
	public class MapViewModel:BaseVM
	{
        #region Flds

        string _title;
        readonly INavigation _nav;

        #endregion Flds

        #region Props

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        #endregion Props

        #region __constructor

        public MapViewModel( INavigation navigation )
		{
            _nav = navigation;
            Title = "Maps";

		}

        #endregion __constructor
    }
}

