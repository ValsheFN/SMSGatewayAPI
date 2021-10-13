using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSGatewayAPI.Models
{
    public class ContactGroup : Record
    {
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        //Foreign Keys
        public virtual ApplicationUser CreatedByUser { get; set; }
        [ForeignKey(nameof(CreatedByUser))]
        public string CreatedByUserId { get; set; }
        public virtual ApplicationUser UpdatedByUser { get; set; }
        [ForeignKey(nameof(UpdatedByUser))]
        public string UpdatedByUserId { get; set; }
    }
}
