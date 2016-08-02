using Membership.Core.Domain.Application;

namespace Membership.Data.Repository
{
    public class ApplicationRepository : GenericRepository<Application>
    {
        public ApplicationRepository()
            : base(new DomainEfModel())
        {

        }

        //public Membership.Core.Domain.Application.Application LoggedUser(string nameStartsWith)
        //{
        //    return this.GetObjectsByParameters(p => p.Id == 1).FirstOrDefault();
        //}
    }
}