using System;
using Xamarin.Forms;
using NotesForms.ViewModels.Base;
using NotesForms.Services;
using System.Collections.Generic;
using ContactApp.Core.Entities;
using System.Diagnostics;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

namespace NotesForms.ViewModels
{
	public class MapViewModel:BaseVM
	{
        #region Flds

        string _title;
        int _altitude;
        IList<Note> _lstNotes;
        Xamarin.Forms.Maps.Map _map;

        readonly INavigation _nav;
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
            set => SetProperty( ref _altitude, value);
        }

        public Xamarin.Forms.Maps.Map Map
        {
            get => _map;
            set => SetProperty( ref _map, value);
        }

        public ObservableCollection<Note> Pins { get; private set; }

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
            _nav            = navigation;
            _noteService    = noteService;
            _geolocation    = geolocation;
            Map         = map;

            SetListNotes();

            Title = "Maps";
		}

        #endregion Ctors

        #region - methods

        void SetListNotes()
        {
            Pins = new ObservableCollection<Note>();
            _lstNotes = _noteService.GetNotes();
        }

       #endregion - methods

        #region # methods
        #endregion # methods

        #region + methods
        /// <summary>
        /// <deprecated></deprecated>
        /// </summary>
        /// <returns></returns>
        public Task SetPinsOnTheMapAsync2()
        {
            if (_lstNotes == null ||
                _lstNotes.Count < 1) return Task.CompletedTask;

          _geolocation.SetPinsOnTheMapAsync(_lstNotes, _map);

            return Task.CompletedTask;
        }

        public async Task SetPinsOnTheMapAsync()
        {

            if (_lstNotes == null ||
                _lstNotes.Count < 1)           
                Pins.Clear();

            foreach (var note in _lstNotes)
            {
                Pins.Add(new Note()
                {
                    Title = note.Title,
                    Latitude = note.Latitude,
                    Longitude = note.Longitude
                });
            }

            await Task.CompletedTask;
        }

        public async Task<Tuple<double, double>> GetCurrentLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    var position = new Tuple<double, double>(location.Latitude, location.Longitude);
                    return position;
                }
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

            return null;
        }

        #endregion + methods
    }
}

