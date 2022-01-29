using MovieLibrary.Models;
using MovieLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MovieLibrary.Views
{
    public partial class ItemsPage : ContentPage
    {
        readonly ItemsViewModel _viewModel;

              

        public ItemsPage()
        {
                InitializeComponent();

                BindingContext = _viewModel = new ItemsViewModel();
                       
        }
                     
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        
        private void SwipeItemDelete_Invoked(object sender, EventArgs e)
        {

        }

        private void SwipeItemDetails_Invoked(object sender, EventArgs e)
        {

        }
    }
}