using System;
using Autofac;

namespace ShopiXamarin
{
    public class DependencyEngine
    {
        private static IContainer _container;
        private static bool isInitialized;

        public static void Initialize(IContainer container)
        {
            _container = container;
            isInitialized = true;
        }

        public static object Resolve(Type typeName)
        {
            if (!isInitialized)
                throw new Exception("Dependency Engine is not initialized.");

            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            if (!isInitialized)
                throw new Exception("Dependency Engine is not initialized.");

            return _container.Resolve<T>();
        }
    }
}
