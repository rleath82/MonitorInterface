using MonitorInterface.Client.Brokers.API;
using MonitorInterface.Client.Brokers.Logging;
using MonitorInterface.Client.Models.Jobs;
using MonitorInterface.Client.Models.OracleResults;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.Jobs
{
    public partial class JobService : IJobService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly HttpClient _httpClient;
        private const string RelativeJobUrl = "https://localhost:44349/api/jobs";

        public JobService(IApiBroker apiBroker, ILoggingBroker loggingBroker, HttpClient httpClient)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Job>> GetJobs() =>
            TryCatch(async () =>
            {
                return await this.apiBroker.GetJobsAsync();
            });

        public Task<OracleResult> GetJobData(string jobId) =>
            TryCatch(async () =>
            {
                return await this.apiBroker.GetJobDataAsync(jobId);
            });

        public Task<OracleResult> CreateNewJob(OracleResult oracleResult) =>
            TryCatch(async () =>
            {
                ValidateOracleResult(oracleResult);

                return await this.apiBroker.PostNewJobAsync(oracleResult);
            });

        public Task<OracleResult> UpdateJob(OracleResult oracleResult) =>
            TryCatch(async () =>
            {
                ValidateOracleResult(oracleResult);

                return await this.apiBroker.UpdateJobAsync(oracleResult);
            });

        public Task<OracleResult> CreateTaskId(OracleResult oracleResult) =>
            TryCatch(async () =>
            {
                return await this.apiBroker.PostTaskIdAsync(oracleResult);
            });

        public Task<OracleResult> DeleteJob(string jobId) =>
            TryCatch(async () =>
            {
                return await this.apiBroker.DeleteJobAsync(jobId);
            });

        //public Task<Dictionary<string, string>> ValidateSql(Dictionary<string, string> content) =>
        //    TryCatch(async () =>
        //    {
        //        return await this.apiBroker.PostSqlValidate(content);
        //    });

        public async Task<HttpResponseMessage> ValidateSql(Dictionary<string, string> pairs)
        {
            FormUrlEncodedContent formContent = new FormUrlEncodedContent(pairs);

            return await _httpClient.PostAsync($"{RelativeJobUrl}/ExecuteSqlValidate", formContent);
        }
    }
}
