using MonitorInterface.Client.Models.RunTimeParameters;
using MonitorInterface.Client.Models.RunTimeParameters.Exceptions;
using System;

namespace MonitorInterface.Client.Services.RunTimes
{
    public partial class RunTimeService
    {
        private void ValidateRunTimeParameters(RunTimeParams runTimeParams)
        {
            switch (runTimeParams)
            {
                case null:
                    throw new NullRunTimeParameterException();
                case { } when IsInvalid(runTimeParams.JobId):
                    throw new InvalidRunTimeParameterException(
                        parameterName: nameof(RunTimeParams.JobId),
                        parameterValue: runTimeParams.JobId);
            }
        }

        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);
    }
}
