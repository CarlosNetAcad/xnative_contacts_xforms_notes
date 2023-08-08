using System;
using System.Windows.Input;
using Prism.Commands;
using Xamarin.Essentials;
using NotesForms.ViewModels.Base;


namespace NotesForms.ViewModels
{
	public class SettingsViewModel:BaseVM
	{
		/// <summary>
		/// 
		/// </summary>
		public SettingsViewModel()
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		public string Version { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Build { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string PackageName { get; set; }

	}
}

