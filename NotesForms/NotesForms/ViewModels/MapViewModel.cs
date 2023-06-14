using System;
using Xamarin.Forms;
using NotesForms.ViewModels.Base;
using NotesForms.Services;
using System.Collections.Generic;
using ContactApp.Core.Entities;
using System.Diagnostics;
using System.Collections;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace NotesForms.ViewModels
{
    public class MapViewModel : BaseVM
    {
        #region Flds

        string _title;
        int _altitude;
        IList<Note> _lstNotes;
        Xamarin.Forms.Maps.Map _map;

        readonly INavigationService _nav;
        readonly INoteService _noteService;
        readonly IGeolocation _geolocation;
        #endregion Flds

        #region Props

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public int Altitude
        {
            get => _altitude;
            set => SetProperty(ref _altitude, value);
        }

        public Xamarin.Forms.Maps.Map Map
        {
            get => _map;
            set => SetProperty(ref _map, value);
        }
        #endregion Props

        #region Ctors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="noteService"></param>
        public MapViewModel(
            INavigation navigation,
            INoteService noteService,
            IGeolocation geolocation,
            Xamarin.Forms.Maps.Map map
            )
        {
            var _nav = navigation;
            _noteService = noteService;
            _geolocation = geolocation;
            Map = map;

            SetListNotes();

            PageTitle = "Maps";
        }
        /// <summary>
        /// Ctor used to Prism
        /// </summary>
        /// <param name="navigationService"></param>
        public MapViewModel(INavigationService navigationService)
        {
            _nav = navigationService;
            PageTitle = "Maps";
        }

        #endregion Ctors

        #region - methods

        void SetListNotes()
        {
            _lstNotes = _noteService.GetNotes();
        }
        #endregion - methods

        #region # methods
        #endregion # methods

        #region + methods
        public Task SetPinsOnTheMapAsync()
        {
            //if (_lstNotes == null ||
            //    _lstNotes.Count < 1) return Task.CompletedTask;

            _geolocation.SetPinsOnTheMapAsync(_lstNotes, _map);

            return Task.CompletedTask;
        }

        public override async void OnNavigatedTo(
            INavigationParameters parameters )
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }

                var position = new Position(location.Latitude, location.Longitude);
                var distance = new Distance(1000);
                var mapSpan = MapSpan.FromCenterAndRadius(position, distance);
                var yourPosition = new Pin()
                {
                    Label = "You are here",
                    Position = position
                };
                //map.Pins.Add(yourPosition);
                //map.MoveToRegion(mapSpan);
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
            #endregion + methods
        }
    }
}