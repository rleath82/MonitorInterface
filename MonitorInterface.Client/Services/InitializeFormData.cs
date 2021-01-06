using MonitorInterface.Client.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonitorInterface.Client.Services
{
    public static class InitializeFormData
    {
        public static List<Month> Months { get; set; }
        public static List<Day> Days { get; set; }
        public static List<Hour> Hours { get; set; }
        public static List<Minute> Minutes { get; set; }
        public static List<SendMSTeams> SendTeams { get; set; }
        public static List<MSTeamsChannel> MSTeamsChannels { get; set; }
        public static List<SendMail> SendMails { get; set; }
        public static List<DbSchema> DbSchemas { get; set; }
        public static List<Status> Statuses { get; set; }

        public static void GetMonthChecklist()
        {
            List<Month> months = new List<Month>()
            {
                new Month{MonthId = 0, MonthName = "All Months", IsMonthChecked = false},
                new Month{MonthId = 1, MonthName = "Jan", IsMonthChecked = false},
                new Month{MonthId = 2, MonthName = "Feb", IsMonthChecked = false},
                new Month{MonthId = 3, MonthName = "Mar", IsMonthChecked = false},
                new Month{MonthId = 4, MonthName = "Apr", IsMonthChecked = false},
                new Month{MonthId = 5, MonthName = "May", IsMonthChecked = false},
                new Month{MonthId = 6, MonthName = "Jun", IsMonthChecked = false},
                new Month{MonthId = 7, MonthName = "Jul", IsMonthChecked = false},
                new Month{MonthId = 8, MonthName = "Aug", IsMonthChecked = false},
                new Month{MonthId = 9, MonthName = "Sep", IsMonthChecked = false},
                new Month{MonthId = 10, MonthName = "Oct", IsMonthChecked = false},
                new Month{MonthId = 11, MonthName = "Nov", IsMonthChecked = false},
                new Month{MonthId = 12, MonthName = "Dec", IsMonthChecked = false}
            };

            Months = months.ToList();
        }

        public static void GetDayChecklist()
        {
            List<Day> days = new List<Day>()
            {
                new Day{DayId = 0, DayName = "Every Day", IsDayChecked = false},
                new Day{DayId = 1, DayName = "Sun", IsDayChecked = false},
                new Day{DayId = 2, DayName = "Mon", IsDayChecked = false},
                new Day{DayId = 3, DayName = "Tue", IsDayChecked = false},
                new Day{DayId = 4, DayName = "Wed", IsDayChecked = false},
                new Day{DayId = 5, DayName = "Thu", IsDayChecked = false},
                new Day{DayId = 6, DayName = "Fri", IsDayChecked = false},
                new Day{DayId = 7, DayName = "Sat", IsDayChecked = false}
            };

            Days = days.ToList();
        }

        public static void GetHourChecklist()
        {
            List<Hour> hours = new List<Hour>()
            {
                new Hour {HourId = 0, HourName = "0", IsHourChecked = false},
                new Hour {HourId = 1, HourName = "1", IsHourChecked = false},
                new Hour {HourId = 2, HourName = "2", IsHourChecked = false},
                new Hour {HourId = 3, HourName = "3", IsHourChecked = false},
                new Hour {HourId = 4, HourName = "4", IsHourChecked = false},
                new Hour {HourId = 5, HourName = "5", IsHourChecked = false},
                new Hour {HourId = 6, HourName = "6", IsHourChecked = false},
                new Hour {HourId = 7, HourName = "7", IsHourChecked = false},
                new Hour {HourId = 8, HourName = "8", IsHourChecked = false},
                new Hour {HourId = 9, HourName = "9", IsHourChecked = false},
                new Hour {HourId = 10, HourName = "10", IsHourChecked = false},
                new Hour {HourId = 11, HourName = "11", IsHourChecked = false},
                new Hour {HourId = 12, HourName = "12", IsHourChecked = false},
                new Hour {HourId = 13, HourName = "13", IsHourChecked = false},
                new Hour {HourId = 14, HourName = "14", IsHourChecked = false},
                new Hour {HourId = 15, HourName = "15", IsHourChecked = false},
                new Hour {HourId = 16, HourName = "16", IsHourChecked = false},
                new Hour {HourId = 17, HourName = "17", IsHourChecked = false},
                new Hour {HourId = 18, HourName = "18", IsHourChecked = false},
                new Hour {HourId = 19, HourName = "19", IsHourChecked = false},
                new Hour {HourId = 20, HourName = "20", IsHourChecked = false},
                new Hour {HourId = 21, HourName = "21", IsHourChecked = false},
                new Hour {HourId = 22, HourName = "22", IsHourChecked = false},
                new Hour {HourId = 23, HourName = "23", IsHourChecked = false},
                new Hour {HourId = 24, HourName = "All Hours", IsHourChecked = false}
            };

            Hours = hours.ToList();
        }

        public static void GetMinuteChecklist()
        {
            List<Minute> minutes = new List<Minute>()
            {
                new Minute {MinuteId = 0, MinuteName = "0", IsMinuteChecked = false},
                new Minute {MinuteId = 1, MinuteName = "1", IsMinuteChecked = false},
                new Minute {MinuteId = 2, MinuteName = "2", IsMinuteChecked = false},
                new Minute {MinuteId = 3, MinuteName = "3", IsMinuteChecked = false},
                new Minute {MinuteId = 4, MinuteName = "4", IsMinuteChecked = false},
                new Minute {MinuteId = 5, MinuteName = "5", IsMinuteChecked = false},
                new Minute {MinuteId = 6, MinuteName = "6", IsMinuteChecked = false},
                new Minute {MinuteId = 7, MinuteName = "7", IsMinuteChecked = false},
                new Minute {MinuteId = 8, MinuteName = "8", IsMinuteChecked = false},
                new Minute {MinuteId = 9, MinuteName = "9", IsMinuteChecked = false},
                new Minute {MinuteId = 10, MinuteName = "10", IsMinuteChecked = false},
                new Minute {MinuteId = 11, MinuteName = "11", IsMinuteChecked = false},
                new Minute {MinuteId = 12, MinuteName = "12", IsMinuteChecked = false},
                new Minute {MinuteId = 13, MinuteName = "13", IsMinuteChecked = false},
                new Minute {MinuteId = 14, MinuteName = "14", IsMinuteChecked = false},
                new Minute {MinuteId = 15, MinuteName = "15", IsMinuteChecked = false},
                new Minute {MinuteId = 16, MinuteName = "16", IsMinuteChecked = false},
                new Minute {MinuteId = 17, MinuteName = "17", IsMinuteChecked = false},
                new Minute {MinuteId = 18, MinuteName = "18", IsMinuteChecked = false},
                new Minute {MinuteId = 19, MinuteName = "19", IsMinuteChecked = false},
                new Minute {MinuteId = 20, MinuteName = "20", IsMinuteChecked = false},
                new Minute {MinuteId = 21, MinuteName = "21", IsMinuteChecked = false},
                new Minute {MinuteId = 22, MinuteName = "22", IsMinuteChecked = false},
                new Minute {MinuteId = 23, MinuteName = "23", IsMinuteChecked = false},
                new Minute {MinuteId = 24, MinuteName = "24", IsMinuteChecked = false},
                new Minute {MinuteId = 25, MinuteName = "25", IsMinuteChecked = false},
                new Minute {MinuteId = 26, MinuteName = "26", IsMinuteChecked = false},
                new Minute {MinuteId = 27, MinuteName = "27", IsMinuteChecked = false},
                new Minute {MinuteId = 28, MinuteName = "28", IsMinuteChecked = false},
                new Minute {MinuteId = 29, MinuteName = "29", IsMinuteChecked = false},
                new Minute {MinuteId = 30, MinuteName = "30", IsMinuteChecked = false},
                new Minute {MinuteId = 31, MinuteName = "31", IsMinuteChecked = false},
                new Minute {MinuteId = 32, MinuteName = "32", IsMinuteChecked = false},
                new Minute {MinuteId = 33, MinuteName = "33", IsMinuteChecked = false},
                new Minute {MinuteId = 34, MinuteName = "34", IsMinuteChecked = false},
                new Minute {MinuteId = 35, MinuteName = "35", IsMinuteChecked = false},
                new Minute {MinuteId = 36, MinuteName = "36", IsMinuteChecked = false},
                new Minute {MinuteId = 37, MinuteName = "37", IsMinuteChecked = false},
                new Minute {MinuteId = 38, MinuteName = "38", IsMinuteChecked = false},
                new Minute {MinuteId = 39, MinuteName = "39", IsMinuteChecked = false},
                new Minute {MinuteId = 40, MinuteName = "40", IsMinuteChecked = false},
                new Minute {MinuteId = 41, MinuteName = "41", IsMinuteChecked = false},
                new Minute {MinuteId = 42, MinuteName = "42", IsMinuteChecked = false},
                new Minute {MinuteId = 43, MinuteName = "43", IsMinuteChecked = false},
                new Minute {MinuteId = 44, MinuteName = "44", IsMinuteChecked = false},
                new Minute {MinuteId = 45, MinuteName = "45", IsMinuteChecked = false},
                new Minute {MinuteId = 46, MinuteName = "46", IsMinuteChecked = false},
                new Minute {MinuteId = 47, MinuteName = "47", IsMinuteChecked = false},
                new Minute {MinuteId = 48, MinuteName = "48", IsMinuteChecked = false},
                new Minute {MinuteId = 49, MinuteName = "49", IsMinuteChecked = false},
                new Minute {MinuteId = 50, MinuteName = "50", IsMinuteChecked = false},
                new Minute {MinuteId = 51, MinuteName = "51", IsMinuteChecked = false},
                new Minute {MinuteId = 52, MinuteName = "52", IsMinuteChecked = false},
                new Minute {MinuteId = 53, MinuteName = "53", IsMinuteChecked = false},
                new Minute {MinuteId = 54, MinuteName = "54", IsMinuteChecked = false},
                new Minute {MinuteId = 55, MinuteName = "55", IsMinuteChecked = false},
                new Minute {MinuteId = 56, MinuteName = "56", IsMinuteChecked = false},
                new Minute {MinuteId = 57, MinuteName = "57", IsMinuteChecked = false},
                new Minute {MinuteId = 58, MinuteName = "58", IsMinuteChecked = false},
                new Minute {MinuteId = 59, MinuteName = "59", IsMinuteChecked = false},
                new Minute {MinuteId = 60, MinuteName = "Every Minute", IsMinuteChecked = false}
            };

            Minutes = minutes.ToList();
        }

        public static void GetSendMSTeamsDropdown()
        {
            List<SendMSTeams> sendTeams = new List<SendMSTeams>()
            {
                new SendMSTeams {SendMSTeamsId = 0, SendMSTeamsName = "Y", IsSendMSTeamsSelected = false},
                new SendMSTeams {SendMSTeamsId = 1, SendMSTeamsName = "N", IsSendMSTeamsSelected = false}
            };

            SendTeams = sendTeams.ToList();
        }

        public static void GetMSTeamsChannelDropdown()
        {
            List<MSTeamsChannel> msTeamsChannel = new List<MSTeamsChannel>()
            {
                new MSTeamsChannel {MSTeamsChannelId = 0, MSTeamsChannelName = "#alerts", IsSendMSTeamsChannelSelected = false}
            };

            MSTeamsChannels = msTeamsChannel.ToList();
        }

        public static void GetSendMailDropdown()
        {
            List<SendMail> sendMail = new List<SendMail>()
            {
                new SendMail {SendMailId = 0, SendMailName = "Y", IsSendMailSelected = false},
                new SendMail {SendMailId = 1, SendMailName = "N", IsSendMailSelected = false}
            };

            SendMails = sendMail.ToList();
        }

        public static void GetDbSchemaDropdown()
        {
            List<DbSchema> dbSchema = new List<DbSchema>()
            {
                new DbSchema {DbSchemaId = 0, DbSchemaName = "MerchDev", IsDbSchemaSelected = false},
                new DbSchema {DbSchemaId = 1, DbSchemaName = "MerchQa", IsDbSchemaSelected = false},
                new DbSchema {DbSchemaId = 2, DbSchemaName = "MerchUat", IsDbSchemaSelected = false},
                new DbSchema {DbSchemaId = 3, DbSchemaName = "MerchPrd", IsDbSchemaSelected = false},
                new DbSchema {DbSchemaId = 4, DbSchemaName = "BcastDev", IsDbSchemaSelected = false},
                new DbSchema {DbSchemaId = 5, DbSchemaName = "Bcast1", IsDbSchemaSelected = false},
                new DbSchema {DbSchemaId = 6, DbSchemaName = "Bcast2", IsDbSchemaSelected = false}
            };

            DbSchemas = dbSchema.ToList();
        }

        public static void GetStatusDropdown()
        {
            List<Status> status = new List<Status>()
            {
                new Status {StatusId = 0, StatusName = "Y", IsStatusSelected = false},
                new Status {StatusId = 1, StatusName = "N", IsStatusSelected = false}
            };

            Statuses = status.ToList();
        }
    }
}
