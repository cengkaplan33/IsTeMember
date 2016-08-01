using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Membership.Site.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            //);

            //Membership ile başlayan lar için
            var route = routes.MapRoute(
                 "Membership", // Route name
                 "Membership/{controller}/{action}/{id}", // URL with parameters
                 new { controller = "Application", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                 new string[] { "Membership.Site.Controllers" }
             ).DataTokens["UseNamespaceFallback"] = false;

            route = routes.MapRoute(
                   "Default", // Route name
                   "{controller}/{action}/{id}", // URL with parameters
                   new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                   new string[] { "Membership.Site.Controllers" }
               ).DataTokens["UseNamespaceFallback"] = false;

            routes.MapRoute(
                "Root", // Route name
                "", // URL with parameters
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[] { "Membership.Site.Controllers" }
            ).DataTokens["UseNamespaceFallback"] = false;


        }
    }
}