using System;

namespace MonitorInterface.Client.Models.ServiceSuspends.Exceptions
{
    public class ServiceSuspendValidationException : Exception
    {
        public ServiceSuspendValidationException(Exception innerException)
            : base("ServiceSuspend validation error occurred, try again.", innerException) { }
    }
}
