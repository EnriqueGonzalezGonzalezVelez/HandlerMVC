using Conceptos2Mvc.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HandlersPost
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            List<String> bloqueos = new List<string>();
            bloqueos.Add("magreb");
            bloqueos.Add("opinion");

            RouteTable.Routes.Add("Noticias", new Route("Noticias/{noticia}", new RouteWiki(bloqueos)));



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
