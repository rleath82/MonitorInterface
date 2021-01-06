using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseRequestedRangeNotSatisfiableException : HttpResponseException
    {
        public HttpResponseRequestedRangeNotSatisfiableException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
