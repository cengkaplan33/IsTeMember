
using System;
using System.Web;
using System.Collections.Specialized;

namespace Membership.Site.Controllers
{
    public class LoginController : Controller
    {
        private bool AdminFakeLogin(string username, string password)
        {
            if (username.StartsWith("@@admin@@\\") &&
                Membership.ValidateUser("admin", password))
            {
                username = username.Substring(10);
                if (UserCache.ByUsername(username) != null)
                {
                    SecurityHelper.SetAuthenticationTicket(username, false, Roles.GetRolesForUser(username));
                    return true;
                }
            }

            return false;
        }

        public static bool IsIntranetRequest(string ip)
        {
            return ip != null && (
                ip.StartsWith("172.") || ip == "::1" || ip == "127.0.0.1");
        }

        public static bool IsRequestThroughProxy(NameValueCollection serverVariables)
        {
            if (serverVariables == null)
                throw new ArgumentNullException("serverVariables");

            string host = serverVariables["REMOTE_ADDR"];
            if (host.IsTrimmedSame("172.24.0.111") ||
                host.IsTrimmedSame("172.20.0.111") ||
                host.IsTrimmedSame("172.27.30.111"))
                return true;

            if (!serverVariables["HTTP_VIA"].IsTrimmedEmpty())
                return true;

            return false;
        }

        public ActionResult Index(string username, string password, string loginfailure, string returnUrl, string noWinAuth)
        {
            ViewData["PageTitle"] = LocalText.Get("Pages.Login.Title");
            ViewData["HideLeftNavigation"] = true;

            var model = new LoginPageModel();
            model.ReturnURL = returnUrl;
            model.DisplayWinLogin = true;
            username = username.TrimToNull();

            model.IsUsingProxy = IsRequestThroughProxy(Request.ServerVariables);

            if (username == null || Request.HttpMethod != "POST")
            {
                if (loginfailure == "1")
                {
                    model.Username = (string)Session["faileduser"];
                    model.ErrorMessage = LocalText.Get("Pages.Login.Failure");
                }
                else
                {

                    string loggedUser = SecurityHelper.LoggedUser;
                    if (!loggedUser.IsEmptyOrNull() && returnUrl != null)
                        model.ErrorMessage = LocalText.GetFormat("Pages.Login.NoRights", loggedUser, returnUrl);
                    else
                    {
                        if (System.Configuration.ConfigurationManager.AppSettings["EnableAutoWinAuth"] != "1")
                            noWinAuth = "1";

                        if (noWinAuth != "1" && 
                            IsIntranetRequest(Request.ServerVariables["REMOTE_ADDR"]) &&
                            (returnUrl == null || !returnUrl.Contains("WinLogin.aspx")))  
                            return new RedirectResult("~/WinLogin.aspx?returnURL=" + Uri.EscapeDataString(returnUrl ?? ""));
                    }
                }
            }
            else
            {
                if (SecurityHelper.Authenticate(username, password, false) ||
                    AdminFakeLogin(username, password))
                {
                    returnUrl = FixReturnUrl(Request.ApplicationPath, returnUrl);
                    return Redirect(returnUrl);
                }
                else
                {
                    ViewData["HideLeftNavigation"] = true;
                    model.ErrorMessage = LocalText.Get("Pages.Login.Failure");
                    return View(model);
                }
            }

            return View(model);
        }

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

        [JsonFilter]
        [HttpPost]
        public ActionResult Login(LoginRequest request)
        {
            return this.Respond(() => {
                var response = new LoginResponse();

                if (request == null)
                    throw new ArgumentNullException("request");
                
                if (request.Username == null)
                    throw new ArgumentNullException("username");

                if (SecurityHelper.Authenticate(request.Username, request.Password, false) ||
                    AdminFakeLogin(request.Username, request.Password))
                {
                    response.CookieName = FormsAuthentication.FormsCookieName;
                    response.CookieValue = Response.Cookies[FormsAuthentication.FormsCookieName].Value;
                    return response;
                }

                throw new ValidationError("AuthenticationError", null,
                    "Kullanıcı adınız ya da şifreniz hatalı!");
            });
        }

        [JsonFilter]
        [HttpPost]
        public ActionResult LoginAsUser(LoginAsUserRequest request)
        {
            return this.Respond(() =>
            {
                var response = new LoginResponse();

                if (request == null)
                    throw new ArgumentNullException("request");

                if (request.Username == null)
                    throw new ArgumentNullException("username");

                if (request.LoginAsUser == null)
                    throw new ArgumentNullException("username");

                if (SecurityHelper.Authenticate(request.Username, request.Password, false))
                {
                    var user = UserCache.ByUsername(request.Username);
                    if (user != null &&
                        UserRightCache.IsUserHasRight(user.UserId, AccessRights.LoginAsFirmUser))
                    {
                        var loginAsUser = UserCache.ByUsername(request.LoginAsUser);
                        if (loginAsUser != null &&
                            UserService.GetUserFirmId(loginAsUser.UserId) == 
                            UserService.GetUserFirmId(user.UserId))
                        {
                            SecurityHelper.SetAuthenticationTicket(loginAsUser.Username, false, 
                                Roles.GetRolesForUser(loginAsUser.Username));
                            response.CookieName = FormsAuthentication.FormsCookieName;
                            response.CookieValue = Response.Cookies[FormsAuthentication.FormsCookieName].Value;
                            return response;
                        }
                    }
                }

                throw new AccessViolationException("Kullanıcı adınız ya da şifreniz hatalı!");
            });
        }

        public ActionResult Signout()
        {
            SecurityHelper.LogOut();
            var returnURL = Request.QueryString["returnURL"] ?? "~/Login?noWinAuth=1";
            return new RedirectResult(returnURL);
        }

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