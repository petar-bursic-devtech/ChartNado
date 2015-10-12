namespace ChartNado.Models.Http
{
    using System.Net;
    using System.Web.Mvc;

    public class HttpUnAuthorizedResult : HttpStatusCodeResult
    {
        public HttpUnAuthorizedResult(int statusCode) : base(statusCode)
        {
        }

        public HttpUnAuthorizedResult(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public HttpUnAuthorizedResult(HttpStatusCode statusCode, string statusDescription)
            : base(statusCode, statusDescription)
        {
        }

        public HttpUnAuthorizedResult(int statusCode, string statusDescription) : base(statusCode, statusDescription)
        {
        }

        // Implement extended properties as needed
    }
}