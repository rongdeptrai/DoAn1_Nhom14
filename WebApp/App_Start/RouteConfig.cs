using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomeUs", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "AuthSingin",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Auth", action = "Singin", id = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "AuthLogout",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Auth", action = "Logout", id = UrlParameter.Optional }
         );
        }
    }
}
