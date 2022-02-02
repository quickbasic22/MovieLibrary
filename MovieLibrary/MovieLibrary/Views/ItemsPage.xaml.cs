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
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
           
        }
  
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

    }
}