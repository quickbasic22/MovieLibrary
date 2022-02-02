using MovieLibrary.Models;
using MovieLibrary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieLibrary.ViewModels
{
    public class NewItemViewModel : INotifyPropertyChanged
    {

        #region Fields
        private string id = "7";
        private string title = "Movie Title";
        private DateTime released = DateTime.Now;
        private string mediaformat = "DVD";
        public IDataStore<Movie> DataStore;
        bool isBusy = false;
        #endregion

        public NewItemViewModel()
        {
            DataStore = (IDataStore<Movie>)App.Current.Properties["StoreData"];
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
               (_, __) => SaveCommand.ChangeCanExecute();
        }

        #region Properties

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public string Id 
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public DateTime Released
        {
            get => released;
            set => SetProperty(ref released, value);
        }

        public string Mediaformat
        {
            get => mediaformat;
            set => SetProperty(ref mediaformat, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        #endregion

        #region Methods
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(mediaformat);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Movie newItem = new Movie()
            {
                Id = Id,
                Title = Title,
                Released = Released,
                Mediaformat = Mediaformat
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
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
        #endregion

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
