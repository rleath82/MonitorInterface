using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseForbiddenException : HttpResponseException
    {
        public HttpResponseForbiddenException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
