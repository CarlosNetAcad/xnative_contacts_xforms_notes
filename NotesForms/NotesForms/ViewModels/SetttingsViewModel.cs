using System;
using System.Windows.Input;
using Prism.Commands;
using Xamarin.Essentials;
using Xamarin.Forms;
using NotesForms.ViewModels.Base;

namespace NotesForms.ViewModels
{
	public class SetttingsViewModel:BaseVM
	{
        public string Version { get; set; }
        public string Build { get; set; }
        public string PackageName { get; set; }
        public ICommand GoSettingsCommand { get; private set; }

        public SetttingsViewModel()
		{
            PageTitle = "Settings";
            Version = AppInfo.VersionString;
            Build = AppInfo.BuildString;
            PackageName = AppInfo.PackageName;
            GoSettingsCommand = new DelegateCommand(OnGoSettingsCommand);
        }

        private void OnGoSettingsCommand()
        {
            AppInfo.ShowSettingsUI();
        }
    }
}

