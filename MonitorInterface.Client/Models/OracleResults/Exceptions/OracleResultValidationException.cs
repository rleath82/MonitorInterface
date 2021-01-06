using System;

namespace MonitorInterface.Client.Models.OracleResults.Exceptions
{
    public class OracleResultValidationException : Exception
    {
        public OracleResultValidationException(Exception innerException)
            : base("OracleResult validation error occurred, try again.", innerException) { }
    }
}
