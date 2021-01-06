using MonitorInterface.Client.Models.Jobs;
using MonitorInterface.Client.Models.OracleResults;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.Jobs
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetJobs();
        Task<OracleResult> GetJobData(string jobId);
        Task<OracleResult> CreateNewJob(OracleResult oracleResult);
        Task<OracleResult> CreateTaskId(OracleResult oracleResult);
        Task<OracleResult> UpdateJob(OracleResult oracleResult);
        Task<OracleResult> DeleteJob(string jobId);
        Task<HttpResponseMessage> ValidateSql(Dictionary<string, string> pairs);
        //Task<Dictionary<string, string>> ValidateSql(Dictionary<string, string> content);
    }
}
