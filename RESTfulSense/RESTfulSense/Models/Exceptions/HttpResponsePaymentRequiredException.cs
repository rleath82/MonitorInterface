using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponsePaymentRequiredException : HttpResponseException
    {
        public HttpResponsePaymentRequiredException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
