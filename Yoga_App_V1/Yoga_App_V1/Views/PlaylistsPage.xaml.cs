using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yoga_App_V1.Models;
using Yoga_App_V1.ViewModels;
using Yoga_App_V1.Views;

namespace Yoga_App_V1.Views
{
    public partial class PlaylistsPage : ContentPage
    {
        PlaylistsViewModel _viewModel;

        public PlaylistsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PlaylistsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}