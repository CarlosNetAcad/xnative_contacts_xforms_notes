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
        MapViewModel VMMap;
        #endregion Flds
        #region Ctors

        public MapsPage ()
		{
			InitializeComponent ();

            var noteService = DependencyService.Resolve<INoteService>();
            var geoLocation = DependencyService.Resolve<IGeolocation>();

			BindingContext = VMMap = new MapViewModel( Navigation, noteService, geoLocation, map );
		}

        #endregion Ctors

        #region # method

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                await VMMap.SetPinsOnTheMapAsync();

                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }

                var position = new Position(location.Latitude, location.Longitude);

                var distance = new Distance(1000);

                var mapSpan = MapSpan.FromCenterAndRadius(position, distance);

                var currentPosition = new Pin()
                {
                    Label = "You are here!",
                    Position = position
                };

                map.Pins.Add(currentPosition);
                map.MoveToRegion(mapSpan);

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        #endregion # region
    }
}

