using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Models
{
    public class TopUp : Record
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TopUpValue { get; set; }
        public string Requester { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime GrantDate { get; set; }
        public string GrantedBy { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        [ForeignKey(nameof(CreatedByUser))]
        public string CreatedByUserId { get; set; }
        public virtual ApplicationUser UpdatedByUser { get; set; }
        [ForeignKey(nameof(UpdatedByUser))]
        public string UpdatedByUserId { get; set; }
    }
}
