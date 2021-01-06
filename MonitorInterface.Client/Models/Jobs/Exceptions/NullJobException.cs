using System;

namespace MonitorInterface.Client.Models.Jobs.Exceptions
{
    public class NullJobException : Exception
    {
        public NullJobException() : base("Null Job error occurred.") { }
    }
}
