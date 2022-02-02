using MovieLibrary.Models;
using MovieLibrary.Services;
using MovieLibrary.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieLibrary
{
    public partial class App : Application
    {
        public ObservableCollection<Movie> Items { get; }
        public IDataStore<Movie> DataStore;
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DataStore = DependencyService.Get<IDataStore<Movie>>();
            this.Properties.Add("StoreData", DataStore);
            Items = new ObservableCollection<Movie>();
            this.Properties.Add("OBC", Items);
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
