using MonitorInterface.Client.Brokers.API;
using MonitorInterface.Client.Brokers.Logging;
using MonitorInterface.Client.Models.RunTimeParameters;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.RunTimes
{
    public partial class RunTimeService : IRunTimeService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public RunTimeService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public Task<RunTimeParams> GetRunTimeParamsForJob(string jobId) =>
            TryCatch(async () =>
            {
                return await this.apiBroker.GetRunTimeParamsForJobAsync(jobId);
            });

        public Task<RunTimeParams> UpdateRunTimesForJob(RunTimeParams runTimeParams) =>
            TryCatch(async () =>
            {
                ValidateRunTimeParameters(runTimeParams);

                return await this.apiBroker.UpdateRunTimeParamsAsync(runTimeParams);
            });
    }
}
