using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using NotesForms.Services;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace NotesForms.ViewModels.Base
{
	public class BaseVM : BindableBase, INavigatedAware
	{
        #region Flds
        bool _isRefreshing;
        string _pageTitle;

        //public event PropertyChangedEventHandler PropertyChanged;
        #endregion Flds

        #region Props
        public ICommand CmdRefresh { get; private set; }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }
        #endregion Props

        #region Ctors
        public BaseVM()
		{
            CmdRefresh = new Command( async () => await Refreshing() );
		}
        #endregion Ctors

        #region # methods
        protected virtual Task Refreshing()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        ///     @desc Setter to a ViewModel attribute.
        ///     @deprecated because is provided by prism framework
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyName"></param>
        /// <returns> {bool} If was set or not</returns>
        /*protected bool SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                oldValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            else
            {
                return false;
            }
        }*/

        protected virtual Task OnRefreshCommand()
        {
            return Task.FromResult(true);
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }


        #endregion # methods
    }
}

