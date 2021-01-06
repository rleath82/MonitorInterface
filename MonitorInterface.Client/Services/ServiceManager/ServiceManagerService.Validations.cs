using MonitorInterface.Client.Models.ServiceSuspends;
using MonitorInterface.Client.Models.ServiceSuspends.Exceptions;
using System;

namespace MonitorInterface.Client.Services.ServiceManager
{
    public partial class ServiceManagerService
    {
        private void ValidateServiceManagerParameters(ServiceSuspend serviceSuspend)
        {
            switch (serviceSuspend)
            {
                case null:
                    throw new NullServiceSuspendException();
                case { } when IsInvalid(serviceSuspend.JobId):
                    throw new InvalidServiceSuspendException(
                        parameterName: nameof(ServiceSuspend.JobId),
                        parameterValue: serviceSuspend.JobId);
                case { } when IsInvalid(serviceSuspend.ServiceStart):
                    throw new InvalidServiceSuspendException(
                        parameterName: nameof(ServiceSuspend.ServiceStart),
                        parameterValue: serviceSuspend.ServiceStart);
                case { } when IsInvalid(serviceSuspend.ServiceStop):
                    throw new InvalidServiceSuspendException(
                        parameterName: nameof(ServiceSuspend.ServiceStop),
                        parameterValue: serviceSuspend.ServiceStop);
            }
        }

        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);
    }
}
