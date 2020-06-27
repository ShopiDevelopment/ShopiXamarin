using System;
using System.Collections.Generic;
using ShopiXamarin.ViewModels.Catalog;
using Xamarin.Forms;

namespace ShopiXamarin.Views.Catalog
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            this.BindingContext = AppContainer.Resolve<HomeViewModel>();
        }
    }
}
