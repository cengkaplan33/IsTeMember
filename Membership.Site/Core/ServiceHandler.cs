using System;
using Membership.Site.Services;

namespace Membership.Site.Base
{
    public static class ServiceHandler
    {
        public static ServiceResponse ToServiceResponse(this Exception exception)
        {
            //TODO: OK::NOT: servis cevapları tekbir yerden loglanabilir 
            var response = new ServiceResponse();
            var error = new ServiceError();

            error.Code = "Exception";
            error.Message = exception.Message;
            error.Details = exception.ToString();


            response.Error = error;

            return response;
        }

        public static JsonNetResult Respond(this BaseController controller, Func<ServiceResponse> handler)
        {
            ServiceResponse response;
            try
            {
                response = handler();
            }
            catch (Exception exception)
            {
                response = exception.ToServiceResponse();
            }

            return response.ToJsonResult();
        }

        //public static System.Web.UI.WebControls.View RespondView(this BaseController controller, Func<System.Web.UI.WebControls.View> handler)
        //{            
        //    try
        //    {
        //        return handler();
        //    }
        //    catch (Exception exception)
        //    {
        //        return new System.Web.Mvc.ViewResult { View( } (Controller.View("~/Views/Shared/Error.cshtml", new System.Web.Mvc.HandleErrorInfo(exception, "controller", "action") { });
        //    }
        //}
    }
}