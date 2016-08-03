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
        public ActionResult Edit()
        {

            var model = new ApplicationModel() { Id = 2, ApplicationCode = "plesk0101", ApplicationName = "Server Panel", Description = "For YOU", Status = 1 };
            return View(model);
        
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