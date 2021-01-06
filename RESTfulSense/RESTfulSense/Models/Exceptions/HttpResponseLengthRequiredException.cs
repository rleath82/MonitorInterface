using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseLengthRequiredException : HttpResponseException
    {
        public HttpResponseLengthRequiredException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
