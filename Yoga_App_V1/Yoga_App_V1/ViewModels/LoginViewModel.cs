using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using Yoga_App_V1.Views;

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
namespace Yoga_App_V1.ViewModels
{
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Command CancelCommand { get; set; }

        public Command LoginCommand { get; set; }
        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        private bool rememberMe;
        public bool RememberMe {
            get => rememberMe;
            set
            {
                rememberMe = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RememberMe"));
            }
        }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnSubmit);
            CancelCommand = new Command(OnCancel);
            rememberMe = false;
        }
        private async void OnSubmit()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Form issue", "left empty", "continue");
            }
            else
            {
                var user = await App.Database.LoginUser(Email, Password);
                if (user != null)
                {
                    App.LoggedInUser = user;
                    if (RememberMe)
                    {
                        Application.Current.Properties["CurrentUser"] = user.Email;
                        await Application.Current.SavePropertiesAsync();
                        Debug.WriteLine("User Remembered");
                    }
                    await Shell.Current.GoToAsync("//" + nameof(AboutPage), false);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Form issue", "Email or password not recognised", "continue");
                }
            }
        }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("//" + nameof(AboutPage));
        }
    }
}
