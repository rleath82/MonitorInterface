using System;

namespace MonitorInterface.Client.Models.OracleResults.Exceptions
{
    public class NullOracleResultException : Exception
    {
        public NullOracleResultException() : base("Null OracleResult error occurred.") { }
    }
}
