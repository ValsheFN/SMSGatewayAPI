using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SMSGatewayAPI.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public int ContactGroupId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }
        public string RoleId { get; set; }
    }
}
