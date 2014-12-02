using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rb.Web.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IDependencyResolver m_resolver;

        public NinjectControllerFactory(IDependencyResolver resolver)
        {
            m_resolver = resolver;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) m_resolver.GetService(controllerType);
        }
    }
}