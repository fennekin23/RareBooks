using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;

namespace Rb.Web.Ninject
{
    public class NinjectResolver : IDependencyResolver
    {
        public NinjectResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        public NinjectResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        public IKernel Kernel { get; private set; }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }
}