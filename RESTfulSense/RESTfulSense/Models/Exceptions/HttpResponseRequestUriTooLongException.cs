using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseRequestUriTooLongException : HttpResponseException
    {
        public HttpResponseRequestUriTooLongException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
