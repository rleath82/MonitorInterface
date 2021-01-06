using System;

namespace MonitorInterface.Client.Models.Jobs.Exceptions
{
    public class JobDependencyException : Exception
    {
        public JobDependencyException(Exception innerException)
            : base("Job dependency error occurred, contact support.", innerException) { }
    }
}
