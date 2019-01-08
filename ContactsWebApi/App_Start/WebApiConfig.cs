using ContactsWebApi.App_Start;
using ContactsWebApi.DependencyResolution;
using System.Web.Http;

namespace ContactsWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = IoC.Initialize();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            AutomapperConfig.Initialize(container);
        }
    }
}
