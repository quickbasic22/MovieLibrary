using MovieLibrary.Models;
using MovieLibrary.Services;
using MovieLibrary.ViewModels;
using MovieLibrary.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieLibrary.Views
{
    public partial class ItemsPage : ContentPage
    {
        readonly ItemsViewModel _viewModel;
        public Command DeleteCommand { get; }
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            DeleteCommand = new Command<string>(OnDelete);
           
        }

        private void OnDelete(string guidid)
        {
            
            _viewModel.DataStore.DeleteItemAsync(guidid);
            Shell.Current.GoToAsync("..");
        }

               

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void CheckBoxSelected_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            DisplayAlert(ItemsListView.Id.ToString(), "Movie Id", "Cancel");
            var checkbox = (CheckBox)sender;
            var checkYes = checkbox.IsChecked;

        }
    }
}