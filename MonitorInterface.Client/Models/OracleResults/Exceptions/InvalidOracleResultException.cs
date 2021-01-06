using System;

namespace MonitorInterface.Client.Models.OracleResults.Exceptions
{
    public class InvalidOracleResultException : Exception
    {
        public InvalidOracleResultException(string parameterName, object parameterValue)
            : base($"Invalid OracleResult error occurred, parameter name: {parameterName}, parameter value: {parameterValue}") { }
    }
}
