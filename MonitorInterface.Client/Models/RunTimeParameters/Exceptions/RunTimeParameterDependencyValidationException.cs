using System;

namespace MonitorInterface.Client.Models.RunTimeParameters.Exceptions
{
    public class RunTimeParameterDependencyValidationException : Exception
    {
        public RunTimeParameterDependencyValidationException(Exception innerException)
            : base("RunTimeParameter dependency validation error occurred, try again.", innerException) { }
    }
}
