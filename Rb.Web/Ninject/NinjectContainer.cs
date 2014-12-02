using System.Reflection;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;

namespace Rb.Web.Ninject
{
    public class NinjectContainer
    {
        private static NinjectResolver s_resolver;

        public static void RegisterAssembly()
        {
            s_resolver = new NinjectResolver(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(s_resolver);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(s_resolver));
        }

        public static void RegisterModules(NinjectModule[] modules)
        {
            s_resolver = new NinjectResolver(modules);
            DependencyResolver.SetResolver(s_resolver);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(s_resolver));
        }

        //Manually Resolve Dependencies
        public static T Resolve<T>()
        {
            return s_resolver.Kernel.Get<T>();
        }
    }
}