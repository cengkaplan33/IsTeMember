namespace Membership.Site.Services
{
    public class CreateRequest<TEntity> : ServiceRequest
    {
        public TEntity Entity { get; set; }
    }
}