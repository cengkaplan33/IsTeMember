using Membership.Site.Base;
using Membership.Site.Helpers;
using System;
using System.Text;
using System.Web.Mvc;

namespace Membership.Site.ActionFilters
{
    public class LogActionFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            StringBuilder logText = new StringBuilder();
            if (filterContext.Controller is BaseController)
            {
                try
                {
                    BaseController controller = filterContext.Controller as BaseController;

                    logText.Append(" IP = " + MVCUtility.GetRequestIp());
                    logText.Append(" Action = " + MVCUtility.GetControllerActionName());

                    if (filterContext.HttpContext.Request.QueryString.Count > 0)
                        logText.Append(" QueryParameters = " + MVCUtility.GetQueryStringParameters(filterContext.HttpContext.Request.QueryString));

                    //TODO: OK::NOT:: TraceLevel değişkenini web config'e koyup okuyacağım ilgili TraceLevel'e göre log tutulmasını sağlayacağım.
                }
                catch (Exception)
                {
                }
            }

            this.OnActionExecuted(filterContext);
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller is BaseController)
            {
                try
                {
                    //TODO: OK::NOT:: burayada isteğe göre filtre eklenebilir.
                }
                catch (Exception)
                {
                }
            }

            this.OnActionExecuting(filterContext);
        }
    }
}
