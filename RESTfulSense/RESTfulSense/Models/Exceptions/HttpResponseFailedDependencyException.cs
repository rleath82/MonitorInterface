﻿using System.Net.Http;

namespace RESTfulSense.Models.Exceptions
{
    public class HttpResponseFailedDependencyException : HttpResponseException
    {
        public HttpResponseFailedDependencyException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
