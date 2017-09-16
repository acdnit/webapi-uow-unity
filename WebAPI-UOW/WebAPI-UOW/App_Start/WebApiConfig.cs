using System.Web.Http;
using WebAPI_UOW.App_Start;
using WebAPI_UOW.Models.Services;

namespace WebAPI_UOW {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new UnityResolver(UnityConfig.GetConfiguredContainer());

            config.Routes.MapHttpRoute("ListPersonApi", "api/person/list", new {controller = "Values", action = "GetListPerson"});
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
        }
    }
}