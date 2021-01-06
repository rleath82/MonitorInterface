using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MonitorInterface.Client.Models.RunTimeParameters;
using MonitorInterface.Client.Services;
using MonitorInterface.Client.Services.Modals;
using MonitorInterface.Client.Services.RunTimes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorInterface.Client.Views.Pages
{
    public partial class RunTimeParameters
    {
        private RunTimeCheckBoxInit init = new RunTimeCheckBoxInit();
        private RunTimeParams results;

        [Inject] IRunTimeService RunTimeParameterService { get; set; }
        [Inject] IModalService Modal { get; set; }
        [Inject] IJSRuntime JsRunTime { get; set; }
        [Inject] IMatToaster Toaster { get; set; }

        [Parameter] public string JobId { get; set; }
        [CascadingParameter] ModalParameters Parameters { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                JobId = Parameters.Get<string>("JobId");

                await GetData();
                InitializeFormData.GetMonthChecklist();
                InitializeFormData.GetDayChecklist();
                InitializeFormData.GetHourChecklist();
                InitializeFormData.GetMinuteChecklist();

                GetMonthParams();
                GetDayParams();
                GetHourParams();
                GetMinuteParams();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Cancel()
        {
            Modal.Cancel();
        }

        public async Task GetData()
        {
            try
            {
                results = await RunTimeParameterService.GetRunTimeParamsForJob(JobId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying Run Time data.", ex.Message);
            }
        }

        private void GetMonthParams()
        {
            var getMonths = from val in results.Month.ToString().Split(',') select int.Parse(val);
            try
            {
                foreach (int month in getMonths)
                {
                    InitializeFormData.Months[month].IsMonthChecked = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving current month selections.", ex.Message);
            }
        }

        private void GetDayParams()
        {
            var getDays = from val in results.Day.ToString().Split(',') select val;
            try
            {
                foreach (var day in getDays)
                {
                    switch (day.ToString())
                    {
                        case "Sunday":
                            InitializeFormData.Days[1].IsDayChecked = true;
                            break;
                        case "Monday":
                            InitializeFormData.Days[2].IsDayChecked = true;
                            break;
                        case "Tuesday":
                            InitializeFormData.Days[3].IsDayChecked = true;
                            break;
                        case "Wednesday":
                            InitializeFormData.Days[4].IsDayChecked = true;
                            break;
                        case "Thursday":
                            InitializeFormData.Days[5].IsDayChecked = true;
                            break;
                        case "Friday":
                            InitializeFormData.Days[6].IsDayChecked = true;
                            break;
                        case "Saturday":
                            InitializeFormData.Days[7].IsDayChecked = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving current day selections.", ex.Message);
            }
        }

        private void GetHourParams()
        {
            var getHours = from val in results.Hour.ToString().Split(',') select int.Parse(val);
            try
            {
                foreach (int hour in getHours)
                {
                    InitializeFormData.Hours[hour].IsHourChecked = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving current hour selections.", ex.Message);
            }
        }

        private void GetMinuteParams()
        {
            var getMinutes = from val in results.Minute.ToString().Split(',') select int.Parse(val);
            try
            {
                foreach (int minute in getMinutes)
                {
                    InitializeFormData.Minutes[minute].IsMinuteChecked = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving current minute selections.", ex.Message);
            }
        }

        private async void SaveChanges()
        {
            bool confirmed = await JsRunTime.InvokeAsync<bool>("confirm", "Are you sure you want to save changes?");
            if (confirmed)
            {
                FormatRunTimeFields();

                try
                {
                    await RunTimeParameterService.UpdateRunTimesForJob(results);
                    Toaster.Add("Run Time Changes Saved Successfully", MatToastType.Success, "Success", "✓");

                    await GetData();
                    Modal.Close(ModalResult.Ok(results));
                }
                catch (Exception ex)
                {
                    Toaster.Add("Error Saving Run Time Changes, try again.", MatToastType.Danger, "Warning", "⚠");
                    Console.WriteLine("Error saving run time changes", ex.Message);
                }
            }
        }

        private void FormatRunTimeFields()
        {
            results.Month = string.Empty;
            results.Day = string.Empty;
            results.Hour = string.Empty;
            results.Minute = string.Empty;

            foreach (var month in InitializeFormData.Months.Where(m => m.IsMonthChecked == true && m.MonthId != 0))
            {
                results.Month += month.MonthId.ToString() + ",";
            }
            results.Month = results.Month.TrimEnd(',');
            foreach (var day in InitializeFormData.Days.Where(d => d.IsDayChecked == true && d.DayId != 0))
            {
                results.Day += ConvertDays(day.DayName) + ",";
            }
            results.Day = results.Day.TrimEnd(',');
            foreach (var hour in InitializeFormData.Hours.Where(h => h.IsHourChecked == true && h.HourId < 24))
            {
                results.Hour += hour.HourName + ",";
            }
            results.Hour = results.Hour.TrimEnd(',');
            foreach (var minute in InitializeFormData.Minutes.Where(m => m.IsMinuteChecked == true && m.MinuteId < 60))
            {
                results.Minute += minute.MinuteName + ",";
            }
            results.Minute = results.Minute.TrimEnd(',');
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

        public void ResetParams()
        {
            foreach (var month in InitializeFormData.Months) month.IsMonthChecked = false;
            foreach (var day in InitializeFormData.Days) day.IsDayChecked = false;
            foreach (var hour in InitializeFormData.Hours) hour.IsHourChecked = false;
            foreach (var minute in InitializeFormData.Minutes) minute.IsMinuteChecked = false;
        }
    }
}
