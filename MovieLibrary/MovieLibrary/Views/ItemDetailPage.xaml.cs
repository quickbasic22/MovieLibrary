using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieLibrary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailPage _itemDetailPage;
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = _itemDetailPage = new ItemDetailPage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _itemDetailPage.OnAppearing();
        }
    }
}