using MonitorInterface.Client.Models.ServiceSuspends;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.ServiceManager
{
    public interface IServiceManagerService
    {
        Task<List<ServiceSuspend>> GetJobStatuses();
        Task<ServiceSuspend> UpdateJobStatuses(ServiceSuspend serviceSuspend);
        Task<ServiceSuspend> DeleteJobTimes(ServiceSuspend serviceSuspend);
    }
}
