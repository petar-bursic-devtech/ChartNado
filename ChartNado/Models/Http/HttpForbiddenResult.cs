namespace ChartNado.Models.Http
{
    using System.Net;
    using System.Web.Mvc;

    public class HttpForbiddenResult : HttpStatusCodeResult
    {
        public HttpForbiddenResult(int statusCode) : base(statusCode)
        {
        }

        public HttpForbiddenResult(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public HttpForbiddenResult(HttpStatusCode statusCode, string statusDescription)
            : base(statusCode, statusDescription)
        {
        }

        public HttpForbiddenResult(int statusCode, string statusDescription) : base(statusCode, statusDescription)
        {
        }

        // Implement extended properties as needed
    }
}