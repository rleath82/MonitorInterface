using System;

namespace MonitorInterface.Client.Models.ServiceSuspends.Exceptions
{
    public class InvalidServiceSuspendException : Exception
    {
        public InvalidServiceSuspendException(string parameterName, object parameterValue)
            : base($"Invalid ServiceSuspend error occurred, parameter name: {parameterName}, parameter value: {parameterValue}") { }
    }
}
