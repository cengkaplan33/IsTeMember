
using Membership.Business.Model;
using Membership.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Business.Manager
{
    public class ApplicationManager
    {

        public ApplicationManager()
        {
        }

        public List<Application> List()
        {
            var entities = new ApplicationRepository().GetObjectsByParameters(p => p.Status == 1)
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

    }
}