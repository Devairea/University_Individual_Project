using System.ComponentModel;
using Xamarin.Forms;
using Yoga_App_V1.ViewModels;

namespace Yoga_App_V1.Views
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