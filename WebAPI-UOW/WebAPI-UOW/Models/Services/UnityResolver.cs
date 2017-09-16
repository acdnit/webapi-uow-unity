﻿using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace WebAPI_UOW.Models.Services {
    public class UnityResolver : IDependencyResolver {
        protected IUnityContainer Container;

        public UnityResolver(IUnityContainer container) {
            Container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public object GetService(Type serviceType) {
            try {
                return Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException) {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            try {
                return Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException) {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope() {
            var child = Container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose() {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing) {
            Container.Dispose();
        }
    }
}