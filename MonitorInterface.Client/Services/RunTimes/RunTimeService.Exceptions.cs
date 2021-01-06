using MonitorInterface.Client.Models.RunTimeParameters;
using MonitorInterface.Client.Models.RunTimeParameters.Exceptions;
using RESTfulSense.Models.Exceptions;
using System;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.RunTimes
{
    public partial class RunTimeService
    {
        private delegate Task<RunTimeParams> ReturningRunTimeParamsFunction();

        private async Task<RunTimeParams> TryCatch(ReturningRunTimeParamsFunction returningRunTimeParamsFunction)
        {
            try
            {
                return await returningRunTimeParamsFunction();
            }
            catch (NullRunTimeParameterException nullRunTimeParameterException)
            {
                throw CreateAndLogValidationException(nullRunTimeParameterException);
            }
            catch (InvalidRunTimeParameterException invalidRunTimeParameterException)
            {
                throw CreateAndLogValidationException(invalidRunTimeParameterException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                throw CreateAndLogCriticalDependencyException(httpResponseUrlNotFoundException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                throw CreateAndLogCriticalDependencyException(httpResponseUnauthorizedException);
            }
            catch (HttpResponseConflictException httpResponseConflictException)
            {
                throw CreateAndLogDependencyValidationException(httpResponseConflictException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                throw CreateAndLogDependencyValidationException(httpResponseBadRequestException);
            }
            catch (HttpResponseInternalServerErrorException httpResponseInternalServerException)
            {
                throw CreateAndLogDependencyException(httpResponseInternalServerException);
            }
            catch (HttpResponseException httpResponseException)
            {
                throw CreateAndLogDependencyException(httpResponseException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogServiceException(serviceException);
            }
        }

        private RunTimeParameterValidationException CreateAndLogValidationException(Exception exception)
        {
            var runTimeParameterValidationException = new RunTimeParameterValidationException(exception);
            this.loggingBroker.LogError(runTimeParameterValidationException);

            return runTimeParameterValidationException;
        }

        private RunTimeParameterDependencyValidationException CreateAndLogDependencyValidationException(Exception exception)
        {
            var runTimeParameterDependencyValidationException = new RunTimeParameterDependencyValidationException(exception);
            this.loggingBroker.LogError(runTimeParameterDependencyValidationException);

            return runTimeParameterDependencyValidationException;
        }

        private RunTimeParameterDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var runTimeParameterDependencyException = new RunTimeParameterDependencyException(exception);
            this.loggingBroker.LogCritical(runTimeParameterDependencyException);

            return runTimeParameterDependencyException;
        }

        private RunTimeParameterDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var runTimeParameterDependencyException = new RunTimeParameterDependencyException(exception);
            this.loggingBroker.LogError(runTimeParameterDependencyException);

            return runTimeParameterDependencyException;
        }

        private RunTimeParameterServiceException CreateAndLogServiceException(Exception exception)
        {
            var runTimeParameterServiceException = new RunTimeParameterServiceException(exception);
            this.loggingBroker.LogError(runTimeParameterServiceException);

            return runTimeParameterServiceException;
        }
    }
}
