using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Models
{
    public class SmsTemplate : Record
    {
        [Required]
        public string SmsTemplateName { set; get; }
        [Required]
        public string Content { set; get; }
        //Foreign Keys
        public virtual ApplicationUser CreatedByUser { get; set; }
        [ForeignKey(nameof(CreatedByUser))]
        public string CreatedByUserId { get; set; }
        public virtual ApplicationUser UpdatedByUser { get; set; }
        [ForeignKey(nameof(UpdatedByUser))]
        public string UpdatedByUserId { get; set; }
    }
}
