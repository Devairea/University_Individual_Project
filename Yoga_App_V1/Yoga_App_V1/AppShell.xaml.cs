using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Yoga_App_V1.ViewModels;
using Yoga_App_V1.Views;

namespace Yoga_App_V1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(PlaylistDetailPage), typeof(PlaylistDetailPage));
            Routing.RegisterRoute(nameof(UserManagementPage), typeof(UserManagementPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ExternalResourcesPage), typeof(ExternalResourcesPage));
        }
    }
}
