using MonitorInterface.Client.Models.ServiceSuspends;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Brokers.API
{
    public partial interface IApiBroker
    {
        Task<List<ServiceSuspend>> GetJobStatusesAsync();
        Task<ServiceSuspend> UpdateJobStatusesAsync(ServiceSuspend serviceSuspend);
        Task<ServiceSuspend> RemoveDownTimesAsync(ServiceSuspend serviceSuspend);
    }
}
