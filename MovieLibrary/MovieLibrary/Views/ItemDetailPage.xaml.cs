using MovieLibrary.ViewModels;
using Xamarin.Forms;

namespace MovieLibrary.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailViewModel _ItemDetails;
        public ItemDetailPage()
        { 
            InitializeComponent();
            BindingContext = _ItemDetails = new ItemDetailViewModel();
        }
    }
}