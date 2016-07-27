using System.Collections.Generic;

namespace Membership.Site.Services
{
    public class RetrieveResponse<T> : ServiceResponse
    {
        public T Entity { get; set; }
    }
}