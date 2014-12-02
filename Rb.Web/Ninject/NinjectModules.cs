using Ninject.Modules;
using Ninject.Web.Common;
using Rb.Data;

namespace Rb.Web.Ninject
{
    public class NinjectModules
    {
        public static NinjectModule[] Modules
        {
            get { return new[] { new MainModule() }; }
        }

        //Main Module For Application.
        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind(typeof (RbDbContext)).ToSelf().InSingletonScope();
                Kernel.Bind(typeof (IRepository<>)).To(typeof (GenericRepository<>));
            }
        }
    }
}