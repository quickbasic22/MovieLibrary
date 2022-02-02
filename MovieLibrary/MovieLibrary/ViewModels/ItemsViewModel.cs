using MovieLibrary.Models;
using MovieLibrary.Services;
using MovieLibrary.Views;
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
    public class ItemsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private Movie _selectedItem;
        public ObservableCollection<Movie> Items { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Movie> ItemTapped { get; }
        public IDataStore<Movie> DataStore;
        string id = String.Empty;
        string title = string.Empty;
        DateTime released = DateTime.Now;
        string mediaformat = "DVD";

        #endregion

        public ItemsViewModel()
        {
            Title = "Browse";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Movie>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DataStore = (IDataStore<Movie>)App.Current.Properties["StoreData"];
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
        #endregion

        #region Methods
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var theList = await DataStore.GetItemsAsync();
                foreach (var movie in theList)
                {
                    Items.Add(movie);
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
            SelectedItem = null;
        }

        public Movie SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Movie item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
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