using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Models
{
    public abstract class Record
    {
        public Record()
        {
            CreationDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
