using MonitorInterface.Client.Models.ServiceSuspends;
using MonitorInterface.Client.Models.ServiceSuspends.Exceptions;
using RESTfulSense.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.ServiceManager
{
    public partial class ServiceManagerService
    {
        private delegate Task<ServiceSuspend> ReturningServiceSuspendFunction();
        private delegate Task<List<ServiceSuspend>> ReturningServiceSuspendListFunction();

        private async Task<ServiceSuspend> TryCatch(ReturningServiceSuspendFunction returningServiceSuspendFunction)
        {
            try
            {
                return await returningServiceSuspendFunction();
            }
            catch (NullServiceSuspendException nullServiceSuspendException)
            {
                throw CreateAndLogValidationException(nullServiceSuspendException);
            }
            catch (InvalidServiceSuspendException invalidServiceSuspendException)
            {
                throw CreateAndLogValidationException(invalidServiceSuspendException);
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

        private async Task<List<ServiceSuspend>> TryCatch(ReturningServiceSuspendListFunction returningServiceSuspendListFunction)
        {
            try
            {
                return await returningServiceSuspendListFunction();
            }
            catch (NullServiceSuspendException nullServiceSuspendException)
            {
                throw CreateAndLogValidationException(nullServiceSuspendException);
            }
            catch (InvalidServiceSuspendException invalidServiceSuspendException)
            {
                throw CreateAndLogValidationException(invalidServiceSuspendException);
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

        private ServiceSuspendValidationException CreateAndLogValidationException(Exception exception)
        {
            var serviceSuspendValidationException = new ServiceSuspendValidationException(exception);
            this.loggingBroker.LogError(serviceSuspendValidationException);

            return serviceSuspendValidationException;
        }

        private ServiceSuspendDependencyValidationException CreateAndLogDependencyValidationException(
            Exception exception)
        {
            var serviceSuspendDependencyValidationException =
                new ServiceSuspendDependencyValidationException(exception);

            this.loggingBroker.LogError(serviceSuspendDependencyValidationException);

            return serviceSuspendDependencyValidationException;
        }

        private ServiceSuspendDependencyException CreateAndLogCriticalDependencyException(
            Exception exception)
        {
            var serviceSuspendDependencyException =
                new ServiceSuspendDependencyException(exception);

            this.loggingBroker.LogCritical(serviceSuspendDependencyException);

            return serviceSuspendDependencyException;
        }

        private ServiceSuspendDependencyException CreateAndLogDependencyException(
            Exception exception)
        {
            var serviceSuspendDependencyException =
                new ServiceSuspendDependencyException(exception);

            this.loggingBroker.LogError(serviceSuspendDependencyException);

            return serviceSuspendDependencyException;
        }

        private ServiceSuspendServiceException CreateAndLogServiceException(
            Exception exception)
        {
            var serviceSuspendServiceException =
                new ServiceSuspendServiceException(exception);

            this.loggingBroker.LogError(serviceSuspendServiceException);

            return serviceSuspendServiceException;
        }
    }
}
