using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Yoga_App_V1.Models;
using Yoga_App_V1.Views;

namespace Yoga_App_V1.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command UserPageCommand { get; }
        public string DisplayWord { get; set; }
        public AboutViewModel()
        {
            Title = "Home";
            string register = "Register";
            try
            {
                string value = App.LoggedInUser.FullName;
                DisplayWord = value ?? register;
            }
            catch
            {
                DisplayWord = register;
            }
            if (DisplayWord != register)
                UserPageCommand = new Command(OnUserSettingsCommand);
            else
                UserPageCommand = new Command(OnRegisterPageCommand);
        }

        async void OnRegisterPageCommand()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        async void OnUserSettingsCommand()
        {
            if (App.LoggedInUser == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(UserManagementPage)}?{nameof(UserManagementViewModel.Email)}={App.LoggedInUser.Email}");
        }
    }
}