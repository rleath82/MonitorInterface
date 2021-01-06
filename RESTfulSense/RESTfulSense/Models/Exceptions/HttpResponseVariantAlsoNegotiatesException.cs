using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseVariantAlsoNegotiatesException : HttpResponseException
    {
        public HttpResponseVariantAlsoNegotiatesException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
