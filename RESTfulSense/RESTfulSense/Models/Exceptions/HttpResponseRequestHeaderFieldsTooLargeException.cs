using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseRequestHeaderFieldsTooLargeException : HttpResponseException
    {
        public HttpResponseRequestHeaderFieldsTooLargeException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
