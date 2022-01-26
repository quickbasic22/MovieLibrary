using MovieLibrary.ViewModels;
using Xamarin.Forms;

namespace MovieLibrary.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        { 
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}