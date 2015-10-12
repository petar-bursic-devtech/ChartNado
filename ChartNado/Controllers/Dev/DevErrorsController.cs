namespace ChartNado.Controllers.Dev
{
    using System;
    using System.Web.Mvc;
    using Models.Http;

    [RoutePrefix("dev/errors")]
    public class DevErrorsController : Controller
    {
        [HttpGet]
        [Route("badrequest")]
        public ActionResult InvokeBadRequest()
        {
            return this.HttpBadRequest();
        }

        [HttpGet]
        [Route("unauthorized")]
        public ActionResult InvokeUnAuthorized()
        {
            return this.HttpUnAuthorized();
        }

        [HttpGet]
        [Route("forbidden")]
        public ActionResult InvokeForbidden()
        {
            return this.HttpForbidden();
        }

        [HttpGet]
        [Route("notfound")]
        public ActionResult InvokeNotFound()
        {
            return HttpNotFound(); // this one already exists, others were added as an extension methods
        }

        [HttpGet]
        [Route("internalservererror")]
        public ActionResult InvokeInternalServerError()
        {
            return this.HttpInternalServerError();
        }

        [HttpGet]
        [Route("genericexception")]
        public ActionResult InvokeGenericException()
        {
            throw new NotImplementedException();
        }
    }
}