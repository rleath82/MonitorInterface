﻿using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponsePreconditionRequiredException : HttpResponseException
    {
        public HttpResponsePreconditionRequiredException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
