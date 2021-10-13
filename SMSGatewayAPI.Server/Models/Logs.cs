using System;
using System.ComponentModel.DataAnnotations;

namespace SMSGatewayAPI.Models
{
    public class Logs
    {
        public int LogsId { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string SendTo { get; set; }
        [Required]
        public string Messages { get; set; }
        [Required]
        public DateTime TimeSent { get; set; }
    }
}
