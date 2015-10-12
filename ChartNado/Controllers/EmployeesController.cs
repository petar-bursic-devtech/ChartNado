namespace ChartNado.Controllers
{
    using System.Web.Mvc;

    [RoutePrefix("employees")]
    public class EmployeesController : Controller
    {
        [HttpGet]
        [Route]
        public ActionResult EmployeesByMonth()
        {
            return View();
        }
    }
}