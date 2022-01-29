using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieLibrary.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NewItemViewModel : BaseViewModel
    {
        private int id;
        private string title;
        private DateTime released;
        private string mediaformat;
        private int itemId;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(mediaformat) && (id > 0) && (released != null);
        }
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
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

       public async void LoadItemId(int itemId)
        {
            Movie item = new Movie();
            try
            {
                Id = itemId;
                Title = "MovieTitle";
                Released = DateTime.Now;
                Mediaformat = "DVD";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }


    }
}
