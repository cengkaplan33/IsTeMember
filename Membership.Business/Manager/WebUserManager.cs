using Membership.Business.Model;
using Membership.Data.Repository;

namespace Membership.Business.Manager
{
    public class WebUserManager
    {

        public WebUserManager()
        {
        }

        public Membership.Business.Model.WebUser LoggedUser(string username)
        {
            Membership.Core.Domain.Web.WebUser entity = new WebUserRepository().GetObjectByParameters(p => p.Email == username);
            //p.IsDeleted == 0 & 

            if (entity == null)
                return null;
            else
                return new  WebUser()
                {
                    Id = entity.Id,
                    ApplicationId = entity.ApplicationId,
                    DisplayName = entity.DisplayName,
                    Email = entity.Email
                };
        }

        public Membership.Business.Model.WebUser ValidateUser(string username,string password)
        {
            Membership.Core.Domain.Web.WebUser entity = new WebUserRepository().GetObjectByParameters(p => p.Email == username & p.Password== password);
            //p.IsDeleted == 0 & 

            if (entity == null)
                return null;
            else
                return new WebUser()
                {
                    Id = entity.Id,
                    ApplicationId = entity.ApplicationId,
                    DisplayName = entity.DisplayName,
                    Email = entity.Email
                };
        }
    }
}