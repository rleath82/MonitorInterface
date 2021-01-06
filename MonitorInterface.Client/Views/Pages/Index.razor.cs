using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MonitorInterface.Client.Constants;
using MonitorInterface.Client.Models.Jobs;
using MonitorInterface.Client.Models.OracleResults;
using MonitorInterface.Client.Services;
using MonitorInterface.Client.Services.Jobs;
using MonitorInterface.Client.Services.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Views.Pages
{
    public partial class Index
    {
        private IEnumerable<Job> jobs;
        private OracleResult result;
        private string JobId { get; set; }
        private bool IsDisabled { get; set; } = true;

        [Inject] IJobService JobService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IJSRuntime JsRunTime { get; set; }
        [Inject] IModalService Modal { get; set; }
        [Inject] IMatToaster Toaster { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                InitializeFormData.GetSendMSTeamsDropdown();
                InitializeFormData.GetMSTeamsChannelDropdown();
                InitializeFormData.GetSendMailDropdown();
                InitializeFormData.GetDbSchemaDropdown();
                InitializeFormData.GetStatusDropdown();

                await GetJobs();
                await GetFormData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task GetJobs()
        {
            try
            {
                jobs = await JobService.GetJobs();
                JobId = jobs.Select(j => j.JobId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying jobs from Oracle.", ex.Message);
            }
        }

        private async Task GetFormData()
        {
            try
            {
                result = await JobService.GetJobData(JobId);
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying form data from Oracle for jobId: {JobId}", ex.Message);
            }
        }

        private async void JobIdChanged(ChangeEventArgs args)
        {
            JobId = args.Value as string;

            if (JobId != null)
            {
                await GetFormData();
            }
        }

        private async void SaveChanges()
        {
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Are you sure you want to save these changes?");
            if (confirmed)
            {
                result.MailFrom = MailAddresses.FromMail;
                result.MSTeamsUrl = MSTeamsEndpoints.HSNAlerts;
                result.SlackUser = Slack.SlackUserString;
                result.JobId = JobId;

                if (result.MailTo == null)
                {
                    result.MailTo = string.Empty;
                }
                if (result.EmailSubject == null)
                {
                    result.EmailSubject = string.Empty;
                }
                if (result.SqlString == null)
                {
                    result.SqlString = string.Empty;
                }

                try
                {
                    await JobService.UpdateJob(result);
                    Toaster.Add("Job updated successfully", MatToastType.Success, "Success", "✓");

                    NavigationManager.NavigateTo("/");
                }
                catch (Exception ex)
                {
                    Toaster.Add("Job not updated successfully", MatToastType.Danger, "Error", "⚠");
                    Console.WriteLine("Job not updated successfully", ex.Message);
                }
            }
        }

        private async void DeleteJob()
        {
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Are you sure you want to delete the selected job?");
            if (confirmed)
            {
                try
                {
                    await JobService.DeleteJob(result.JobId);
                    Toaster.Add("Job Deleted Successfully", MatToastType.Success, "Success", "✓");
                    await GetJobs();
                    await GetFormData();
                    StateHasChanged();
                }
                catch (Exception ex)
                {
                    Toaster.Add("Error deleting job, contact support.", MatToastType.Danger, "Warning", "⚠");
                    Console.WriteLine("Error deleting job.", ex.Message);
                }
            }
        }

        private void AddNewJob()
        {
            NavigationManager.NavigateTo("/CreateNewJob");
        }

        private async void ValidateSql(string sqlString)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            sqlString = result.SqlString;
            if (sqlString == null)
            {
                sqlString = string.Empty;
            }
            sqlString = result.SqlString.Replace("\t", " ").Replace("\n", " ").Replace("\r", " ");
            pairs.Add(result.DbSchema, sqlString);

            try
            {
                var IsValid = await JobService.ValidateSql(pairs);
                if (IsValid.IsSuccessStatusCode)
                {
                    Toaster.Add("Valid Sql Statement", MatToastType.Success, "Success", "✓");
                }
                else
                {
                    Toaster.Add("Invalid Sql Statement", MatToastType.Danger, "Warning", "⚠");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowRunTimeParameters()
        {
            var parameters = new ModalParameters();
            parameters.Add("JobId", JobId);

            Modal.Show<RunTimeParameters>("Run Time Parameters", parameters);
        }

        private void ShowServiceManager()
        {
            Modal.Show<ServiceManager>("Service Downtime");
        }

        private void Override()
        {
            IsDisabled = false;
        }
    }
}
