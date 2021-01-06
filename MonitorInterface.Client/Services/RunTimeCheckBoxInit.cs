using MonitorInterface.Client.Models;

namespace MonitorInterface.Client.Services
{
    public class RunTimeCheckBoxInit
    {
        public void CheckAllMonths(Month month)
        {
            if (month.IsMonthChecked == false)
            {
                foreach (var item in InitializeFormData.Months)
                {
                    item.IsMonthChecked = true;
                }
            }
            else
            {
                foreach (var item in InitializeFormData.Months)
                {
                    item.IsMonthChecked = false;
                }
            }
        }

        public void CheckManualMonth(Month month)
        {
            if (month.IsMonthChecked == false)
            {
                month.IsMonthChecked = true;
            }
            else
            {
                month.IsMonthChecked = false;
                InitializeFormData.Months[0].IsMonthChecked = false;
            }
        }

        public void CheckAllDays(Day day)
        {
            if (day.IsDayChecked == false)
            {
                foreach (var item in InitializeFormData.Days)
                {
                    item.IsDayChecked = true;
                }
            }
            else
            {
                foreach (var item in InitializeFormData.Days)
                {
                    item.IsDayChecked = false;
                }
            }
        }

        public void CheckManualDay(Day day)
        {
            if (day.IsDayChecked == false)
            {
                day.IsDayChecked = true;
            }
            else
            {
                day.IsDayChecked = false;
                InitializeFormData.Days[0].IsDayChecked = false;
            }
        }

        public void CheckAllHours(Hour hour)
        {
            if (hour.IsHourChecked == false)
            {
                foreach (var item in InitializeFormData.Hours)
                {
                    item.IsHourChecked = true;
                }
            }
            else
            {
                foreach (var item in InitializeFormData.Hours)
                {
                    item.IsHourChecked = false;
                }
            }
        }

        public void CheckManualHour(Hour hour)
        {
            if (hour.IsHourChecked == false)
            {
                hour.IsHourChecked = true;
            }
            else
            {
                hour.IsHourChecked = false;
                InitializeFormData.Hours[24].IsHourChecked = false;
            }
        }

        public void CheckAllMinutes(Minute minute)
        {
            if (minute.IsMinuteChecked == false)
            {
                foreach (var item in InitializeFormData.Minutes)
                {
                    item.IsMinuteChecked = true;
                }
            }
            else
            {
                foreach (var item in InitializeFormData.Minutes)
                {
                    item.IsMinuteChecked = false;
                }
            }
        }

        public void CheckManualMinute(Minute minute)
        {
            if (minute.IsMinuteChecked == false)
            {
                minute.IsMinuteChecked = true;
            }
            else
            {
                minute.IsMinuteChecked = false;
                InitializeFormData.Minutes[60].IsMinuteChecked = false;
            }
        }
    }
}
