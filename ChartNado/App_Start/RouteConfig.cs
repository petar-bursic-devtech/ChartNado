namespace ChartNado
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // enable attribute routing, no longer using convention routing
            routes.MapMvcAttributeRoutes();
        }
    }
}