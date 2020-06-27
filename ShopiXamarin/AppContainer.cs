using System;
using _ShopiXamarin.Network;
using Autofac;
using ShopiXamarin.Services;
using ShopiXamarin.Services.Contracts;
using Xamarin.Forms;

namespace ShopiXamarin
{
    public  class AppContainer
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //View Models
            builder.RegisterType<ViewModels.Authentication.LoginViewModel>();
            builder.RegisterType<ViewModels.MainViewModel>();
            builder.RegisterType<ViewModels.Catalog.HomeViewModel>();
            builder.RegisterType<ViewModels.Bag.ShoppingBagViewModel>();
            builder.RegisterType<ViewModels.Profile.ProfileViewModel>();
            
            //Popup Models
            //builder.RegisterType<ForgotPasswordPopupModel>();
            
            //Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<AppCenterAnalyticService>().As<IAnalyticService>().SingleInstance();
            builder.RegisterType<PopupService>().As<IPopupService>().SingleInstance();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
            //builder.RegisterInstance(DependencyService.Get<IUtilities>()).As<IUtilities>().SingleInstance();
            
            //General
            builder.RegisterType<Operations>().As<IOperations>().SingleInstance();
            DependencyEngine.Initialize(builder.Build());
        }

        public static void RegisterCustom<T, TImpl>()
            where T : class
            where TImpl : class, T
        {
            DependencyService.Register<T, TImpl>();
        }

        public static object Resolve(Type typeName)
        {
            return DependencyEngine.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return DependencyEngine.Resolve<T>();
        }
    }
}
