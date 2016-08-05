using Membership.Business.Manager;
using Membership.Site.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Site.Services
{

    public class DirectoryListRequest : ListRequest
    {
        public int TaskId { get; set; }
    }

    public partial class DirectoryService
    {
        public ListResponse<DirectoryModel> List(DirectoryListRequest request)
        {
            ListResponse<DirectoryModel> response = new ListResponse<DirectoryModel>();

            var Directorys = new DirectoryManager().List();

            if (Directorys == null || Directorys.Count == 0)
                return response;



            response.Entities = Directorys.Select(entity => new DirectoryModel()
            {
                Id = entity.Id.Value,
                DirectoryCode = entity.DirectoryCode,
                DirectoryName = entity.DirectoryName,
                Description = entity.Description ?? "",
                Status = entity.Status
            }).ToList();
            //    .ToList();


            //response.Entities = new System.Collections.Generic.List<DirectoryModel>();
            //response.Entities.Add(new DirectoryModel() { DirectoryId = 1, Directory = "Reseller Plesk Panel" });
            //response.Entities.Add(new DirectoryModel() { DirectoryId = 2, Directory = "Reseller Cloud Server Manager" });
            //response.Entities.Add(new DirectoryModel() { DirectoryId = 3, Directory = "Admin Plesk Panel" });
            //response.Entities.Add(new DirectoryModel() { DirectoryId = 4, Directory = "Admin Cloud Server Manager" });

            //for (int i = 5; i < 20; i++)
            //    response.Entities.Add(new DirectoryModel() { DirectoryId = i, Directory = " Admin " + i + " Cloud Server Manager" });

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

        public DeleteResponse Delete(DeleteRequest request)
        {
            if (request.EntityId == null || request.EntityId <= 0)
                throw new Exception("EntityId boş geçilemez");


            //OK::NOT:: aşağıdaki şekilde WebUserManager a erişebilirim ama katmanlı yapı adına bu işlemi servis üzerinden yapacağım.
            //new Membership.Business.Manager.WebUserManager().LoggedUser(System.Web.HttpContext.Current.User.Identity.Name);

            var loggedUser = SecurityHelper.LoggerUserItem;

            new DirectoryManager(new Business.Model.WebUser()
            {
                Id = loggedUser.Id.Value,
            }).Delete(request.EntityId.Value);

            return new DeleteResponse();
        }

        public RetrieveResponse<DirectoryModel> Retrieve(RetrieveRequest request)
        {
            if (request.EntityId == null || request.EntityId <= 0)
                throw new Exception("EntityId boş geçilemez");


            //OK::NOT:: aşağıdaki şekilde WebUserManager a erişebilirim ama katmanlı yapı adına bu işlemi servis üzerinden yapacağım.
            //new Membership.Business.Manager.WebUserManager().LoggedUser(System.Web.HttpContext.Current.User.Identity.Name);

            var loggedUser = SecurityHelper.LoggerUserItem;

            var model = new DirectoryManager(new Business.Model.WebUser()
            {
                Id = loggedUser.Id.Value,
            }).Retrieve(request.EntityId.Value);

            return new RetrieveResponse<DirectoryModel>()
            {
                Entity = new DirectoryModel()
                {
                    Id = model.Id.Value,
                    DirectoryCode = model.DirectoryCode,
                    DirectoryName = model.DirectoryName,
                    Description = model.Description,
                    Status = model.Status
                }
            };
        }

        public DeleteResponse Update(UpdateRequest<DirectoryModel> request)
        {
            if (request.Entity == null)
                throw new Exception("Entity boş geçilemez");


            //OK::NOT:: aşağıdaki şekilde WebUserManager a erişebilirim ama katmanlı yapı adına bu işlemi servis üzerinden yapacağım.
            //new Membership.Business.Manager.WebUserManager().LoggedUser(System.Web.HttpContext.Current.User.Identity.Name);

            var loggedUser = SecurityHelper.LoggerUserItem;

            //new DirectoryManager(new Business.Model.WebUser()
            //{
            //    Id = loggedUser.Id.Value,
            //}).Delete(request.EntityId.Value);


            new DirectoryManager(new Business.Model.WebUser()
            {
                Id = loggedUser.Id.Value,
            }).Update(new Business.Model.Directory()
            {
                DirectoryCode = request.Entity.DirectoryCode,
                DirectoryName = request.Entity.DirectoryName,
                Description = request.Entity.Description,
                Id = request.Entity.Id,
            });



            return new DeleteResponse();
        }

        public CreateResponse Create(CreateRequest<DirectoryModel> request)
        {
            if (request.Entity == null)
                throw new Exception("Entity boş geçilemez");


            if (String.IsNullOrEmpty(request.Entity.DirectoryCode.Trim()))
                throw new Exception("DirectoryCode boş olamaz");

            if (String.IsNullOrEmpty(request.Entity.DirectoryCode.Trim()))
                throw new Exception("DirectoryCode boş olamaz");


            //OK::NOT:: aşağıdaki şekilde WebUserManager a erişebilirim ama katmanlı yapı adına bu işlemi servis üzerinden yapacağım.
            //new Membership.Business.Manager.WebUserManager().LoggedUser(System.Web.HttpContext.Current.User.Identity.Name);

            var loggedUser = SecurityHelper.LoggerUserItem;

            //new DirectoryManager(new Business.Model.WebUser()
            //{
            //    Id = loggedUser.Id.Value,
            //}).Delete(request.EntityId.Value);



            var entityId = new DirectoryManager(new Business.Model.WebUser()
               {
                   Id = loggedUser.Id.Value,
               }).Create(new Business.Model.Directory()
               {
                   DirectoryCode = request.Entity.DirectoryCode,
                   DirectoryName = request.Entity.DirectoryName,
                   Description = request.Entity.Description,
                   Id = request.Entity.Id,
               });



            return new CreateResponse() { EntityId = entityId };
        }
    }
}