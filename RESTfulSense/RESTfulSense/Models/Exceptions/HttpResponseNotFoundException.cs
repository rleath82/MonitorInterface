using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseNotFoundException : HttpResponseException
    {
        public HttpResponseNotFoundException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
