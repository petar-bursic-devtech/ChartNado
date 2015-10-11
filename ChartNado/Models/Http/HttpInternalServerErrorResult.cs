namespace ChartNado.Models.Http
{
    using System.Net;
    using System.Web.Mvc;

    public class HttpInternalServerErrorResult : HttpStatusCodeResult
    {
        public HttpInternalServerErrorResult(int statusCode) : base(statusCode)
        {
        }

        public HttpInternalServerErrorResult(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public HttpInternalServerErrorResult(HttpStatusCode statusCode, string statusDescription)
            : base(statusCode, statusDescription)
        {
        }

        public HttpInternalServerErrorResult(int statusCode, string statusDescription)
            : base(statusCode, statusDescription)
        {
        }

        // Implement extended properties as needed
    }
}