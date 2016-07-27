using Membership.Site.ActionFilters;
using System;
using System.Web.Mvc;

namespace Membership.Site.Base
{
    [LogActionFilter]
    public class BaseController : Controller, IDisposable
    {
        public BaseController()
        {
            //OK::NOT:: culture vb  gibi tanımların veya önceden tanımlı sistem için gerekli veriler burada SET edilebilir.
        }

        #region Private Members

        //yukarıda bahsettiğim gibi varsa ön tanımlı değişkenler private olarak tanımlanır doldurulur ve ilgili yerlerde kullanılabilir.

        #endregion


        protected override void HandleUnknownAction(string actionName)
        {
            ViewBag.ErrorMessage = "İşlem bulunamadı";

            this.View("Error").ExecuteResult(this.ControllerContext);
        }
    }
}