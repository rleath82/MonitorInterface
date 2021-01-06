using System;

namespace MonitorInterface.Client.Models.Jobs.Exceptions
{
    public class InvalidJobException : Exception
    {
        public InvalidJobException(string parameterName, object parameterValue)
            : base($"Invalid Job error occurred, parameter name: {parameterName}, parameter value: {parameterValue}") { }
    }
}
