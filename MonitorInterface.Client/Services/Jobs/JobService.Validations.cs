using MonitorInterface.Client.Models.OracleResults;
using MonitorInterface.Client.Models.OracleResults.Exceptions;
using System;

namespace MonitorInterface.Client.Services.Jobs
{
    public partial class JobService
    {
        private void ValidateOracleResult(OracleResult oracleResult)
        {
            switch (oracleResult)
            {
                case null:
                    throw new NullOracleResultException();
                case { } when IsInvalid(oracleResult.JobName):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.JobName),
                        parameterValue: oracleResult.JobName);
                case { } when IsInvalid(oracleResult.Status):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.Status),
                        parameterValue: oracleResult.Status);
                case { } when IsInvalid(oracleResult.DbSchema):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.DbSchema),
                        parameterValue: oracleResult.DbSchema);
                case { } when IsInvalid(oracleResult.IssueDescription):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.IssueDescription),
                        parameterValue: oracleResult.IssueDescription);
                case { } when IsInvalid(oracleResult.MSTeamsChannel):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.MSTeamsChannel),
                        parameterValue: oracleResult.MSTeamsChannel);
                case { } when IsInvalid(oracleResult.MSTeamsUrl):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.MSTeamsUrl),
                        parameterValue: oracleResult.MSTeamsUrl);
                case { } when IsInvalid(oracleResult.MailFrom):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.MailFrom),
                        parameterValue: oracleResult.MailFrom);
                case { } when IsInvalid(oracleResult.SendMail):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.SendMail),
                        parameterValue: oracleResult.SendMail);
                case { } when IsInvalid(oracleResult.SendMSTeams):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.SendMSTeams),
                        parameterValue: oracleResult.SendMSTeams);
                case { } when IsInvalid(oracleResult.SlackUser):
                    throw new InvalidOracleResultException(
                        parameterName: nameof(OracleResult.SlackUser),
                        parameterValue: oracleResult.SlackUser);
            }
        }

        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);
    }
}
