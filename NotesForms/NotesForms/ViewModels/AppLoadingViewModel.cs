using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NotesForms.Services;
using NotesForms.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;

namespace NotesForms.ViewModels

{
	public class AppLoadingViewModel:BaseVM
	{
		private readonly IAuthService _authorizationService;
        private readonly INavigationService _navigation;

        public ICommand CheckUserSessionCommand { get; private set; }

        public AppLoadingViewModel(
			INavigationService navigationService,
			IAuthService authService)
		{
			_authorizationService = authService;
			_navigation = navigationService;

            CheckUserSessionCommand = new DelegateCommand(async () => await OnCheckUserSessionCommand());
        }

        private async Task OnCheckUserSessionCommand()
        {
            var isRefresh = await _authorizationService.RefreshAuth();

            if (isRefresh)
            {
                //main menu
                await _navigation.NavigateAsync(
                                      $"root:///{nameof(MenuViewModel)}" +
                                      $"?createTab=NavigationPage|{nameof(NoteViewModel)}" +
                                      $"&createTab=NavigationPage|{nameof(MapViewModel)}" +
                                      $"&createTab=NavigationPage|{nameof(ArticleViewModel)}" +
                                      $"&createTab=NavigationPage|{nameof(ProfileViewModel)}" +
                                      $"&createTab=NavigationPage|{nameof(SettingsViewModel)}");
            }
            else
            {
                await _navigation.NavigateAsync($"root:///NavigationPage/{nameof(SignInViewModel)}");
            }
        }
    }
}

