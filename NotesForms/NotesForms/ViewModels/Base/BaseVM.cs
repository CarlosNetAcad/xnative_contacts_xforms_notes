using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using NotesForms.Services;
using Xamarin.Forms;

namespace NotesForms.ViewModels.Base
{
	public class BaseVM : INotifyPropertyChanged
	{
        #region Flds
        bool _isRefreshing;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Flds

        #region Props
        public ICommand CmdRefresh { get; private set; }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        #endregion Props

        #region __constructor
        public BaseVM()
		{
            CmdRefresh = new Command( async () => await Refreshing() );
		}
        #endregion __constructor

        #region # methods
        protected virtual Task Refreshing()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        ///     @desc Setter to a ViewModel attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyName"></param>
        /// <returns> {bool} If was set or not</returns>
        protected bool SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = null)
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
        }
        #endregion # methods
    }
}

