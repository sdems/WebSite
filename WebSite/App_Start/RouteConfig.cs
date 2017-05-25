using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Start",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Mariage",
                url:"Mariage/{guidId}",
                defaults: new { Controller="Mariage",action ="Index", guidId = new System.Web.Mvc.Routing.Constraints.GuidRouteConstraint() }
                );

            routes.MapRoute(
                name: "Mailing",
                url: "Mailing",
                defaults: new { Controller = "Mailing", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
