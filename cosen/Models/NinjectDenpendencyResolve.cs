using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
namespace cosen.Models
{
    public class NinjectDenpendencyResolve : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectDenpendencyResolve()
        {
            this._kernel = new StandardKernel();
            this._kernel.Settings.InjectNonPublic = true;
            this.AddBindings();
        }

        private void AddBindings()
        {
            this._kernel.Bind<ILogicModel>().To<LogicModel>();
        }
        public object GetService(Type serviceType)
        {
            return this._kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._kernel.GetAll(serviceType);
        }
    }
}