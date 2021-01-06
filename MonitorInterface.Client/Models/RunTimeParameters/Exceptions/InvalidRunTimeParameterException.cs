using System;

namespace MonitorInterface.Client.Models.RunTimeParameters.Exceptions
{
    public class InvalidRunTimeParameterException : Exception
    {
        public InvalidRunTimeParameterException(string parameterName, object parameterValue)
            : base($"Invalid RunTimeParameter error occurred, parameter name: {parameterName}, parameter value: {parameterValue}") { }
    }
}
