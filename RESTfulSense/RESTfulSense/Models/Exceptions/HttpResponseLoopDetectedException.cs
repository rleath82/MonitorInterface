using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseLoopDetectedException : HttpResponseException
    {
        public HttpResponseLoopDetectedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
