using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Models
{
    public class SmsTemplate
    {
        public int SmsTemplateId { set; get; }
        public string SmsTemplateName { set; get; }
        public string Content { set; get; }
    }
}
