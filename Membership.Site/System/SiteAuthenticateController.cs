using Membership.Site.Base;
using Membership.Site.Model;
using Membership.Site.Services;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Membership.Site.Controllers
{
    public class SiteAuthenticateController : BaseController
    {
        private bool AdminFakeLogin(string username, string password)
        {
            if (username.StartsWith("@@admin@@\\") && System.Web.Security.Membership.ValidateUser("admin", password))
            {
                username = username.Substring(10);
                //if (UserCache.ByUsername(username) != null)
                if ("sadas" != null)
                {
                    SecurityHelper.SetAuthenticationTicket(username, false, Roles.GetRolesForUser(username));
                    return true;
                }
            }

            return false;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string email, string password)
        {
            var returnUrl = Constant.Web.RedirectHomePage;
            var model = new LoginPageModel();
            model.ReturnURL = returnUrl;
            model.DisplayWinLogin = true;
            var username = email.TrimToNull();

            if (username == null || Request.HttpMethod != "POST")
            {
                //return new RedirectResult("SiteAuthenticate/Index");
                return new RedirectResult(Constant.Web.RedirectLoginPage);
            }
            else
            {
                if (SecurityHelper.Authenticate(username, password, false) || AdminFakeLogin(username, password))
                {
                    returnUrl = FixReturnUrl(Request.ApplicationPath, returnUrl);
                    return Redirect(returnUrl);
                }
                else
                {
                    ViewData["HideLeftNavigation"] = true;
                    model.ErrorMessage = "Giriş işlemi başarısız";
                    return View("Index",model);
                }
            }

            //return new JsonResult() { };
        }

        public ActionResult Signout()
        {
            SecurityHelper.LogOut();
            //var returnURL = Request.QueryString["returnURL"] ?? "~/Login?noWinAuth=1";
            return new RedirectResult(Constant.Web.RedirectLoginPage);
        }

        //OK::NOT:: Index isminde iki method olamaz değişkenleri farklı olsa bile.
        //public ActionResult Index(string email, string password)
        //{
        //    ViewData["PageTitle"] = "Giriş Sayfası";
        //    ViewData["HideLeftNavigation"] = true;

        //    var returnUrl = "Dashboard/Index";
        //    var model = new LoginPageModel();
        //    model.ReturnURL = returnUrl;
        //    model.DisplayWinLogin = true;
        //    var username = String.IsNullOrEmpty(email.Trim()) == false ? null : email.Trim();

        //    if (username == null || Request.HttpMethod != "POST")
        //    {
        //        return new RedirectResult("Login/Index");
        //    }
        //    else
        //    {
        //        if (SecurityHelper.Authenticate(username, password, false) ||
        //            AdminFakeLogin(username, password))
        //        {
        //            returnUrl = FixReturnUrl(Request.ApplicationPath, returnUrl);
        //            return Redirect(returnUrl);
        //        }
        //        else
        //        {
        //            ViewData["HideLeftNavigation"] = true;
        //            model.ErrorMessage = "Giriş işlemi başarısız";
        //            return View(model);
        //        }
        //    }

        //    return View(model);
        //}

        public static string FixReturnUrl(string applicationPath, string returnUrl)
        {
            if (String.IsNullOrEmpty(returnUrl))
                returnUrl = "~/Dashboard";
            else if (!returnUrl.EndsWith("/") &&
                (returnUrl.Equals(applicationPath, StringComparison.OrdinalIgnoreCase) ||
                 (returnUrl + "/").Equals(applicationPath, StringComparison.OrdinalIgnoreCase)))
                returnUrl += "/";

            return returnUrl;
        }

        //[JsonFilter]
        //[HttpPost]
        //public ActionResult Login(LoginRequest request)
        //{
        //    return this.Respond(() =>
        //    {
        //        var response = new LoginResponse();

        //        if (request == null)
        //            throw new ArgumentNullException("request");

        //        if (request.Username == null)
        //            throw new ArgumentNullException("username");

        //        if (SecurityHelper.Authenticate(request.Username, request.Password, false) ||
        //            AdminFakeLogin(request.Username, request.Password))
        //        {
        //            response.CookieName = FormsAuthentication.FormsCookieName;
        //            response.CookieValue = Response.Cookies[FormsAuthentication.FormsCookieName].Value;
        //            return response;
        //        }

        //        throw new ValidationError("AuthenticationError", null,
        //            "Kullanıcı adınız ya da şifreniz hatalı!");
        //    });
        //}

        //[HttpPost]
        //public ActionResult LoginAsUser(LoginAsUserRequest request)
        //{
        //    return this.Respond(() =>
        //    {
        //        var response = new LoginResponse();

        //        if (request == null)
        //            throw new ArgumentNullException("request");

        //        if (request.Username == null)
        //            throw new ArgumentNullException("username");

        //        if (request.LoginAsUser == null)
        //            throw new ArgumentNullException("username");

        //        if (SecurityHelper.Authenticate(request.Username, request.Password, false))
        //        {
        //            var user = UserCache.ByUsername(request.Username);
        //            if (user != null &&
        //                UserRightCache.IsUserHasRight(user.UserId, AccessRights.LoginAsFirmUser))
        //            {
        //                var loginAsUser = UserCache.ByUsername(request.LoginAsUser);
        //                if (loginAsUser != null &&
        //                    UserService.GetUserFirmId(loginAsUser.UserId) ==
        //                    UserService.GetUserFirmId(user.UserId))
        //                {
        //                    SecurityHelper.SetAuthenticationTicket(loginAsUser.Username, false,
        //                        Roles.GetRolesForUser(loginAsUser.Username));
        //                    response.CookieName = FormsAuthentication.FormsCookieName;
        //                    response.CookieValue = Response.Cookies[FormsAuthentication.FormsCookieName].Value;
        //                    return response;
        //                }
        //            }
        //        }

        //        throw new AccessViolationException("Kullanıcı adınız ya da şifreniz hatalı!");
        //    });
        //}

        //public ActionResult Signout()
        //{
        //    SecurityHelper.LogOut();
        //    var returnURL = Request.QueryString["returnURL"] ?? "~/Login?noWinAuth=1";
        //    return new RedirectResult(returnURL);
        //}

        public class LoginRequest : ServiceRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class LoginAsUserRequest : ServiceRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string LoginAsUser { get; set; }
        }

        public class LoginResponse : ServiceResponse
        {
            public string CookieName { get; set; }
            public string CookieValue { get; set; }
        }
    }
}