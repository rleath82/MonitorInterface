using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseBadGatewayException : HttpResponseException
    {
        public HttpResponseBadGatewayException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
