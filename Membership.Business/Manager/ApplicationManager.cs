
using Membership.Business.Model;
using Membership.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Business.Manager
{

    public abstract class BaseManager
    {

        private WebUser currentUser;

        public BaseManager()
        {

        }

        public WebUser CurrentUser
        {
            get
            {
                if (currentUser == null)
                    throw new System.Exception("Tanımlı bir CurrentUser yok");

                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }
    }

    public class ApplicationManager : BaseManager
    {

        public ApplicationManager()
        {
        }

        public ApplicationManager(WebUser User)
        {
            this.CurrentUser = User;
        }

        public List<Application> List()
        {
            var entities = new ApplicationRepository().GetObjectsByParameters(p => (p.IsDeleted != null && p.IsDeleted.Value == 0))
                .Select(entity => new Application()
                {
                    Id = entity.Id,
                    ApplicationCode = entity.ApplicationCode,
                    ApplicationName = entity.ApplicationName,
                    Description = entity.Description,
                    Status = entity.Status
                }).ToList();
            //    .ToList();

            //p.IsDeleted == 0 & 

            if (entities == null || entities.Count == 0)
                return null;
            else
                return entities;
        }

        public bool Delete(int ApplicationId)
        {
            try
            {
                var entity = new ApplicationRepository().GetById(ApplicationId);

                if (entity == null || entity.IsDeleted == 1)
                    return true;
                else
                {
                    entity.DeletedBy = this.CurrentUser.Id;
                    entity.IsDeleted = 1;

                    new ApplicationRepository()
                        .Update(entity);
                }

                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Application Retrieve(int ApplicationId)
        {
            try
            {
                var entity = new ApplicationRepository().GetById(ApplicationId);

                if (entity == null || entity.IsDeleted == 1)
                    throw new System.Exception("RecordNotFound");


                return new Application()
                {
                    Id = entity.Id,
                    ApplicationCode = entity.ApplicationCode,
                    ApplicationName = entity.ApplicationName,
                    Description = entity.Description,
                    Status = entity.Status
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Update(Application Model)
        {
            try
            {
                if (Model == null)
                    throw new System.Exception("Model is null");

                if (Model.Id == null)
                    throw new System.Exception("EntityId is null");

                var entity = new ApplicationRepository().GetById(Model.Id.Value);

                entity.ApplicationCode = Model.ApplicationCode;
                entity.ApplicationName = Model.ApplicationName;
                entity.Description = Model.Description;

                entity.UpdatedBy = this.CurrentUser.Id;
                entity.UpdateTime = System.DateTime.Now;

                new ApplicationRepository().Update(entity);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}