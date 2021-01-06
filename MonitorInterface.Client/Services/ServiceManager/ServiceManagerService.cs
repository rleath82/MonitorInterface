using MonitorInterface.Client.Brokers.API;
using MonitorInterface.Client.Brokers.Logging;
using MonitorInterface.Client.Models.ServiceSuspends;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.ServiceManager
{
    public partial class ServiceManagerService : IServiceManagerService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public ServiceManagerService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public Task<List<ServiceSuspend>> GetJobStatuses() =>
            TryCatch(async () =>
            {
                return await this.apiBroker.GetJobStatusesAsync();
            });

        public Task<ServiceSuspend> UpdateJobStatuses(ServiceSuspend serviceSuspend) =>
            TryCatch(async () =>
            {
                ValidateServiceManagerParameters(serviceSuspend);

                return await this.apiBroker.UpdateJobStatusesAsync(serviceSuspend);
            });

        public Task<ServiceSuspend> DeleteJobTimes(ServiceSuspend serviceSuspend) =>
            TryCatch(async () =>
            {
                return await this.apiBroker.RemoveDownTimesAsync(serviceSuspend);
            });
    }
}
