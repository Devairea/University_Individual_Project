using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Yoga_App_V1.Models;
using Yoga_App_V1.Views;

namespace Yoga_App_V1.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string email;
        private string password;
        private string confirmpassword;
        private string firstname;
        private string lastname;
        private DateTime birthdate;
        private string freetime;
        private bool rememberMe;

        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }
        public Command LoginNavigateCommand { get; }

        public DateTime MinDOB { get { return DateTime.Now.AddYears(-100); } }
        public DateTime MaxDOB { get { return DateTime.Now.AddYears(-18); } }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegister, ValidateRegister);
            CancelCommand = new Command(OnCancel);
            LoginNavigateCommand = new Command(OnLoginNavigate);
            this.PropertyChanged +=
                (_, __) => RegisterCommand.ChangeCanExecute();
            rememberMe = false;
        }
        private bool ValidateRegister()
        {
            return !string.IsNullOrWhiteSpace(email)
                && !string.IsNullOrWhiteSpace(password)
                && !string.IsNullOrWhiteSpace(firstname)
                && !string.IsNullOrWhiteSpace(lastname)
                && !string.IsNullOrWhiteSpace(freetime)
                && password.Equals(confirmpassword);
                //&& !(birthdate < MinDOB) && !(birthdate > MaxDOB)
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string ConfrimPassword
        {
            get => confirmpassword;
            set => SetProperty(ref confirmpassword, value);
        }
        public string FirstName
        {
            get => firstname;
            set => SetProperty(ref firstname, value);
        }
        public string LastName
        {
            get => lastname;
            set => SetProperty(ref lastname, value);
        }
        public DateTime BirthDate
        {
            get => birthdate;
            set => SetProperty(ref birthdate, value);
        }
        public string FreeTime
        {
            get => freetime;
            set => SetProperty(ref freetime, value);
        }
        public bool RememberMe
        {
            get => rememberMe;
            set
            {
                SetProperty(ref rememberMe, value);
            }
        }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("//" + nameof(AboutPage));
        }
        private async void OnLoginNavigate()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
        private async void OnRegister()
        {
            User newUser = new User()
            {
                Email = Email,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
                FreeTime = FreeTime,
                RegisterDate = DateTime.Now
            };

            if(await App.Database.RegisterUser(newUser))
            {
                App.LoggedInUser = newUser;
                if (RememberMe)
                {
                    Application.Current.Properties["CurrentUser"] = newUser.Email;
                    await Application.Current.SavePropertiesAsync();
                    Debug.WriteLine("User Remembered");
                }



                //await DataStore.AddItemAsync(newUser);
                Debug.WriteLine("Registeration Successful");

                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("//" + nameof(AboutPage));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Form issue", "That email already exists", "continue");
            }
        }
    }
}
