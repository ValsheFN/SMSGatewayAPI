using System;

namespace SMSGatewayAPI.Models
{
    public class Logs
    {
        public int LogsId { get; set; }
        public string From { get; set; }
        public string SendTo { get; set; }
        public string Messages { get; set; }
        public DateTime? TimeSent { get; set; }
    }
}
