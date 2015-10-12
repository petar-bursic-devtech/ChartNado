namespace ChartNado.Controllers.Dev
{
    using System;
    using System.Web.Mvc;
    using Models.Dev.Entities;
    using Models.Dev.Services;

    [RoutePrefix("dev/ioc")]
    public class DevIocController : Controller
    {
        private readonly IDevEmployeeService _devEmployeeService;

        public DevIocController(IDevEmployeeService devEmployeeService)
        {
            _devEmployeeService = devEmployeeService;
        }

        [HttpGet]
        [Route("employees", Name = "named_route_for_link")]
        public ActionResult Employees()
        {
            _devEmployeeService.SaveEmployee(new DevEmployee
            {
                Id = Guid.NewGuid(),
                FirstName = "Jon",
                LastName = "Dough",
                Salary = 10000.0M,
                Age = 30
            });

            _devEmployeeService.SaveEmployee(new DevEmployee
            {
                Id = Guid.NewGuid(),
                FirstName = "Sasha",
                LastName = "Grey",
                Salary = 20.0M,
                Age = 27
            });

            return View(_devEmployeeService.RetrieveEmployees());
        }
    }
}