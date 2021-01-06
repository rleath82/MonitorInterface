using MonitorInterface.Client.Models.Jobs;
using MonitorInterface.Client.Models.Jobs.Exceptions;
using MonitorInterface.Client.Models.OracleResults;
using MonitorInterface.Client.Models.OracleResults.Exceptions;
using RESTfulSense.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Services.Jobs
{
    public partial class JobService
    {
        private delegate Task<IEnumerable<Job>> ReturningJobListFunction();
        private delegate Task<OracleResult> ReturningOracleResultFunction();
        private delegate Task<Dictionary<string, string>> ReturningSqlValidationFunction();

        private async Task<IEnumerable<Job>> TryCatch(ReturningJobListFunction returningJobListFunction)
        {
            try
            {
                return await returningJobListFunction();
            }
            catch (NullJobException nullJobException)
            {
                throw CreateAndLogJobValidationException(nullJobException);
            }
            catch (InvalidJobException invalidJobException)
            {
                throw CreateAndLogJobValidationException(invalidJobException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                throw CreateAndLogJobCriticalDependencyException(httpResponseUrlNotFoundException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                throw CreateAndLogJobCriticalDependencyException(httpResponseUnauthorizedException);
            }
            catch (HttpResponseConflictException httpResponseConflictException)
            {
                throw CreateAndLogJobDependencyValidationException(httpResponseConflictException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                throw CreateAndLogJobDependencyValidationException(httpResponseBadRequestException);
            }
            catch (HttpResponseInternalServerErrorException httpResponseInternalServerException)
            {
                throw CreateAndLogJobDependencyException(httpResponseInternalServerException);
            }
            catch (HttpResponseException httpResponseException)
            {
                throw CreateAndLogJobDependencyException(httpResponseException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogJobServiceException(serviceException);
            }
        }

        private async Task<OracleResult> TryCatch(ReturningOracleResultFunction returningOracleResultFunction)
        {
            try
            {
                return await returningOracleResultFunction();
            }
            catch (NullOracleResultException nullOracleResultException)
            {
                throw CreateAndLogOracleResultValidationException(nullOracleResultException);
            }
            catch (InvalidOracleResultException invalidOracleResultsException)
            {
                throw CreateAndLogOracleResultValidationException(invalidOracleResultsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                throw CreateAndLogOracleResultCriticalDependencyException(httpResponseUrlNotFoundException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                throw CreateAndLogOracleResultCriticalDependencyException(httpResponseUnauthorizedException);
            }
            catch (HttpResponseConflictException httpResponseConflictException)
            {
                throw CreateAndLogOracleResultDependencyValidationException(httpResponseConflictException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                throw CreateAndLogOracleResultDependencyValidationException(httpResponseBadRequestException);
            }
            catch (HttpResponseInternalServerErrorException httpResponseInternalServerException)
            {
                throw CreateAndLogOracleResultDependencyException(httpResponseInternalServerException);
            }
            catch (HttpResponseException httpResponseException)
            {
                throw CreateAndLogOracleResultDependencyException(httpResponseException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogOracleResultServiceException(serviceException);
            }
        }

        private async Task<Dictionary<string, string>> TryCatch(ReturningSqlValidationFunction returningSqlValidationFunction)
        {
            try
            {
                return await returningSqlValidationFunction();
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                throw CreateAndLogOracleResultCriticalDependencyException(httpResponseUrlNotFoundException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                throw CreateAndLogOracleResultCriticalDependencyException(httpResponseUnauthorizedException);
            }
            catch (HttpResponseConflictException httpResponseConflictException)
            {
                throw CreateAndLogOracleResultDependencyValidationException(httpResponseConflictException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                throw CreateAndLogOracleResultDependencyValidationException(httpResponseBadRequestException);
            }
            catch (HttpResponseInternalServerErrorException httpResponseInternalServerException)
            {
                throw CreateAndLogOracleResultDependencyException(httpResponseInternalServerException);
            }
            catch (HttpResponseException httpResponseException)
            {
                throw CreateAndLogOracleResultDependencyException(httpResponseException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogOracleResultServiceException(serviceException);
            }
        }

        private JobValidationException CreateAndLogJobValidationException(Exception exception)
        {
            var jobValidationException = new JobValidationException(exception);
            this.loggingBroker.LogError(jobValidationException);

            return jobValidationException;
        }

        private JobDependencyValidationException CreateAndLogJobDependencyValidationException(Exception exception)
        {
            var jobDependencyValidationException = new JobDependencyValidationException(exception);
            this.loggingBroker.LogError(jobDependencyValidationException);

            return jobDependencyValidationException;
        }

        private JobDependencyException CreateAndLogJobCriticalDependencyException(Exception exception)
        {
            var jobDependencyException = new JobDependencyException(exception);
            this.loggingBroker.LogCritical(jobDependencyException);

            return jobDependencyException;
        }

        private JobDependencyException CreateAndLogJobDependencyException(Exception exception)
        {
            var jobDependencyException = new JobDependencyException(exception);
            this.loggingBroker.LogError(jobDependencyException);

            return jobDependencyException;
        }

        private JobServiceException CreateAndLogJobServiceException(Exception exception)
        {
            var jobServiceException = new JobServiceException(exception);
            this.loggingBroker.LogError(jobServiceException);

            return jobServiceException;
        }


        private OracleResultValidationException CreateAndLogOracleResultValidationException(Exception exception)
        {
            var oracleResultValidationException = new OracleResultValidationException(exception);
            this.loggingBroker.LogError(oracleResultValidationException);

            return oracleResultValidationException;
        }

        private OracleResultDependencyValidationException CreateAndLogOracleResultDependencyValidationException(Exception exception)
        {
            var oracleResultDependencyValidationException = new OracleResultDependencyValidationException(exception);
            this.loggingBroker.LogError(oracleResultDependencyValidationException);

            return oracleResultDependencyValidationException;
        }

        private OracleResultDependencyException CreateAndLogOracleResultCriticalDependencyException(Exception exception)
        {
            var oracleResultDependencyException = new OracleResultDependencyException(exception);
            this.loggingBroker.LogCritical(oracleResultDependencyException);

            return oracleResultDependencyException;
        }

        private OracleResultDependencyException CreateAndLogOracleResultDependencyException(Exception exception)
        {
            var oracleResultDependencyException = new OracleResultDependencyException(exception);
            this.loggingBroker.LogError(oracleResultDependencyException);

            return oracleResultDependencyException;
        }

        private OracleResultServiceException CreateAndLogOracleResultServiceException(Exception exception)
        {
            var oracleResultServiceException = new OracleResultServiceException(exception);
            this.loggingBroker.LogError(oracleResultServiceException);

            return oracleResultServiceException;
        }
    }
}
