using MovieLibrary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieLibrary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}