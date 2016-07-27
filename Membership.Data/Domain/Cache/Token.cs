using System;
using System.Collections.Generic;

namespace Membership.Core.Domain.Cache
{
    public class Token
    {
        public Token()
        {
            IpList = new List<string>();
            CreateTime = DateTime.Now;
        }

        public string ApplicationCode { get; set; }

        public string TokenId { get; set; }

        public List<string> IpList { get; set; }

        public DateTime CreateTime { get; }

        public string RequestIp { get; set; }
    }
}