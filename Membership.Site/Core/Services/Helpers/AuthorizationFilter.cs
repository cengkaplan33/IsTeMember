using Membership.Site.Base;
using Membership.Site.Helpers;
using System;
using System.Text;
using System.Web.Mvc;

namespace Membership.Site.ActionFilters
{
    public class AuthorizationFilter : AuthorizeAttribute
    {
        public AuthorizationFilter()
        {
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string action = MVCUtility.GetControllerName() + "/" + MVCUtility.GetControllerActionName();

            if (!MVCUtility.IsUnAuthorizedAction(action))
                base.OnAuthorization(filterContext);
            else return;

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                BaseController controller = filterContext.Controller as BaseController;
                
                //OK::NOT:: gerekli görülen kontroller burada yapılabilinir
            }
            else
            {
                filterContext.Result = new RedirectResult(Constant.Web.RedirectLoginPage);
                return;
            }
        }
    }
}