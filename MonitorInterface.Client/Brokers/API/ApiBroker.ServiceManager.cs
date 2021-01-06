using MonitorInterface.Client.Models.ServiceSuspends;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Brokers.API
{
    public partial class ApiBroker
    {
        private const string RelativeServiceManagerUrl = "https://localhost:44349/api/ServiceManager";

        public async Task<List<ServiceSuspend>> GetJobStatusesAsync() =>
            await this.GetContentAsync<List<ServiceSuspend>>(RelativeServiceManagerUrl);
        public async Task<ServiceSuspend> UpdateJobStatusesAsync(ServiceSuspend serviceSuspend) =>
            await this.PutContentAsync(RelativeServiceManagerUrl + "/UpdateJobStatuses", serviceSuspend);
        public async Task<ServiceSuspend> RemoveDownTimesAsync(ServiceSuspend serviceSuspend) =>
            await this.PutContentAsync(RelativeServiceManagerUrl + "/RemoveJobTimes", serviceSuspend);
    }
}
