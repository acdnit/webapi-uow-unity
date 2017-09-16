using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebAPI_UOW.App_Start.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebAPI_UOW.App_Start.UnityWebActivator), "Shutdown")]

namespace WebAPI_UOW.App_Start {
    public static class UnityWebActivator {
        public static void Start() {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void Shutdown() {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}