using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseMethodNotAllowedException : HttpResponseException
    {
        public HttpResponseMethodNotAllowedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
