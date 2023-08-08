using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Core.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using NotesForms.ViewModels.Base;

namespace NotesForms.ViewModels
{
	public class AppLoadingViewModel:BaseVM
	{
		private readonly IAuthService _authService;

		private readonly INavigationService _navigation;

		public ICommand CheckUserSessionCommand { get; private set; }

		private async Task OnCheckUserSessionCommand()
		{
			var isRefresh = await _authService.RefreshAuth();

			if( isRefresh)
			{
				await _navigation.NavigateAsync(
                      $"root:///{nameof(MenuViewModel)}" +
                                      $"?createTab=NavigationPage|{nameof(NoteViewModel)}" +
                                      $"&createTab=NavigationPage|{nameof(MapViewModel)}" +
                                      $"&createTab=NavigationPage|{nameof(ArticleViewModel)}" +
                                      $"&createTab=NavigationPage|{nameof(ProfileViewModel)}" +
                                      $"&createTab=NavigationPage|{nameof(ProfileViewModel)}"
                );
			}
			else
			{
                await _navigation.NavigateAsync($"root:///NavigationPage/{nameof(SignInViewModel)}");
            }
		}

		public AppLoadingViewModel(
			INavigationService navigationService,
			IAuthService authService
		)
		{
			_authService = authService;
			_navigation = navigationService;
			CheckUserSessionCommand = new DelegateCommand(
				null
			);
		}
	}
}

