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
        readonly INavigation  _navigation;
        readonly IGeolocation _geolocation;
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
            Note note,
            INoteService noteService,
            INavigation navigation,
            IGeolocation geolocation,
            bool exist = false)
		{
            //->#SubRegion Set Props
            NoteSelected    = note;
            Exist           = exist;

            _noteService = noteService;
            _navigation = navigation;
            _geolocation = geolocation;

            SetNoteTypesOptions();

            LoadEntity( note );

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

            _navigation.PopAsync();
        }

        void OnDeleteCommand()
        {
            _noteService.DeleteNote(NoteSelected);
            _navigation.PopAsync();
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
                NoteSelected.Latitude = 37.785834;// location.Latitude;
                NoteSelected.Longitude = -122.406417;// location.Longitude;
                //->NOTE: @deprecated, save by Messaging center
                //_noteService.SaveNote( NoteSelected );

                Console.WriteLine("Location:::::::");
                Debug.WriteLine($"{NoteSelected.Latitude} {NoteSelected.Longitude}");

                if (Exist)
                    MessagingCenter.Instance.Send(this, Messages.NoteUpdated, NoteSelected);
                else
                    MessagingCenter.Instance.Send(this, Messages.NoteSaved, NoteSelected);

                await _navigation.PopAsync();
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

