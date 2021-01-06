using System;

namespace MonitorInterface.Client.Models.RunTimeParameters.Exceptions
{
    public class RunTimeParameterValidationException : Exception
    {
        public RunTimeParameterValidationException(Exception innerException)
            : base("RunTimeParameter validation error occurred, try again.", innerException) { }
    }
}
