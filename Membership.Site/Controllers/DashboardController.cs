using Membership.Site.Base;
using System.Web.Mvc;

namespace Membership.Site.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}