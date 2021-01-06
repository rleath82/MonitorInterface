namespace MonitorInterface.Client.Models
{
    public class Month
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public bool IsMonthChecked { get; set; }
    }

    public class Day
    {
        public int DayId { get; set; }
        public string DayName { get; set; }
        public bool IsDayChecked { get; set; }
    }

    public class Hour
    {
        public int HourId { get; set; }
        public string HourName { get; set; }
        public bool IsHourChecked { get; set; }
    }

    public class Minute
    {
        public int MinuteId { get; set; }
        public string MinuteName { get; set; }
        public bool IsMinuteChecked { get; set; }
    }

    public class SendMSTeams
    {
        public int SendMSTeamsId { get; set; }
        public string SendMSTeamsName { get; set; }
        public bool IsSendMSTeamsSelected { get; set; }
    }

    public class MSTeamsChannel
    {
        public int MSTeamsChannelId { get; set; }
        public string MSTeamsChannelName { get; set; }
        public bool IsSendMSTeamsChannelSelected { get; set; }
    }

    public class SendMail
    {
        public int SendMailId { get; set; }
        public string SendMailName { get; set; }
        public bool IsSendMailSelected { get; set; }
    }

    public class SqlString
    {
        public string SqlStatement { get; set; }
    }

    public class DbSchema
    {
        public int DbSchemaId { get; set; }
        public string DbSchemaName { get; set; }
        public bool IsDbSchemaSelected { get; set; }
    }

    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsStatusSelected { get; set; }
    }
}
