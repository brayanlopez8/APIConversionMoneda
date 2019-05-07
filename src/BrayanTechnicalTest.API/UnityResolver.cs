using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Exceptions;

namespace API.Resolver
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer _contenedor;
        public UnityResolver(IUnityContainer contenedor)
        {
            if (contenedor == null)
            {
                throw new ArgumentException("Contenedor Vacio");
            }
            _contenedor = contenedor;
        }
        public IDependencyScope BeginScope()
        {
            var Child = _contenedor.CreateChildContainer();
            return new UnityResolver(Child);
        }

        public void Dispose()
        {
            _contenedor.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _contenedor.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _contenedor.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
    }
}