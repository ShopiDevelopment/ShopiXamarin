using System;
using System.Collections.Generic;
using ShopiXamarin.ViewModels.Profile;
using Xamarin.Forms;

namespace ShopiXamarin.Views.Profile
{
    public partial class ProfileView : ContentPage
    {
        public ProfileView()
        {
            InitializeComponent();
            this.BindingContext = AppContainer.Resolve<ProfileViewModel>();
        }
    }
}
