using MovieLibrary.Models;
using MovieLibrary.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieLibrary.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string title;
        private DateTime released;
        private string mediaformat;

        public ItemDetailViewModel()
        {
        }

        
        public string Id { get; set; }

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

    }
}
