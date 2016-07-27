namespace Membership.Site.Services
{
    public class ListRequest : ServiceRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}