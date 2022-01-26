using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieLibrary.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string title;
        private DateTime released;
        private string mediaformat;

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
                && !String.IsNullOrWhiteSpace(mediaformat);
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

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Movie newItem = new Movie()
            {
                Id = Guid.NewGuid().ToString(),
                Title = Title,
                Released = Released,
                Mediaformat = Mediaformat
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        
    }
}
