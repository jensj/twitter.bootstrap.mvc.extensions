using System.Web.Mvc;
using System.Web.Routing;
using MvcApplication_EricHexter_Bootstrap.NavigationRoutes;

namespace MvcApplication_EricHexter_Bootstrap.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //This is the first Navigation route
            //                          RouteName        DisplayName    Url   Defaults
            routes.MapNavigationRoute("Home-navigation", "Home", "", new { controller = "Home", action = "Index" });
            //This is the second Navigation route
            //                          RouteName        DisplayName    Url   Defaults
            routes.MapNavigationRoute("About-navigation", "About", "about", new { controller = "Home", action = "About" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}