namespace ChartNado.Models.Http
{
    using System.Net;
    using System.Web.Mvc;

    public static class ControllerExtensions
    {
        /// <summary>
        ///     Generate Http Forbidden result.
        ///     Inside Controller - call it with this.HttpForbidden()
        ///     Outside of the Controller - call it on the instance of the Controller
        /// </summary>
        /// <param name="controller">Mvc Controller</param>
        /// <returns>HttpForbiddenResult initialized to appropriate Http Status Code</returns>
        public static HttpForbiddenResult HttpForbidden(this Controller controller)
        {
            return new HttpForbiddenResult(HttpStatusCode.Forbidden);
        }

        /// <summary>
        ///     Generate Http Forbidden result with additional description.
        ///     Inside Controller - call it with this.HttpForbidden("status description")
        ///     Outside of the Controller - call it on the instance of the Controller
        /// </summary>
        /// <param name="controller">Mvc Controller</param>
        /// <param name="statusDescription">String status description</param>
        /// <returns>HttpForbiddenResult initialized to appropriate Http Status Code with message</returns>
        public static HttpForbiddenResult HttpForbidden(this Controller controller, string statusDescription)
        {
            return new HttpForbiddenResult(HttpStatusCode.Forbidden, statusDescription);
        }

        /// <summary>
        ///     Generate Http Bad Request result.
        ///     Inside Controller - call it with this.HttpBadRequest()
        ///     Outside of the Controller - call it on the instance of the Controller
        /// </summary>
        /// <param name="controller">Mvc Controller</param>
        /// <returns>HttpBadRequestResult initialized to appropriate Http Status Code</returns>
        public static HttpBadRequestResult HttpBadRequest(this Controller controller)
        {
            return new HttpBadRequestResult(HttpStatusCode.BadRequest);
        }

        /// <summary>
        ///     Generate Http Bad Request result.
        ///     Inside Controller - call it with this.HttpBadRequest("status description")
        ///     Outside of the Controller - call it on the instance of the Controller
        /// </summary>
        /// <param name="controller">Mvc Controller</param>
        /// <param name="statusDescription">String status description</param>
        /// <returns>HttpBadRequestResult initialized to appropriate Http Status Code with message</returns>
        public static HttpBadRequestResult HttpBadRequest(this Controller controller, string statusDescription)
        {
            return new HttpBadRequestResult(HttpStatusCode.BadRequest, statusDescription);
        }

        /// <summary>
        ///     Generate Http Unauthorized result.
        ///     Inside Controller - call it with this.HttpUnAuthorized()
        ///     Outside of the Controller - call it on the instance of the Controller
        /// </summary>
        /// <param name="controller">Mvc Controller</param>
        /// <returns>HttpUnAuthorizedResult initialized to appropriate Http Status Code</returns>
        public static HttpUnAuthorizedResult HttpUnAuthorized(this Controller controller)
        {
            return new HttpUnAuthorizedResult(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        ///     Generate Http Unauthorized result.
        ///     Inside Controller - call it with this.HttpUnAuthorized("status description")
        ///     Outside of the Controller - call it on the instance of the Controller
        /// </summary>
        /// <param name="controller">Mvc Controller</param>
        /// <param name="statusDescription">String status description</param>
        /// <returns>HttpUnAuthorizedResult initialized to appropriate Http Status Code with message</returns>
        public static HttpUnAuthorizedResult HttpUnAuthorized(this Controller controller, string statusDescription)
        {
            return new HttpUnAuthorizedResult(HttpStatusCode.Unauthorized, statusDescription);
        }

        /// <summary>
        ///     Generate Http Internal Server Error result.
        ///     Inside Controller - call it with this.HttpInternalServerError()
        ///     Outside of the Controller - call it on the instance of the Controller
        /// </summary>
        /// <param name="controller">Mvc Controller</param>
        /// <returns>HttpInternalServerErrorResult initialized to appropriate Http Status Code</returns>
        public static HttpInternalServerErrorResult HttpInternalServerError(this Controller controller)
        {
            return new HttpInternalServerErrorResult(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        ///     Generate Http Internal Server Error result.
        ///     Inside Controller - call it with this.HttpInternalServerError("status description")
        ///     Outside of the Controller - call it on the instance of the Controller
        /// </summary>
        /// <param name="controller">Mvc Controller</param>
        /// <param name="statusDescription">String status description</param>
        /// <returns>HttpInternalServerErrorResult initialized to appropriate Http Status Code with message</returns>
        public static HttpInternalServerErrorResult HttpInternalServerError(this Controller controller,
            string statusDescription)
        {
            return new HttpInternalServerErrorResult(HttpStatusCode.InternalServerError, statusDescription);
        }
    }
}