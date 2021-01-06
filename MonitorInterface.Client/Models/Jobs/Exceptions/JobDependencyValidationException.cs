using System;

namespace MonitorInterface.Client.Models.Jobs.Exceptions
{
    public class JobDependencyValidationException : Exception
    {
        public JobDependencyValidationException(Exception innerException)
            : base("Job dependency validation error occurred, try again.", innerException) { }
    }
}
