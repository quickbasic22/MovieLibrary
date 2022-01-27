using MovieLibrary.Models;
using MovieLibrary.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MovieLibrary.Views
{
    public partial class ItemsPage : ContentPage
    {
        readonly ItemsViewModel _viewModel;

        public List<Movie> movieSelectionList;
       

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel(movieSelectionList);
        }
                     
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void CheckBoxSelected_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

          
        }

        private void ItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var moviecurrent = e.CurrentSelection as Movie;
            
            if (moviecurrent.MovieIsSelected)
                movieSelectionList.Add(moviecurrent);
            else
                movieSelectionList.Remove(moviecurrent);

        }
    }
}