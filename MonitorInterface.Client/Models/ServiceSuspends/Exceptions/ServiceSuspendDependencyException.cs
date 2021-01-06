using System;

namespace MonitorInterface.Client.Models.ServiceSuspends.Exceptions
{
    public class ServiceSuspendDependencyException : Exception
    {
        public ServiceSuspendDependencyException(Exception innerException)
            : base("ServiceSuspend dependency error occurred, contact support.", innerException) { }
    }
}
