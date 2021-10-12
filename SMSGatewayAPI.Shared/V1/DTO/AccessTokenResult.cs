using System;
using System.Collections.Generic;
using System.Text;

namespace SMSGatewayProject.Shared.V1.DTO
{
    public class AccessTokenResult
    {
        public AccessTokenResult(string token, DateTime expiryDate)
        {
            Token = token;
            ExpiryDate = expiryDate;
        }

        public AccessTokenResult()
        {

        }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

    }
}
