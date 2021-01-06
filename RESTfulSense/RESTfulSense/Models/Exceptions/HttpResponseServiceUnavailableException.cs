using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseServiceUnavailableException : HttpResponseException
    {
        public HttpResponseServiceUnavailableException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
