using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseBadRequestException : HttpResponseException
    {
        public HttpResponseBadRequestException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
