namespace ChartNado
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Controllers;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            if (Context.IsCustomErrorEnabled)
            {
                ShowCustomErrorPage(Server.GetLastError());
            }
        }

        private void ShowCustomErrorPage(Exception exception)
        {
            var httpException = exception as HttpException ?? new HttpException(500, "Internal Server Error", exception);

            Response.Clear();
            var routeData = new RouteData();
            routeData.Values.Add("controller", "errors");
            routeData.Values.Add("fromAppErrorEvent", true);

            switch (httpException.GetHttpCode())
            {
                case 403:
                    routeData.Values.Add("action", "forbidden");
                    break;
                case 404:
                    routeData.Values.Add("action", "notfound");
                    break;
                case 500:
                    routeData.Values.Add("action", "internalservererror");
                    break;
                default:
                    routeData.Values.Add("action", "generic");
                    routeData.Values.Add("httpStatusCode", httpException.GetHttpCode());
                    break;
            }

            Server.ClearError();

            IController controller = new ErrorsController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}