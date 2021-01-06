using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MonitorInterface.Client.Models.ServiceSuspends;
using MonitorInterface.Client.Services.Modals;
using MonitorInterface.Client.Services.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Views.Pages
{
    public partial class ServiceManager
    {
        private List<ServiceSuspend> results = new List<ServiceSuspend>();
        private ServiceSuspend result;

        private bool IsDisabled { get; set; } = true;
        private string SelectMessage { get; set; }
        private string Message { get; set; }
        private string FontColor { get; set; }
        private DateTime? StartDate { get; set; }
        private DateTime? EndDate { get; set; }

        [Inject] IServiceManagerService ServiceManagerService { get; set; }
        [Inject] IJSRuntime JsRunTime { get; set; }
        [Inject] IModalService Modal { get; set; }
        [Inject] IMatToaster Toaster { get; set; }

        protected override async Task OnInitializedAsync()
        {
            result = new ServiceSuspend();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            SelectMessage = "Select All";
            FontColor = "green";
            await GetData();
            GetStatus();
        }

        private async Task GetData()
        {
            results = await ServiceManagerService.GetJobStatuses();
        }

        private void GetStatus()
        {
            var count = 0;

            foreach (var item in results)
            {
                if (item.ServiceStart != null && item.ServiceStop != null)
                {
                    count++;
                    item.ScheduledDownTime = item.ServiceStart + " to " + item.ServiceStop;
                }
                else
                {
                    item.ScheduledDownTime = "No Down Time Scheduled";
                }
            }
            foreach (var items in results)
            {
                if (count > 1)
                {
                    FontColor = "red";
                    Message = "Overrides established  " + items.ServiceStart + " to " + items.ServiceStop + "\n";
                    IsDisabled = true;
                }
                else if (count == 1)
                {
                    FontColor = "red";
                    Message = "Overrides established  " + items.ServiceStart + " to " + items.ServiceStop;
                    IsDisabled = true;
                }
                else
                {
                    FontColor = "green";
                    Message = "There are no Override Times currently established";
                }
            }
        }

        private void SetService()
        {
            IsDisabled = false;
        }

        private async void SaveChanges()
        {
            if (StartDate <= EndDate)
            {
                bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Are you sure you want to make these changes?");
                if (confirmed)
                {
                    result.JobId = "";
                    foreach (var item in results.Where(i => i.IsJobSelected == true))
                    {
                        result.JobId += item.JobId + ",";
                        item.ScheduledDownTime = StartDate.ToString() + " - " + EndDate.ToString();
                    }
                    result.JobId = result.JobId.TrimEnd(',');
                    result.ServiceStart = StartDate.ToString();
                    result.ServiceStop = EndDate.ToString();
                    await ServiceManagerService.UpdateJobStatuses(result);
                    await GetData();
                    StartDate = DateTime.Now;
                    EndDate = DateTime.Now;
                }
                else
                {
                    GetStatus();
                    StartDate = DateTime.Now;
                    EndDate = DateTime.Now;
                }
            }
            else
            {
                Toaster.Add("Start time must be less than end time.", MatToastType.Danger, "Warning", "⚠");
                GetStatus();
            }
            await GetData();
            GetStatus();
            StateHasChanged();
        }

        private async void ClearDownTimes()
        {
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Do you want to Remove Service Monitoring for the selected jobs?");
            if (confirmed)
            {
                result.JobId = string.Empty;
                foreach (var item in results.Where(i => i.IsJobSelected == true))
                {
                    item.ScheduledDownTime = null;
                    result.JobId += item.JobId + ",";
                }
                result.JobId = result.JobId.TrimEnd(',');
                if (result.JobId == string.Empty)
                {
                    Toaster.Add("Please check the job(s) you want to clear.", MatToastType.Warning, "Warning", "⚠");
                }

                await ServiceManagerService.DeleteJobTimes(result);
                await GetData();
                GetStatus();
                ClearSelected();
                StartDate = DateTime.Now;
                EndDate = DateTime.Now;
            }
            else
            {
                GetStatus();
            }
            StateHasChanged();
        }

        public void Exit()
        {
            Modal.Cancel();
        }

        public void SelectAll()
        {
            if (SelectMessage == "Deselect All")
            {
                ClearSelected();
            }
            else
            {
                foreach (var item in results)
                {
                    item.IsJobSelected = true;
                    SelectMessage = "Deselect All";
                }
            }
        }

        public void ClearSelected()
        {
            foreach (var item in results)
            {
                item.IsJobSelected = false;
                SelectMessage = "Select All";
            }
        }

        public void JobChecked(string jobId)
        {
            foreach (var items in results.Where(i => i.JobId == jobId))
            {
                if (items.IsJobSelected == false)
                {
                    items.IsJobSelected = true;
                }
                else
                {
                    items.IsJobSelected = false;
                }
            }
        }
    }
}
