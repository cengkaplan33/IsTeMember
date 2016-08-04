using Membership.Site.Base;
using Membership.Site.Model;
using Membership.Site.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Membership.Site.Controllers
{
    public class ApplicationController : BaseController
    {
        // GET: Application
        public ActionResult Index()
        {
            return View();
        }

        // GET: Application
        public ActionResult Edit( int? id)
        {
            try
            {
                if (id <= 0)
                {
                    return View(new ApplicationModel { Id = -1 });
                }
                else
                {
                    var response = new ApplicationService().Retrieve(new RetrieveRequest() { EntityId = id });
                    return View(response.Entity);
                }

                //var i = 0;
                //var d = 4 / i;
            }
            catch (Exception exception)
            {
                var sss = ControllerContext;
                return View("~/Views/Shared/Error.cshtml", new System.Web.Mvc.HandleErrorInfo(exception, ControllerContext.RouteData.Values["Controller"].ToString(), ControllerContext.RouteData.Values["Action"].ToString()) { });
            }
            //var model = new ApplicationModel() { Id = 2, ApplicationCode = "plesk0101", ApplicationName = "Server Panel", Description = "For YOU", Status = 1 };
        }

        [HttpPost]
        public ActionResult List(ApplicationListRequest request)
        {
            return this.Respond(() => new ApplicationService().List(request));
        }

        [HttpPost]
        public ActionResult Delete(DeleteRequest request)
        {
            return this.Respond(() => new ApplicationService().Delete(request));
        }

        [HttpPost]
        public ActionResult Update(UpdateRequest<ApplicationModel> request)
        {
            return this.Respond(() => new ApplicationService().Update(request));
        }

        //public class AuditEntryController : GenericEntityController<AuditEntryRow, AuditEntryService, AuditEntryListRequest>
        //{

        //    [AcceptVerbs("POST"), JsonFilter, Authorize]
        //    public ActionResult StartAuditing(AuditEntryStartAuditingRequest request)
        //    {
        //        return this.RespondIn((uow) => new AuditEntryService().StartAuditing(uow, request));
        //    }
        //}
    }
}