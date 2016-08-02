using Membership.Business.Manager;
using Membership.Site.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Site.Services
{

    public class ApplicationListRequest : ListRequest
    {
        public int TaskId { get; set; }
    }

    public partial class ApplicationService
    {
        public ListResponse<ApplicationModel> List(ApplicationListRequest request)
        {
            ListResponse<ApplicationModel> response = new ListResponse<ApplicationModel>();
            var applications = new ApplicationManager().List();

            if (applications == null || applications.Count == 0)
                return response;

            

                response.Entities = applications.Select(entity => new ApplicationModel()
            {
                Id = entity.Id,
                ApplicationCode = entity.ApplicationCode,
                ApplicationName = entity.ApplicationName,
                Description = entity.Description,
                Status = entity.Status
            }).ToList();
            //    .ToList();


            //response.Entities = new System.Collections.Generic.List<ApplicationModel>();
            //response.Entities.Add(new ApplicationModel() { ApplicationId = 1, Application = "Reseller Plesk Panel" });
            //response.Entities.Add(new ApplicationModel() { ApplicationId = 2, Application = "Reseller Cloud Server Manager" });
            //response.Entities.Add(new ApplicationModel() { ApplicationId = 3, Application = "Admin Plesk Panel" });
            //response.Entities.Add(new ApplicationModel() { ApplicationId = 4, Application = "Admin Cloud Server Manager" });

            //for (int i = 5; i < 20; i++)
            //    response.Entities.Add(new ApplicationModel() { ApplicationId = i, Application = " Admin " + i + " Cloud Server Manager" });
          
            return response;
        }

        //public ListResponse<VadeModel> VadeListesi()
        //{
        //    ListResponse<VadeModel> response = new ListResponse<VadeModel>();

        //    using (var db = new BenimKredimModel())
        //    {
        //        response.Entities = db.BankCredits.Where(x => x.CreditTypeId == (int)BankCreditType.Personal)
        //            .Select(x => new VadeModel { Vade = x.InstalmentCount })
        //            .Distinct().OrderBy(x => x.Vade)
        //            .ToList();

        //        response.TotalCount = response.Entities.Count();
        //    }

        //    return response;
        //}

    }
}