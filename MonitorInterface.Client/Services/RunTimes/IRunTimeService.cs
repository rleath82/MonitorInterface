using MonitorInterface.Client.Models.RunTimeParameters;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.RunTimes
{
    public interface IRunTimeService
    {
        Task<RunTimeParams> GetRunTimeParamsForJob(string jobId);
        Task<RunTimeParams> UpdateRunTimesForJob(RunTimeParams runTimeParams);
    }
}
