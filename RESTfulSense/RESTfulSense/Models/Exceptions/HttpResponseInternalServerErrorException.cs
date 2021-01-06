using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseInternalServerErrorException : HttpResponseException
    {
        public HttpResponseInternalServerErrorException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
