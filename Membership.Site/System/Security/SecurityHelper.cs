using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Text;
using System.IO;
using Membership.Business.Security;
using Membership.Site.Services;
using Membership.Site.Model;

namespace Membership.Site
{
    public enum RightErrorHandling
    {
        ThrowException,
        Redirect,
        RedirectIfNotSignedIn
    }

    /// <summary>
    ///   Static class contains helper functions associated with user rights, login, encrypting </summary>
    public static class SecurityHelper
    {
        /// <summary>
        ///   Standart super username for membership </summary>
        public const string AdminUser = "admin";

        /// <summary>
        ///   Validate user identity by checking username and password and sets 
        ///   authentication ticket that is based on cookie  
        /// </summary>
        /// <param name="username">
        ///   Username to be validated (required).</param>
        /// <param name="password">
        ///   User Password to be validated(required).</param>
        /// <param name="persist">
        ///   true to make ticket persistent? (beni hatırla seçeneği, güvenlik açısından pek kullanmıyoruz.)</param>
        /// <returns>
        ///   if validation is successful,returns true and sets ticket. if it is invalid, returns only false
        ///   ,doesn't change current ticket.</returns>
        public static bool Authenticate(string username, string password, bool persist)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (password == null)
                throw new ArgumentNullException("password");

            //if (! System.Web.Security.Membership.ValidateUser(username, password))
            //    return false;

            if (!new SecurityManager().IsValidUser(username, password))
                return false;

            SetAuthenticationTicket(username, persist);
            return true;
        }


        /// <summary>
        ///   Sets authentication cookie.</summary>
        /// <param name="username">
        ///   Validated Username (required).</param>
        /// <param name="persist">
        ///   is persistent authentication tikcet? (remember me, we don't use this for reasons considering with security)</param>
        /// <param name="roles">
        ///   Roles users has. Persisted in cookie for quick access</param>
        public static void SetAuthenticationTicket(string username, bool persist, params string[] roles)
        {
            if (username == null)
                throw new ArgumentNullException(username);

            //HttpCookie authCookie = FormsAuthentication.GetAuthCookie(username, persist);
            //FormsAuthenticationTicket tempTicket = FormsAuthentication.Decrypt(authCookie.Value);

            //string userData = string.Join("|", roles);

            //var cookiePath = HttpContext.Current.Request.ApplicationPath;
            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            //    tempTicket.Version,
            //    tempTicket.Name,
            //    tempTicket.IssueDate,
            //    tempTicket.Expiration,
            //    persist,
            //    userData,
            //    cookiePath);
            //authCookie.Value = FormsAuthentication.Encrypt(authTicket);
            //authCookie.Name = FormsAuthentication.FormsCookieName;
            //authCookie.Path = cookiePath;

            //HttpContext.Current.Response.Cookies.Remove(authCookie.Name);
            //HttpContext.Current.Response.Cookies.Add(authCookie);

            FormsAuthentication.SetAuthCookie(username, false);
        }

        private static string[] EmptyStringArray = new string[0];

