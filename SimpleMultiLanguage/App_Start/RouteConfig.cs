using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleMultiLanguage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "about",
                url: "{lang}/about",
                constraints: new { lang = "tr|en" },
                defaults: new { controller = "home", action = "about", lang = "en" }

            );

            routes.MapRoute(
                name: "Default",
                url: "{lang}/{controller}/{action}/{id}",
                constraints: new { lang = "tr|en" },
                defaults: new { controller = "Home", action = "Index", lang = "en", id = UrlParameter.Optional },
                namespaces: new[] { string.Format("{0}.Controllers", BuildManager.GetGlobalAsaxType().BaseType.Assembly.GetName().Name) }
            );
            routes.MapRoute(
             name: "DefaultEn",
             url: "{controller}/{action}/{id}",

             defaults: new { controller = "Home", action = "Index", lang = "en", id = UrlParameter.Optional },
             namespaces: new[] { string.Format("{0}.Controllers", BuildManager.GetGlobalAsaxType().BaseType.Assembly.GetName().Name) }
         );
        }
    }
}
