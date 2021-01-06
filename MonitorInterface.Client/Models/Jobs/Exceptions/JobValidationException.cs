using System;

namespace MonitorInterface.Client.Models.Jobs.Exceptions
{
    public class JobValidationException : Exception
    {
        public JobValidationException(Exception innerException)
            : base("Job validation error occurred, try again.", innerException) { }
    }
}
