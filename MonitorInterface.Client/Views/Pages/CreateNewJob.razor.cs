using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MonitorInterface.Client.Constants;
using MonitorInterface.Client.Models.OracleResults;
using MonitorInterface.Client.Services;
using MonitorInterface.Client.Services.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonitorInterface.Client.Views.Pages
{
    public partial class CreateNewJob
    {
        private RunTimeCheckBoxInit init = new RunTimeCheckBoxInit();
        private OracleResult newJob = new OracleResult();

        [Inject] IJobService JobService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IJSRuntime JsRunTime { get; set; }
        [Inject] IMatToaster Toaster { get; set; }

        protected override void OnInitialized()
        {
            try
            {
                newJob.MSTeamsChannel = "#alerts";
                newJob.SlackUser = Slack.SlackUserString;
                newJob.SendMSTeams = "N";
                newJob.SendMail = "N";
                newJob.Status = "N";
                newJob.MailFrom = MailAddresses.FromMail;
                newJob.DbSchema = "MerchDev";

                InitializeFormData.GetMonthChecklist();
                InitializeFormData.GetDayChecklist();
                InitializeFormData.GetHourChecklist();
                InitializeFormData.GetMinuteChecklist();
                InitializeFormData.GetDbSchemaDropdown();
                InitializeFormData.GetSendMailDropdown();
                InitializeFormData.GetSendMSTeamsDropdown();
                InitializeFormData.GetMSTeamsChannelDropdown();
                InitializeFormData.GetStatusDropdown();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading form data.", ex.Message);
            }
        }

        private async void AddNewJob()
        {
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Add this new job now?");
            if (confirmed)
            {
                FormatRunTimeFields();

                if (newJob.MailFrom == null)
                {
                    newJob.MailFrom = string.Empty;
                }
                if (newJob.MailTo == null)
                {
                    newJob.MailTo = string.Empty;
                }
                if (newJob.SqlString == null)
                {
                    newJob.SqlString = string.Empty;
                }

                try
                {
                    await JobService.CreateNewJob(newJob);
                    await JobService.CreateTaskId(newJob);
                    Toaster.Add("Job Created Successfully", MatToastType.Success, "Success", "✓");
                    NavigationManager.NavigateTo("/");
                }
                catch (Exception ex)
                {
                    Toaster.Add("Job Not Created Successfully", MatToastType.Danger, "Warning", "⚠");
                    Console.WriteLine("Error creating new job, ensure all fields are complete.", ex.Message);
                }
            }
        }

        private void FormatRunTimeFields()
        {
            newJob.Month = string.Empty;
            newJob.Day = string.Empty;
            newJob.Hour = string.Empty;
            newJob.Minute = string.Empty;

            foreach (var month in InitializeFormData.Months.Where(m => m.IsMonthChecked == true && m.MonthId != 0))
            {
                newJob.Month += month.MonthId.ToString() + ",";
            }
            newJob.Month = newJob.Month.TrimEnd(',');
            foreach (var day in InitializeFormData.Days.Where(d => d.IsDayChecked == true && d.DayId != 0))
            {
                newJob.Day += ConvertDays(day.DayName) + ",";
            }
            newJob.Day = newJob.Day.TrimEnd(',');
            foreach (var hour in InitializeFormData.Hours.Where(h => h.IsHourChecked == true && h.HourId < 24))
            {
                newJob.Hour += hour.HourName + ",";
            }
            newJob.Hour = newJob.Hour.TrimEnd(',');
            foreach (var minute in InitializeFormData.Minutes.Where(m => m.IsMinuteChecked == true && m.MinuteId < 60))
            {
                newJob.Minute += minute.MinuteName + ",";
            }
            newJob.Minute = newJob.Minute.TrimEnd(',');
        }

        private string ConvertDays(string day)
        {
            switch (day)
            {
                case "Mon":
                    return "Monday";
                case "Tue":
                    return "Tuesday";
                case "Wed":
                    return "Wednesday";
                case "Thu":
                    return "Thursday";
                case "Fri":
                    return "Friday";
                case "Sat":
                    return "Saturday";
                case "Sun":
                    return "Sunday";
            }
            return "Monday";
        }

        private async void ValidateSql(string sqlString)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            sqlString = newJob.SqlString;
            if (sqlString == null)
            {
                sqlString = string.Empty;
            }
            sqlString = sqlString.Replace("\t", " ").Replace("\n", " ").Replace("\r", " ");
            pairs.Add(newJob.DbSchema, sqlString);

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

        private void BackToIndex()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
