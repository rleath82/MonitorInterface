using System;

namespace MonitorInterface.Client.Models.OracleResults.Exceptions
{
    public class OracleResultDependencyException : Exception
    {
        public OracleResultDependencyException(Exception innerException)
            : base("OracleResult dependency error occurred, contact support.", innerException) { }
    }
}
