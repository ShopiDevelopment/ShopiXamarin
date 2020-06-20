using System;
using Autofac;
using Xamarin.Forms;

namespace ShopiXamarin
{
    public  class AppContainer
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //View Models
            //builder.RegisterType<InitViewModel>();
            
            //Popup Models
            //builder.RegisterType<ForgotPasswordPopupModel>();
            
            //Services
            //builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            //builder.RegisterInstance(DependencyService.Get<IUtilities>()).As<IUtilities>().SingleInstance();
            
            //General
            //builder.RegisterType<Operations>().As<IOperations>().SingleInstance();
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
