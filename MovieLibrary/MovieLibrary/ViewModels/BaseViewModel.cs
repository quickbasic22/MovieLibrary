using MovieLibrary.Models;
using MovieLibrary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MovieLibrary.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            
        }

        public IDataStore<Movie> DataStore => DependencyService.Get<IDataStore<Movie>>();

        private string title = string.Empty;
        private DateTime released = DateTime.Now;
        private string mediaformat = string.Empty;
        private bool isbusy = false;

        public bool IsBusy
        {
            get { return isbusy; }
            set { SetProperty(ref isbusy, value); }
        }

        
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DateTime Released
        {
            get { return released; }
            set { SetProperty(ref released, value); }
        }

        public string Mediaformat
        {
            get { return mediaformat; }
            set { SetProperty(ref mediaformat, value); }
        }

       
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
