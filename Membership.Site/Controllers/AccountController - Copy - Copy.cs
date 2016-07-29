using Membership.Site.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Membership.Site.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost,HttpGet]
        [AllowAnonymous]
        public ActionResult Signin(string username, string password, string returnUrl)
        {
            return new JsonResult() { };
        }

        [HttpPost]
        public ActionResult Signin(string email, string password)
        {
            return new JsonResult() { };
        }


        //public class LoginViewModel
        //{
        //    public string email { get; set; }
        //    public string password { get; set; }
        //    public bool rememberMe { get; set; }
        //    public string returnUrl{ get; set; }
        //}


        //[HttpPost, HttpGet]
        //[AllowAnonymous]
        //public ActionResult Signin(LoginViewModel model)
        //{
        //    var sss = model;

        //    return new JsonResult() { };
        //}

        public ActionResult Signout()
        {
            //SecurityHelper.LogOut();
            var returnURL = Request.QueryString["returnURL"] ?? "~/Login?noWinAuth=1";
            return new RedirectResult(returnURL);
        }

        //public ActionResult Login()
        //{

        //    return new JsonResult() {  };
        //}
    }
}