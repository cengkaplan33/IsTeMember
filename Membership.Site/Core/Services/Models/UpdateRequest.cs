using Newtonsoft.Json;

namespace Membership.Site.Services
{
    public class UpdateRequest<TEntity> : ServiceRequest
    {
        public TEntity Entity { get; set; }
        [JsonIgnore]
        public TEntity OldEntity { get; set; }

    }
}
