using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Shared
{
    class CreateRoleViewModel
    {
        [Required]
        public string RoleName { set; get; }
    }
}
