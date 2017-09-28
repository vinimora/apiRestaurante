using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApiRestaurante
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //cada maproute é uma url, e ela manda para a controller, e a action é a funcao
            routes.MapRoute(
                name: "Home site",
                url: "",
                defaults: new { controller = "Site", action = "Index" }
            );
            routes.MapRoute(
                name: "Fale Conosco site",
                url: "fale-conosco",
                defaults: new { controller = "Site", action = "FaleConosco" }
            );
            routes.MapRoute(
                name: "Sobre Nos site",
                url: "sobre-nos",
                defaults: new { controller = "Site", action = "SobreNos" }
            );

            routes.MapRoute(
                name: "API",
                url: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
