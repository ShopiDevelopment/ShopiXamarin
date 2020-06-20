using System;
using ShopiXamarin.Services.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopiXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppContainer.RegisterDependencies();
            AppContainer.Resolve<INavigationService>().InitializeAsync(false);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
