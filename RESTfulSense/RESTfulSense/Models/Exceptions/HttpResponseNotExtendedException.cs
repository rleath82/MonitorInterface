using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseNotExtendedException : HttpResponseException
    {
        public HttpResponseNotExtendedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
