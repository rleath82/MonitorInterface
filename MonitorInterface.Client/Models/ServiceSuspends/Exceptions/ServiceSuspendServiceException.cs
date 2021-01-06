using System;

namespace MonitorInterface.Client.Models.ServiceSuspends.Exceptions
{
    public class ServiceSuspendServiceException : Exception
    {
        public ServiceSuspendServiceException(Exception innerException)
            : base("ServiceSuspend service error occurred, contact support.", innerException) { }
    }
}
