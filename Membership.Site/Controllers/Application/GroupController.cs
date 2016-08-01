using Membership.Site.Base;
using System.Web.Mvc;

namespace Membership.Site.Controllers
{
    public class GroupController : BaseController
    {
        // GET: Group
        public ActionResult Index()
        {
            return View("~/Views/Membership/Group/Index.cshtml");
        }
    }
}