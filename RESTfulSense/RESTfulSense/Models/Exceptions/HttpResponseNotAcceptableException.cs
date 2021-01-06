using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseNotAcceptableException : HttpResponseException
    {
        public HttpResponseNotAcceptableException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
