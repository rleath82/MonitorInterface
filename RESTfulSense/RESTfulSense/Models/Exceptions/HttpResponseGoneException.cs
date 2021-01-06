using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseGoneException : HttpResponseException
    {
        public HttpResponseGoneException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
