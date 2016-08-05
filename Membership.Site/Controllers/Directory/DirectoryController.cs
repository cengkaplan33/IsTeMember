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
    public class DirectoryController : BaseController
    {
        // GET: Directory
        public ActionResult Index()
        {
            return View("~/Views/Membership/Directory/Index.cshtml");
        }

        // GET: Directory
        public ActionResult Edit( int? id)
        {
            try
            {
                if (id <= 0)
                {
                    return View("~/Views/Membership/Directory/Edit.cshtml", new DirectoryModel() { Id = -1 });
                }
                else
                {
                    var response = new DirectoryService().Retrieve(new RetrieveRequest() { EntityId = id });
                    return View("~/Views/Membership/Directory/Edit.cshtml", response.Entity);
                }

                //var i = 0;
                //var d = 4 / i;
            }
            catch (Exception exception)
            {
                var sss = ControllerContext;
                return View("~/Views/Shared/Error.cshtml", new System.Web.Mvc.HandleErrorInfo(exception, ControllerContext.RouteData.Values["Controller"].ToString(), ControllerContext.RouteData.Values["Action"].ToString()) { });
            }
            //var model = new DirectoryModel() { Id = 2, DirectoryCode = "plesk0101", DirectoryName = "Server Panel", Description = "For YOU", Status = 1 };
        }

        [HttpPost]
        public ActionResult List(DirectoryListRequest request)
        {
            return this.Respond(() => new DirectoryService().List(request));
        }

        [HttpPost]
        public ActionResult Delete(DeleteRequest request)
        {
            return this.Respond(() => new DirectoryService().Delete(request));
        }

        [HttpPost]
        public ActionResult Update(UpdateRequest<DirectoryModel> request)
        {
            return this.Respond(() => new DirectoryService().Update(request));
        }

        [HttpPost]
        public ActionResult Create(CreateRequest<DirectoryModel> request)
        {
            return this.Respond(() => new DirectoryService().Create(request));
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