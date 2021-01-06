using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseUnsupportedMediaTypeException : HttpResponseException
    {
        public HttpResponseUnsupportedMediaTypeException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
