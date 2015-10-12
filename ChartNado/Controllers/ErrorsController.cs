namespace ChartNado.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    ///     All errors handled by this controller should in the end
    ///     point to the generic error view.
    ///     Use specialized error views during the development phase.
    /// </summary>
    [RoutePrefix("errors")]
    public class ErrorsController : Controller
    {
        /// <summary>
        ///     HTTP request that was sent to the server has invalid syntax
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("badrequest")] // 400
        public ActionResult BadRequest()
        {
            return View("BadRequest");
        }

        /// <summary>
        ///     The user sending request is not AUTHENTICATED at all.
        ///     Or the user is AUTHENTICATED incorrectly.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("unauthorized")] // 401
        public ActionResult UnAuthorized()
        {
            return View("UnAuthorized");
        }

        /// <summary>
        ///     The user is not AUTHORIZED, regarding permissions based on Roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("forbidden")] // 403
        public ActionResult Forbidden()
        {
            return View("Forbidden");
        }

        /// <summary>
        ///     The resource was not found.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("notfound")] // 404
        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        /// <summary>
        ///     Internal server error.
        ///     Show generic error page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("internalservererror")] // 500
        public ActionResult InternalServerError()
        {
            return View("Generic");
        }
    }
}