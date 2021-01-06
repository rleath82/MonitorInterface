using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseGatewayTimeoutException : HttpResponseException
    {
        public HttpResponseGatewayTimeoutException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
