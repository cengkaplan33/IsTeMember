using Membership.Core.Domain.Web;

namespace Membership.Data.Repository
{
    public class WebUserRepository : GenericRepository<WebUser>
    {
        public WebUserRepository()
            : base(new DomainEfModel())
        {

        }

        //public Membership.Core.Domain.Application.Application LoggedUser(string nameStartsWith)
        //{
        //    return this.GetObjectsByParameters(p => p.Id == 1).FirstOrDefault();
        //}
    }
}