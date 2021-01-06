using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseTooManyRequestsException : HttpResponseException
    {
        public HttpResponseTooManyRequestsException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
