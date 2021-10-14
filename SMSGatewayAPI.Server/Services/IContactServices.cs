using SMSGatewayAPI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Services
{
    public interface IContactServices
    {
        Task<OperationResponse<ContactDetail>>
    }
}
