using System;
using System.Collections.Generic;
using ShopiXamarin.ViewModels.Bag;
using Xamarin.Forms;

namespace ShopiXamarin.Views.Bag
{
    public partial class ShoppingBagView : ContentPage
    {
        public ShoppingBagView()
        {
            InitializeComponent();
            this.BindingContext = AppContainer.Resolve<ShoppingBagViewModel>();
        }
    }
}
