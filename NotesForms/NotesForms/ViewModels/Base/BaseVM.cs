using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotesForms.ViewModels.Base
{
	public class BaseVM : INotifyPropertyChanged
	{

        bool _isRefreshing;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty( ref _isRefreshing,value );
        }

        public ICommand CmdRefresh { get; private set; }

        public BaseVM()
		{
            CmdRefresh = new Command( async () => await Refreshing() );
		}

        protected virtual Task Refreshing()
        {
            return Task.FromResult(true);
        }

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
    }
}

