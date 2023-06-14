using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Core.Entities;
using NotesForms.Services;
using NotesForms.Constants;
using NotesForms.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;
using Prism.Navigation;
using Prism.Events;

namespace NotesForms.ViewModels
{
    public class NoteDetailViewModel : BaseVM
    {
        #region Flds;
        string _title;
        string _content;
        DateTime _createdAt;
        NoteType _selectedNoteType;
        double _longitude;
        double _latitude;
        bool _exist;

        readonly INoteService _noteService;
        readonly INavigationService  _navigation;
        readonly IGeolocation _geolocation;
        readonly IEventAggregator _eventAggregator;
        #endregion Flds

        #region Prop
        public IList<NoteType> NoteTypes { get; set; }

        public Note NoteSelected { get; set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set => SetProperty( ref _createdAt, value );
        }

        public NoteType SelectedNoteType
        {
            get => _selectedNoteType;
            set => SetProperty(ref _selectedNoteType, value);
        }
        
        public double Longitude {
            get => _longitude;
            set => SetProperty( ref _longitude, value );
        }

        public double Latitude {
            get => _latitude;
            set => SetProperty( ref _latitude, value );
        }

        public bool Exist
        {
            get => _exist;
            set => SetProperty( ref _exist, value );
        }
        #endregion Prop

        #region Ctors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        /// <param name="noteService"></param>
        /// <param name="navigation"></param>
        public NoteDetailViewModel(
            INoteService noteService,
            INavigationService navigation,
            IGeolocation geolocation,
            IEventAggregator eventAggregator)
		{
            //->#SubRegion Set Props
            PageTitle = "Note Details";

            _noteService = noteService;
            _navigation = navigation;
            _geolocation = geolocation;
            _eventAggregator = eventAggregator;

            SetNoteTypesOptions();

            //->#SubRegion Commands
            SaveCommand = new Command( async () => await StoringNoteAsync() );
            DeleteCommand   = new Command( OnDeleteCommand );
		}
        #endregion Ctors

        #region - methods
        void SetNoteTypesOptions()
        {
            NoteTypes = new List<NoteType>();

            NoteTypes.Add(NoteType.Default);
            NoteTypes.Add(NoteType.Image);
            NoteTypes.Add(NoteType.Music);
            NoteTypes.Add(NoteType.Video);
        }

        void LoadEntity( Note note )
        {
            Title               = note?.Title;
            Content             = note?.Content;
            CreatedAt           = note?.CreatedAt   ?? DateTime.Now;
            SelectedNoteType    = note?.NoteType    ?? NoteType.Default;
            Longitude           = note?.Longitude   ?? 0.00;
            Latitude            = note?.Latitude    ?? 0.00;
        }

        /// <summary>
        /// @deprecated by async method
        /// </summary>
        void OnSaveCommand()
        {
            NoteSelected = NoteSelected ?? new Note();

            NoteSelected.Title      = Title;
            NoteSelected.Content    = Content;
            NoteSelected.CreatedAt  = DateTime.Now;
            NoteSelected.iNoteType  = (int)SelectedNoteType;

            _noteService.SaveNote(NoteSelected);

            MessagingCenter.Instance.Send(this, "upsert", NoteSelected);

            _navigation.GoBackAsync();
        }

        void OnDeleteCommand()
        {
            _noteService.DeleteNote(NoteSelected);
            _navigation.GoBackAsync();
        }

        async Task<Location> GetCurrentLocation()
        {
            return await _geolocation.GetCurrentLocation();
        }

        async Task StoringNoteAsync()
        {
            try
            {
                Location location = await _geolocation.GetCurrentLocation();

                NoteSelected = NoteSelected ?? new Note();

                NoteSelected.Title      = Title;
                NoteSelected.Content    = Content;
                NoteSelected.CreatedAt  = DateTime.Now;
                NoteSelected.iNoteType  = (int)SelectedNoteType;
                NoteSelected.Latitude   = location.Latitude;
                NoteSelected.Longitude  = location.Longitude;

                var parameters = new NavigationParameters();
                parameters.Add("Note", NoteSelected);

                if (Exist)
                    parameters.Add("Action", Messages.NoteUpdated);
                else
                    parameters.Add("Action", Messages.NoteSaved);

                await _navigation.GoBackAsync();
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
        #endregion - methods

        #region #methods

        #endregion #methods

        #region +methods

        #endregion +methods

    }
}

