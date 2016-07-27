using System.Collections.Generic;

namespace Membership.Site.Services
{
    public class ListResponse<T> : ServiceResponse
    {
        public List<T> Entities { get; set; }
        public int TotalCount;
        public int Skip;
        public int Take;
    }
}