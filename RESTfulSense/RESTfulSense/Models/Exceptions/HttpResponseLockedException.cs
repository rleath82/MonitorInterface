using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseLockedException : HttpResponseException
    {
        public HttpResponseLockedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
