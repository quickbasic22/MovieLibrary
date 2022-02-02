using MovieLibrary.Models;
using MovieLibrary.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieLibrary.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private int id;
        private string title;
        private DateTime released;
        private string mediaformat;
        public ICommand DeleteMovie { get; set; }
        public Command LoadItemsCommand { get; }
        public IDataStore<Movie> DataStore;
        public ObservableCollection<Movie> Items { get; }


        public ItemDetailViewModel()
        {
            DataStore = (IDataStore<Movie>)App.Current.Properties["StoreData"];
            Items = (ObservableCollection<Movie>)App.Current.Properties["OBC"];
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteMovie = new Command(OnDelete);
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public int Id
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

        private async void OnDelete(object obj)
        {
            var movie = obj as Movie;
            await DataStore.DeleteItemAsync(movie.Id);
            Items.RemoveAt(movie.Id);
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

       

        public int ItemId
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

        public async void LoadItemId(int itemId)
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

    }
}
