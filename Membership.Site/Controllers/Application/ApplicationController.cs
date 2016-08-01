using Membership.Site.Base;
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

        [HttpPost]
        public ActionResult List(ApplicationListRequest request)
        {
            return this.Respond(() => new ApplicationService().List(request));
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