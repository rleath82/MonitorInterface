using MonitorInterface.Client.Models.Jobs;
using MonitorInterface.Client.Models.OracleResults;
using MonitorInterface.Client.Models.RunTimeParameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Brokers.API
{
    public partial interface IApiBroker
    {
        Task<IEnumerable<Job>> GetJobsAsync();
        Task<OracleResult> GetJobDataAsync(string jobId);
        Task<RunTimeParams> GetRunTimeParamsForJobAsync(string jobId);
        Task<OracleResult> PostNewJobAsync(OracleResult oracleResult);
        Task<OracleResult> PostTaskIdAsync(OracleResult oracleResult);
        Task<OracleResult> UpdateJobAsync(OracleResult oracleResult);
        Task<RunTimeParams> UpdateRunTimeParamsAsync(RunTimeParams runTimeParams);
        Task<OracleResult> DeleteJobAsync(string jobId);
        Task<Dictionary<string, string>> PostSqlValidate(Dictionary<string, string> content);
    }
}
