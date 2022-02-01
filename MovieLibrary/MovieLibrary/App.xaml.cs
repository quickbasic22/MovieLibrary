using MovieLibrary.Models;
using MovieLibrary.Services;
using MovieLibrary.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MovieLibrary
{
    public partial class App : Application
    {
        public IDataStore<Movie> DataStore;
        public ObservableCollection<Movie> Items;
        public ItemsViewModel ItemsModel;

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DataStore = DependencyService.Get<IDataStore<Movie>>();          
            this.Properties.Add("DataStore", DataStore);
            Items = new ObservableCollection<Movie>();
            this.Properties.Add("ObserveMovies", Items);
            ItemsModel = new ItemsViewModel();
            this.Properties.Add("ItemsModel", ItemsModel);
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
