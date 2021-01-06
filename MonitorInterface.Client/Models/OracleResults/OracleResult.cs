namespace MonitorInterface.Client.Models.OracleResults
{
    public class OracleResult
    {
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string JobName { get; set; }
        public string Status { get; set; }
        public string DbSchema { get; set; }
        public string SqlString { get; set; }
        public string IssueDescription { get; set; }
        public string EmailSubject { get; set; }
        public string JobId { get; set; }
        public string MSTeamsChannel { get; set; }
        public string MSTeamsUrl { get; set; }
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string SlackUser { get; set; }
        public string SendMail { get; set; }
        public string SendMSTeams { get; set; }
    }
}
