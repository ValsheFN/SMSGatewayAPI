using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Shared.Models
{
    public class ContactDetail
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public int ContactGroupId { get; set; }
    }
}