        /// <summary>
        ///   Gets list of roles for current user from authentication cookie</summary>
        /// <returns>
        ///   An array of user roles.</returns>
        public static string[] GetAuthenticatedRoles()
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                HttpCookie authCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null &&
                    authCookie.Value != null &&
                    authCookie.Value.Length > 0)
                {
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (authTicket.UserData != null)
                        return authTicket.UserData.Split('|');
                }
            }

            return EmptyStringArray;
        }

        /// <summary>
        ///   Logs out to logged user.</summary>
        public static void LogOut()
        {
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            // Setting up a cookie which has expired, Enforce client to delete this cookie.
            authCookie.Expires = DateTime.Now.AddYears(-30);
            authCookie.HttpOnly = true;
            //authCookie.Path = UrlHelper.GetApplicationRootPath();

            // bu path /site olmalı, /site/ olduğunda eğer http://sunucu/site yazılırsa path cookie bu yola uygulanmıyor, sürekli login gerekiyor!
            authCookie.Path = HttpContext.Current.Request.ApplicationPath;
            HttpContext.Current.Response.Cookies.Add(authCookie);


            //// clear authentication cookie
            //HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            //cookie1.Expires = DateTime.Now.AddYears(-1);
            //Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie2);

            FormsAuthentication.SignOut();
        }

        /// <summary>
        ///   Gets user unique ID (as GUID).</summary>
        /// <param name="username">
        ///   Username, its ID will be found (required).</param>
        /// <returns>
        ///   Kullanıcı bulunursa ID'si. Bulunamazsa Guid.Empty.</returns>
        /// <returns>
        ///   Returns user id if it is found, else Guid.Empty .</returns>
        public static Int32? GetUserID(string username)
        {
            if (username == null)
                throw new ArgumentNullException("username");

            //todo: user EF den alınacak.
            //var user = UserCache.ByUsername(username);
            //if (user == null)
            //    return null;
            //else
            //    return user.UserId;

            return 3;
        }

        public const int AdminUserId = 1;

        /// <summary>
        ///   Checks whether current user is admin or not</summary>
        /// <summary>
        ///   Allows Active .</summary>
        /// <returns>
        ///   if it is "Admin" returns true.</returns>
        public static bool IsAdmin()
        {
            return (LoggedUser == AdminUser) || ImpersonatedUserId == AdminUserId;
        }

        /// <summary>
        ///   Checks whether given username is admin</summary>
        /// <param name="username">
        ///   Username will be checked.</param>
        /// <returns>
        ///   Returns true if given user is admin.</returns>
        public static bool IsAdmin(string username)
        {
            return username == AdminUser;
        }

        /// <summary>
        ///   Indicates whether logged user is in given role or not .</summary>
        /// <param name="role">
        ///   Role will be checked (required).</param>
        /// <returns>
        ///   Returns true if the user in role</returns>
        public static bool IsInRole(string role)
        {
            if (role == null || role.Length == 0)
                throw new ArgumentNullException("role");

            if (LoggedUser == null)
                return false;

            return HttpContext.Current.User.IsInRole(role);
        }

        /// <summary>
        ///   Checks if user is logged in.</summary>
        public static bool IsLoggedIn
        {
            get
            {
                string loggedUser = LoggedUser;
                return (loggedUser != null && loggedUser.Length > 0);
            }
        }

        /// <summary>
        ///   Returns logged user, else if empty string or null.</summary>
        public static string LoggedUser
        {
            get
            {
                if (HttpContext.Current != null &&
                    HttpContext.Current.Request != null &&
                    HttpContext.Current.Request.IsAuthenticated)
                {
                    try
                    {
                        return HttpContext.Current.User.Identity.Name;
                    }
                    catch
                    {
                    }
                }
                return null;
            }
        }

        public static Int32 CurrentUserId
        {
            get
            {
                var userId = CurrentUserIdOrNull;
                if (userId == null)
                    throw new InvalidOperationException("Giriş yapmış bir kullanıcı yok!");

                return userId.Value;
            }
        }

        public static Int32 ActualUserId
        {
            get
            {
                var userId = ActualUserIdOrNull;
                if (userId == null)
                    throw new InvalidOperationException("Giriş yapmış bir kullanıcı yok!");

                return userId.Value;
            }
        }

        public static Int32? ActualUserIdOrNull
        {
            get
            {
                string username = LoggedUser;
                if (String.IsNullOrEmpty(username))
                    return null;


                var user = new WebUserService().LoggedUser();
                //var user = UserCache.ByUsername(username);
                if (user == null || user.Entity == null)
                    return null;

                return user.Entity.Id;

                //return 3;
            }
        }

        public static WebUserModel LoggerUserItem
        {
            get
            {
                string username = LoggedUser;
                if (username.IsEmptyOrNull())
                    return null;

                var response = new WebUserService().LoggedUser();
                if (response == null || response.Entity == null)
                    return null;

                return response.Entity;
            }
        }


        public static Int32? CurrentUserIdOrNull
        {
            get
            {
                var impersonated = ImpersonatedUserId;
                if (impersonated != null)
                    return impersonated;
                return ActualUserIdOrNull;
            }
        }

        private static Int32? ImpersonatedUserId
        {
            get
            {
                var stack = ContextItems.Get<List<Int32>>("ImpersonationStack", null);
                if (stack != null && stack.Count > 0)
                    return stack[stack.Count - 1];
                return null;
            }
        }

        public static void Impersonate(Int32 userId)
        {
            var stack = ContextItems.Get<List<Int32>>("ImpersonationStack", null);
            if (stack != null)
            {
                stack.Add(userId);
                return;
            }
            else
            {
                stack = new List<int>();
                stack.Add(userId);
                ContextItems.Set("ImpersonationStack", stack);
            }
        }

        public static void UndoImpersonate()
        {
            var stack = ContextItems.Get<List<Int32>>("ImpersonationStack", null);
            if (stack != null && stack.Count > 0)
                stack.RemoveAt(stack.Count - 1);
        }

        static SecurityHelper()
        {
        }
    }
}