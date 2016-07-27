//using System.Web.Mvc;

//namespace Membership.Site.Web.Controllers
//{
//    public class AccountController : Controller
//    {
//        // GET: Account
//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost,HttpGet]
//        [AllowAnonymous]
//        public ActionResult Signin(string username, string password, string returnUrl)
//        {
//            return new JsonResult() { };
//        }

//        [HttpPost]
//        public ActionResult Signin(string email, string password)
//        {
//            return new JsonResult() { };
//        }



//        //[HttpPost, HttpGet]
//        //[AllowAnonymous]
//        //public ActionResult Signin(LoginViewModel model)
//        //{
//        //    var sss = model;

//        //    return new JsonResult() { };
//        //}

//        public ActionResult Signout()
//        {
//            //SecurityHelper.LogOut();
//            var returnURL = Request.QueryString["returnURL"] ?? "~/Login?noWinAuth=1";
//            return new RedirectResult(returnURL);
//        }

//        //public ActionResult Login()
//        //{

//        //    return new JsonResult() {  };
//        //}
//    }
//}