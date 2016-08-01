
using Membership.Site.Model;
using System.Linq;

namespace Membership.Site.Services
{
    public partial class WebUserService
    {
        //public ListResponse<AccountModel> List(AccountSearchRequest request)
        //{
        //    ListResponse<AccountModel> response = new ListResponse<AccountModel>();

        //    if (request.Vade == 0 || request.Tutar == 0)
        //        return response;


        //    //using (var db = new BenimKredimModel())
        //    //{
        //    //    response.Entities = db.BankCredits.Where(x => x.CreditTypeId == (int)BankCreditType.Personal & x.InstalmentCount == request.Vade)
        //    //        .Select(x => new AccountModel()
        //    //        {
        //    //            BankaAdi = x.Bank.Name,
        //    //            VadeOrani = x.ProfitRate,
        //    //            VadeliTutar = (request.Tutar + request.Tutar * x.ProfitRate)
        //    //        })
        //    //        .ToList();
        //    //}

        //    return response;
        //}

        public RetrieveResponse<WebUserModel> Retrieve(RetrieveRequest request)
        {
            RetrieveResponse<WebUserModel> response = new RetrieveResponse<WebUserModel>();

            if (request.EntityId == null || request.EntityId <= 0)
                throw new System.Exception("EntityId is null or unassigned");


            return response;
        }

        public RetrieveResponse<WebUserModel> LoggedUser()
        {
            RetrieveResponse<WebUserModel> response = new RetrieveResponse<WebUserModel>();

            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

            }
            var webUserEntity = new Membership.Business.Manager.WebUserManager().LoggedUser(System.Web.HttpContext.Current.User.Identity.Name);
            //response.Entity = new WebUserModel() { ApplicationId = 1, Id = 1, DisplayName = "Ömer KAPLAN", Email = "ok@g.com" };

            response.Entity = new WebUserModel()
            {
                ApplicationId = webUserEntity.ApplicationId,
                Id = webUserEntity.Id,
                DisplayName = webUserEntity.DisplayName,
                Email = webUserEntity.Email
            };

            return response;
        }
    }
}