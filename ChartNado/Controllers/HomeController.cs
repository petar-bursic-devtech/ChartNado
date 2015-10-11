namespace ChartNado.Controllers
{
    using System.Web.Mvc;

    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        // this is our default route for the application
        [HttpGet]
        [Route("~/")] //    matches [/]             - ignores route prefix
        [Route("")] //      matches [/home]         - defines default route for the controller
        [Route("index")] // matches [/home/index]   - explicitly matches a given route
        public ActionResult Index()
        {
            return View();
        }
    }
}