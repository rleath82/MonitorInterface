using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseNetworkAuthenticationRequiredException : HttpResponseException
    {
        public HttpResponseNetworkAuthenticationRequiredException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
