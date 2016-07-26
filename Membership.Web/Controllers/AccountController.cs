using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Membership.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost,HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            return new JsonResult() { };
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            return new JsonResult() { };
        }


        public class LoginViewModel
        {
            public string email { get; set; }
            public string password { get; set; }
            public bool rememberMe { get; set; }
            public string returnUrl{ get; set; }
        }


        [HttpPost, HttpGet]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            var sss = model;

            return new JsonResult() { };
        }

        //public ActionResult Login()
        //{

        //    return new JsonResult() {  };
        //}
    }
}