using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Yoga_App_V1.Models;
using Yoga_App_V1.Views;

namespace Yoga_App_V1.ViewModels
{
    [QueryProperty(nameof(Email), nameof(Email))]
    public class UserManagementViewModel : BaseViewModel
    {
        private string email;
        private User user;
        private List<string> badges;
        public Command LogoutCommand { get; }

        public UserManagementViewModel()
        {
            LogoutCommand = new Command(async () => await ExecuteLogoutCommand());
        }

        public User DisplayedUser
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        public List<string> Badges
        {
            get => badges;
            set => SetProperty(ref badges, value);
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                LoadUser(value);
            }
        }

        private void LoadUser(string checkEmail)
        {
            if (App.LoggedInUser.Email == checkEmail)
            {
                DisplayedUser = App.LoggedInUser;
                TimeSpan ts = DateTime.Now - DisplayedUser.RegisterDate;
                Badges = new List<string>
                {
                    "Days Joined: " + ts.Days
                };
            }
        }
        // TODO: Load state from previously suspended application
        private async Task ExecuteLogoutCommand()
        {
            App.LoggedInUser = null;
            Debug.WriteLine("User Model removal successful");
            Application.Current.Properties["CurrentUser"] = null;
            await Application.Current.SavePropertiesAsync();
            Debug.WriteLine("Property Removal Successful");
            await Shell.Current.GoToAsync("//" + nameof(AboutPage), false);
        }
    }
}
