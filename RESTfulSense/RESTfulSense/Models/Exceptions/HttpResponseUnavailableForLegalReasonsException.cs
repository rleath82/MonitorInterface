using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseUnavailableForLegalReasonsException : HttpResponseException
    {
        public HttpResponseUnavailableForLegalReasonsException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
