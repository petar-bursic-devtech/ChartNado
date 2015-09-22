using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChartNado.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult EmployeesByMonth()
        {
            return View();
        }
    }
}