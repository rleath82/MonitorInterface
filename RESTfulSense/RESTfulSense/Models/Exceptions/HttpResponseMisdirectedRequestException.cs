using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseMisdirectedRequestException : HttpResponseException
    {
        public HttpResponseMisdirectedRequestException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
