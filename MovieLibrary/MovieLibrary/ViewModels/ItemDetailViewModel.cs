using MovieLibrary.Models;
using MovieLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieLibrary.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string itemId;
        private string id;
        private string title;
        private DateTime released;
        private string mediaformat;
        public Command<Movie> DeleteMovie { get; set; }
        public Command LoadItemsCommand { get; }
        public IDataStore<Movie> DataStore;
        public ObservableCollection<Movie> Items { get; }
        #endregion

        public ItemDetailViewModel()
        {
            DataStore = (IDataStore<Movie>)App.Current.Properties["StoreData"];
            Items = (ObservableCollection<Movie>)App.Current.Properties["OBC"];
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteMovie = new Command<Movie>(OnDelete);
        }
        #region Properties
        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        #endregion

        #region Methods
        private async void OnDelete(object obj)
        {
            var movie = obj as Movie;
            await DataStore.DeleteItemAsync(movie.Id);
            Items.Remove(movie);
            await ExecuteLoadItemsCommand();

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Title = item.Title;
                Released = item.Released;
                Mediaformat = item.Mediaformat;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
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
