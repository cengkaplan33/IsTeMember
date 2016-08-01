using System;

namespace Membership.Core.Domain
{
    public class DomainBase
    {
        public string RequestIp { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public byte? IsDeleted { get; set; }
    }
}