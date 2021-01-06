using MonitorInterface.Client.Models.Jobs;
using MonitorInterface.Client.Models.OracleResults;
using MonitorInterface.Client.Models.RunTimeParameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Brokers.API
{
    public partial class ApiBroker
    {
        private const string RelativeJobUrl = "https://localhost:44349/api/jobs";


        public async Task<IEnumerable<Job>> GetJobsAsync() =>
            await this.GetContentAsync<IEnumerable<Job>>(RelativeJobUrl + "/GetJobs");
        public async Task<OracleResult> GetJobDataAsync(string jobId) =>
            await this.GetContentAsync<OracleResult>(RelativeJobUrl + $"/GetJobData/{jobId}");
        public async Task<RunTimeParams> GetRunTimeParamsForJobAsync(string jobId) =>
            await this.GetContentAsync<RunTimeParams>(RelativeJobUrl + $"/GetRunTimesForJob/{jobId}");
        public async Task<OracleResult> PostNewJobAsync(OracleResult oracleResult) =>
            await this.PostContentAsync(RelativeJobUrl + "/CreateNewJob", oracleResult);
        public async Task<OracleResult> PostTaskIdAsync(OracleResult oracleResult) =>
            await this.PostContentAsync(RelativeJobUrl + "/CreateTaskId", oracleResult);
        public async Task<OracleResult> UpdateJobAsync(OracleResult oracleResult) =>
            await this.PutContentAsync(RelativeJobUrl + "/UpdateJob", oracleResult);
        public async Task<RunTimeParams> UpdateRunTimeParamsAsync(RunTimeParams runTimeParams) =>
            await this.PutContentAsync(RelativeJobUrl + "/UpdateRunTimeParametersForJob", runTimeParams);
        public async Task<OracleResult> DeleteJobAsync(string jobId) =>
            await this.DeleteContentAsync<OracleResult>(RelativeJobUrl + $"/{jobId}");
        public async Task<Dictionary<string, string>> PostSqlValidate(Dictionary<string, string> content) =>
            await this.PostContentAsync(RelativeJobUrl + "/ExecuteSqlValidate", content);
    }
}
