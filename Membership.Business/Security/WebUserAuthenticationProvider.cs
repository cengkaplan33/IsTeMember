using Membership.Business.Manager;
using System;

namespace Membership.Business.Security
{
    public class SecurityManager
    {
        public bool IsValidUser(string userName, string password)
        {
            try
            {
                var webUser = new WebUserManager().ValidateUser(userName, password);

                if (webUser == null)
                    return false;

                return true;
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