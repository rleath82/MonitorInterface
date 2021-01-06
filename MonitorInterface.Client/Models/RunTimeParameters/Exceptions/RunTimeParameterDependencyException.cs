using System;

namespace MonitorInterface.Client.Models.RunTimeParameters.Exceptions
{
    public class RunTimeParameterDependencyException : Exception
    {
        public RunTimeParameterDependencyException(Exception innerException)
            : base("RunTimeParameter dependency error occurred, contact support.", innerException) { }
    }
}
