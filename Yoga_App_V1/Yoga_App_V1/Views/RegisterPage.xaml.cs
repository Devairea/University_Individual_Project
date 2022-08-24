using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yoga_App_V1.Models;
using Yoga_App_V1.ViewModels;

namespace Yoga_App_V1.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            var vm = new RegisterViewModel();
            BindingContext = vm;
            RememberMe.CheckedChanged += (sender, e) => { vm.RememberMe = e.Value; };
        }
    }
}