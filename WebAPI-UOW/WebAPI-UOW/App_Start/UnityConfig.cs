using System;
using Microsoft.Practices.Unity;
using System.Web.Http;
using WebAPI_UOW.Controllers;
using WebAPI_UOW.Models.Repository;
using WebAPI_UOW.Models.Services;
using WebAPI_UOW.Models.Ef;

namespace WebAPI_UOW.App_Start {   
    public class UnityConfig {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() => {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer() {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container) {
            container.RegisterType<IApiUnitOfWork, ApiUnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor(new WebApiContext()));
            container.RegisterType<IPersonService, PersonService>();            
        }
    }
}
