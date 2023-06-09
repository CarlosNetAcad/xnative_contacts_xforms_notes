using System;
using System.Collections.Generic;
using NotesForms.Services;
using NotesForms.ViewModels;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NotesForms.Pages
{	
	public partial class MapsPage : ContentPage
	{
        #region Flds
        MapViewModel _vMMap;
        #endregion Flds

        #region Ctors

        public MapsPage ()
		{
			InitializeComponent ();

            var noteService = DependencyService.Resolve<INoteService>();
            var geoLocation = DependencyService.Resolve<IGeolocation>();

			BindingContext = _vMMap = new MapViewModel( Navigation, noteService, geoLocation, map );
		}

        #endregion Ctors

        #region # method

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _vMMap.SetPinsOnTheMapAsync();

            var currentLocation = await _vMMap.GetCurrentLocationAsync();

            var position = new Position( currentLocation.Item1,currentLocation.Item2 );

            var distance = new Distance(1000);

            var mapSpan = MapSpan.FromCenterAndRadius(position,distance);

            map.MoveToRegion( mapSpan);
        }

        #endregion # region
    }
}

