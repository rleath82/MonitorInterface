using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseNotImplementedException : HttpResponseException
    {
        public HttpResponseNotImplementedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
