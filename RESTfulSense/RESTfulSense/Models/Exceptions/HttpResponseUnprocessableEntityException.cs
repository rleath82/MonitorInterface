using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseUnprocessableEntityException : HttpResponseException
    {
        public HttpResponseUnprocessableEntityException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
