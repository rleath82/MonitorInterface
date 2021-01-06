using System;

namespace MonitorInterface.Client.Models.OracleResults.Exceptions
{
    public class OracleResultServiceException : Exception
    {
        public OracleResultServiceException(Exception innerException)
            : base("OracleResult service error occurred, contact support.", innerException) { }
    }
}
