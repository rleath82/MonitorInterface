using System;

namespace MonitorInterface.Client.Models.Jobs.Exceptions
{
    public class JobServiceException : Exception
    {
        public JobServiceException(Exception innerException)
            : base("Job service error occurred, contact support.", innerException) { }
    }
}
