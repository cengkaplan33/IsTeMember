using Membership.Site.Base;
using System.Web.Mvc;

namespace Membership.Site.Controllers
{
    public class DomainController : BaseController
    {
        // GET: Domain
        public ActionResult Index()
        {
            return View("~/Views/Membership/Domain/Index.cshtml");
        }
    }
}