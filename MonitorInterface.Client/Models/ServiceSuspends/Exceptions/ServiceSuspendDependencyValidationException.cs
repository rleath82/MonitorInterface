using System;

namespace MonitorInterface.Client.Models.ServiceSuspends.Exceptions
{
    public class ServiceSuspendDependencyValidationException : Exception
    {
        public ServiceSuspendDependencyValidationException(Exception innerException)
            : base("ServiceSuspend dependency validation error occurred, try again.", innerException) { }
    }
}
