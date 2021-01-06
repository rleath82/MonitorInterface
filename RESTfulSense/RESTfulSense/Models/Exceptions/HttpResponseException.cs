using System;
using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpResponseMessage httpResponseMessage, string message)
            : base(message) => this.HttpResponseMessage = httpResponseMessage;

        public HttpResponseMessage HttpResponseMessage { get; private set; }
    }
}
