using System;

namespace MonitorInterface.Client.Models.RunTimeParameters.Exceptions
{
    public class RunTimeParameterServiceException : Exception
    {
        public RunTimeParameterServiceException(Exception innerException)
            : base("RunTimeParameter service error occurred, contact support.", innerException) { }
    }
}
