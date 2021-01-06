using System;

namespace MonitorInterface.Client.Models.RunTimeParameters.Exceptions
{
    public class NullRunTimeParameterException : Exception
    {
        public NullRunTimeParameterException() : base("Null RunTimeParameter error occurred.") { }
    }
}
