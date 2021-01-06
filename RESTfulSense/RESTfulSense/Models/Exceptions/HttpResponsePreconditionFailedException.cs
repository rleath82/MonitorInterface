using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponsePreconditionFailedException : HttpResponseException
    {
        public HttpResponsePreconditionFailedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
