using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesForms;
using NotesForms.Pages;
using NotesForms.Services;
using NotesForms.Repository;
using NotesForms.ViewModels;
using System.Diagnostics;
using Prism;
using Prism.Ioc;
using Prism.DryIoc;
using Prism.Navigation;
using System.ComponentModel.Design;


namespace NotesForms
{
    public partial class App : PrismApplication
    {
        #region Ctors
        /// <summary>
        /// This is the constructor
        /// ID string generated is "M:NotesForms.App.#ctor"
        /// </summary>
        public App() : this(null)
        { 
        }

        public App(IPlatformInitializer initializer) :  this( initializer ,true)
        {
        }

        public App( IPlatformInitializer initializer,
            bool setFormsDependencyResolver) :base( initializer,setFormsDependencyResolver)
        {
        }
        #endregion Ctors

        #region - methods
        #endregion - methods

        #region - events
        #endregion - events

        #region # method

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"NavigationPage/{nameof(AppLoadingViewModel)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //register services
            containerRegistry.RegisterSingleton<IPreferenceService,PreferencesService>();
            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterSingleton<IArticleService,  APIRepository>();
            containerRegistry.RegisterSingleton<INoteService, SQLiteRepository>();
            containerRegistry.RegisterSingleton<IAuthService, AuthRepository>();

            //register pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabbedPage>();

            //register viewmodels and pages
            containerRegistry.RegisterForNavigation<MenuTabbedPage, MenuViewModel>(nameof(MenuViewModel));
            containerRegistry.RegisterForNavigation<AppLoadingPage, AppLoadingViewModel>(nameof(AppLoadingViewModel));
            containerRegistry.RegisterForNavigation<SignInPage, SignInPage>(nameof(SignInViewModel));
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpViewModel>(nameof(SignUpViewModel));
            containerRegistry.RegisterForNavigation<ArticlesPage, ArticleViewModel>(nameof(ArticleViewModel));
            containerRegistry.RegisterForNavigation<NoteDetailPage, NoteDetailViewModel>(nameof(NoteDetailViewModel));
            containerRegistry.RegisterForNavigation<MapsPage, MapViewModel>(nameof(MapViewModel));

            //containerRegistry.RegisterForNavigation<NotesPage, NotesViewModel>(nameof(NotesViewModel));
            containerRegistry.RegisterForNavigation<NotesCollectionPage, NoteViewModel>(nameof(NoteViewModel));
            containerRegistry.RegisterForNavigation<ProfilesPage, ProfileViewModel>(nameof(ProfileViewModel));
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>(nameof(SettingsViewModel));

        }
        #endregion # methods

        #region # events
        #endregion # events

        #region + methods       
        #endregion + methods

        #region + events       
        #endregion + events
    }
}

