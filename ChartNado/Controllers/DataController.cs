using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChartNado.Controllers
{
    public class DataController : ApiController
    {
        // GET api/data
        public IHttpActionResult GetEmployees()
        {

            return Ok();
        }
             
    }
}
