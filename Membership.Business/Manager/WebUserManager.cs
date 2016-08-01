using Membership.Business.Model;
using Membership.Core.Domain.Web;
using Membership.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Business.Manager
{
    public class WebUserManager
    {

        public WebUserManager()
        {

        }

        public WebUserModel LoggedUser(string username)
        {

            var entity = new WebUserRepository().GetObjectByParameters(p => p.Email == username);
            //p.IsDeleted == 0 & 

            if (entity == null)
                return null;
            else
                return new WebUserModel()
                {
                    Id = entity.Id,
                    ApplicationId = entity.ApplicationId,
                    DisplayName = entity.DisplayName,
                    Email = entity.Email
                };
        }
    }
}