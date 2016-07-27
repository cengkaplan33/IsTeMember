//using Membership.Site.Services;
//using Membership.Site.Base;
//using System.Web.Mvc;

//namespace Membership.Site.Controllers
//{
//    public class AccountController : BaseController
//    {
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public JsonNetResult Search(AccountSearchRequest request)
//        {
//           return     this.Respond(() => new AccountService().List(new AccountSearchRequest() { Tutar = request.Tutar, Vade = request.Vade }));
//        }

//        //public JsonNetResult VadeListesi()
//        //{
//        //    return this.Respond(() => new AccountService().());
//        //}
//    }
//}