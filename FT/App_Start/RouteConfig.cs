using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Designer",
                url: "{controller}/{action}/{id}",
                defaults: new {},
                constraints: new {controller = "designer"}
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new {controller = "home", action = "index"}
                );
        }
    }
}
