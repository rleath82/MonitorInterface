using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseRequestTimeoutException : HttpResponseException
    {
        public HttpResponseRequestTimeoutException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
