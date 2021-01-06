using System;

namespace MonitorInterface.Client.Models.OracleResults.Exceptions
{
    public class OracleResultDependencyValidationException : Exception
    {
        public OracleResultDependencyValidationException(Exception innerException)
            : base("OracleResult dependency validation error occurred, try again.", innerException) { }
    }
}
