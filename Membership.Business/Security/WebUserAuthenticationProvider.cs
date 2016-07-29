using Membership.Business.Model;
using Membership.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Business.Security
{
    public class SecurityManager
    {
        public bool IsValidUser(string userName, string password)
        {
            try
            {
                Core.Domain.Web.WebUser webUser;
                using (var db = new Membership.Data.DomainEfModel())
                    webUser = new WebUserRepository(db).GetObjectByParameters(p => p.Email == userName);

                if (webUser == null)
                    return false;

                if (webUser.Password == password)
                    return true;

                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //public Model.WebUser ValidateUser(string userName, string password)
        //{
        //    try
        //    {
        //        Core.Domain.Web.WebUser webUser;
        //        using (var db = new Membership.Data.DomainEfModel())
        //        {
        //            var webUserRepo = new WebUserRepository(db);

        //            webUser = webUserRepo.GetObjectByParameters(p => p.Email == userName);
        //        }

        //        if (webUser != null)
        //        {
        //            if (webUser.Password == password)
        //            {
        //                return new WebUser() { ApplicationId = webUser.ApplicationId, DisplayName = webUser.DisplayName, Id = webUser.Id, Email = webUser.Email };
        //            }
        //            else throw new Exception("InvalidUser");
        //        }
        //        else throw new Exception("UserRecordNotFound");
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}
    }
}