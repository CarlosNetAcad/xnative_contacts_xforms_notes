using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Core.Entities;
using NotesForms.Services;
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

        #endregion Prop

        #region __constructor
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
            IGeolocation geolocation)
		{
            //->MARK: Set Props
            _noteService    = noteService;
            _navigation     = navigation;
            _geolocation    = geolocation;

            NoteSelected    = note;

            SetNoteTypesOptions();

            LoadEntity( note );

            //->MARK: Commands
            SaveCommand     = new Command( async () => await StoringNoteAsync() );
            DeleteCommand   = new Command( OnDeleteCommand );
		}
        #endregion __constructor

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
            Location location = await _geolocation.GetCurrentLocation();

            NoteSelected = NoteSelected ?? new Note();

            NoteSelected.Title      = Title;
            NoteSelected.Content    = Content;
            NoteSelected.CreatedAt  = DateTime.Now;
            NoteSelected.iNoteType  = (int)SelectedNoteType;
            NoteSelected.Longitude  = location.Longitude;
            NoteSelected.Latitude   = location.Latitude;

            //_noteService.SaveNote( NoteSelected );

            MessagingCenter.Instance.Send( this, "upsert", NoteSelected );

            await _navigation.PopAsync();
        }
        #endregion - methods

        #region #methods

        #endregion #methods

        #region +methods

        #endregion +methods

    }
}

