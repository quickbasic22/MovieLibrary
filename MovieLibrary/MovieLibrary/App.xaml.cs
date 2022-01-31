using MovieLibrary.Models;
using MovieLibrary.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

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
            this.Properties.Add("DataStore", DataStore);  
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
