using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Models
{
    public class TopUp
    {
        public string TopUpId { get; set; }
        public string ContactId { get; set; }
        public string Requester { get; set; }
        public string Status { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? GrantDate { get; set; }
    }
}
