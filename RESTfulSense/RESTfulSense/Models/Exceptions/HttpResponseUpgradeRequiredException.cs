using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseUpgradeRequiredException : HttpResponseException
    {
        public HttpResponseUpgradeRequiredException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
