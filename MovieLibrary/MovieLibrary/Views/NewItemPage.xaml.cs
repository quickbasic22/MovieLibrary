using MovieLibrary.Models;
using MovieLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieLibrary.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Movie Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}