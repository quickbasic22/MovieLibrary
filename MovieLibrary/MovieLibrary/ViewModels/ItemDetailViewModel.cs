using MovieLibrary.Models;
using MovieLibrary.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieLibrary.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        public Command<Movie> DeleteCommand { get; set; }
        public Command LoadItemsCommand { get; }


        public ItemDetailViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteCommand = new Command<Movie>(OnDelete);
        }

        public async Task ExecuteLoadItemsCommand()
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

        private async void OnDelete(object obj)
        {
            var movie = obj as Movie;
            await DataStore.DeleteItemAsync(movie.Id);
            Items.RemoveAt(movie.Id);
            await ExecuteLoadItemsCommand();
            await Shell.Current.GoToAsync($"{nameof(ItemsPage)}");
            Console.WriteLine(String.Format($"item deleted = {0} with id {1}", movie.Title, movie.Id));

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
