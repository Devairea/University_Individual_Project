using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yoga_App_V1.Models;
using Yoga_App_V1.Services;
using Yoga_App_V1.Views;

namespace Yoga_App_V1
{
    public partial class App : Application
    {
        private static DBAccess dbaccess;
        private static User loggedinUser;
        public static DBAccess Database
        {
            get
            {
                if(dbaccess == null)
                {
                    dbaccess = new DBAccess();
                }
                return dbaccess;
            }
        }

        public static User LoggedInUser
        {
            get => loggedinUser;
            set => loggedinUser = value;
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<UserDataStore>();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            try
            {
                if (Application.Current.Properties["CurrentUser"] != null)
                {
                    LoggedInUser = await Database.GetUser(Application.Current.Properties["CurrentUser"].ToString());
                }
                else
                {
                    LoggedInUser = null;
                }
            }
            catch
            {
                LoggedInUser = null;
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
