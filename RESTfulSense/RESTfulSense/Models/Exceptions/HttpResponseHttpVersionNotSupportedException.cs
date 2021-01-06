using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseHttpVersionNotSupportedException : HttpResponseException
    {
        public HttpResponseHttpVersionNotSupportedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
