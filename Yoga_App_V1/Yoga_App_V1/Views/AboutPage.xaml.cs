using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yoga_App_V1.ViewModels;

namespace Yoga_App_V1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            Title = "Home";
        }

        protected async override void OnAppearing()
        {
            try
            {
                if (App.LoggedInUser == null && Application.Current.Properties["CurrentUser"] != null)
                {
                    App.LoggedInUser = await App.Database.GetUser(Application.Current.Properties["CurrentUser"].ToString());
                }
                BindingContext = new AboutViewModel();
                base.OnAppearing();
            }
            catch
            {

            }
        }
    }
}