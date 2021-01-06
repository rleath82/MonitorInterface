namespace MonitorInterface.Client.Models.ServiceSuspends
{
    public class ServiceSuspend
    {
        public string JobId { get; set; }
        public string JobName { get; set; }
        public string ServiceStart { get; set; }
        public string ServiceStop { get; set; }
        public string ScheduledDownTime { get; set; }
        public bool IsJobSelected { get; set; }
    }
}
