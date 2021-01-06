using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseUnauthorizedException : HttpResponseException
    {
        public HttpResponseUnauthorizedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
