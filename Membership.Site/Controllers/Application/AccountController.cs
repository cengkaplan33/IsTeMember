using Membership.Site.Base;
using System.Web.Mvc;

namespace Membership.Site.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("~/Views/Membership/Account/Index.cshtml");
        }
    }
}