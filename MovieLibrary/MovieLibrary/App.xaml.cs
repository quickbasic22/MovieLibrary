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
        public IDataStore<Movie> DataStore;
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DataStore = DependencyService.Get<IDataStore<Movie>>();
            this.Properties.Add("StoreData", DataStore);
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Console.WriteLine("OnStart Fired");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("OnSleep Fired");
        }

        protected override void OnResume()
        {
            Console.WriteLine("OnResume Fired");
        }
    }
}
