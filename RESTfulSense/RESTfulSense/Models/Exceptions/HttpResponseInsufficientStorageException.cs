using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseInsufficientStorageException : HttpResponseException
    {
        public HttpResponseInsufficientStorageException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
