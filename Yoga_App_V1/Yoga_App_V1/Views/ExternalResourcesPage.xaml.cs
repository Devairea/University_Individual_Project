using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yoga_App_V1.ViewModels;

namespace Yoga_App_V1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExternalResourcesPage : ContentPage
    {
        public ExternalResourcesPage()
        {
            InitializeComponent();
            BindingContext = new ExternalResourcesViewModel();
        }
    }
}