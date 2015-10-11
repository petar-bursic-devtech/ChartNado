namespace ChartNado.Models.Http
{
    using System.Net;
    using System.Web.Mvc;

    public class HttpBadRequestResult : HttpStatusCodeResult
    {
        public HttpBadRequestResult(int statusCode) : base(statusCode)
        {
        }

        public HttpBadRequestResult(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public HttpBadRequestResult(HttpStatusCode statusCode, string statusDescription)
            : base(statusCode, statusDescription)
        {
        }

        public HttpBadRequestResult(int statusCode, string statusDescription) : base(statusCode, statusDescription)
        {
        }

        // Implement extended properties as needed
    }
}