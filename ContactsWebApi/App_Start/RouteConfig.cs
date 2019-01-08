﻿using System.Web.Mvc;
using System.Web.Routing;

namespace ContactsWebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "DefaultArea",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Help", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ContactsWebApi.Areas.HelpPage.Controllers" }
            ).DataTokens.Add("Area", "HelpPage");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
