using System;

namespace MonitorInterface.Client.Models.ServiceSuspends.Exceptions
{
    public class NullServiceSuspendException : Exception
    {
        public NullServiceSuspendException() : base("Null ServiceSuspend error occurred.") { }
    }
}
