﻿using MovieLibrary.ViewModels;
using Xamarin.Forms;

namespace MovieLibrary.Views
{
    public partial class ItemsPage : ContentPage
    {
        readonly ItemsViewModel _viewModel;
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = (ItemsViewModel)App.Current.Properties["ItemsModel"];
            ItemsListView.ItemsSource = _viewModel.Items;
           
        }
  
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
}