using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseConflictException : HttpResponseException
    {
        public HttpResponseConflictException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
