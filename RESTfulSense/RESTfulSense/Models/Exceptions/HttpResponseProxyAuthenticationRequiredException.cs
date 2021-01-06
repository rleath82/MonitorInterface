using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseProxyAuthenticationRequiredException : HttpResponseException
    {
        public HttpResponseProxyAuthenticationRequiredException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
