
using Membership.Business.Model;
using Membership.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Business.Manager
{
    public class DirectoryManager : BaseManager
    {

        public DirectoryManager()
        {
        }

        public DirectoryManager(WebUser User)
        {
            this.CurrentUser = User;
        }

        public List<Directory> List()
        {
            var entities = new DirectoryRepository().GetObjectsByParameters(p => ( p.IsDeleted == null || (p.IsDeleted != null && p.IsDeleted.Value == 0)))
                .Select(entity => new Directory()
                {
                    Id = entity.Id,
                    DirectoryCode = entity.DirectoryCode,
                    DirectoryName = entity.DirectoryName,
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

        public bool Delete(int DirectoryId)
        {
            try
            {
                var entity = new DirectoryRepository().GetById(DirectoryId);

                if (entity == null || entity.IsDeleted == 1)
                    return true;
                else
                {
                    entity.DeletedBy = this.CurrentUser.Id;
                    entity.IsDeleted = 1;

                    new DirectoryRepository()
                        .Update(entity);
                }

                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Directory Retrieve(int DirectoryId)
        {
            try
            {
                var entity = new DirectoryRepository().GetById(DirectoryId);

                if (entity == null || entity.IsDeleted == 1)
                    throw new System.Exception("RecordNotFound");


                return new Directory()
                {
                    Id = entity.Id,
                    DirectoryCode = entity.DirectoryCode,
                    DirectoryName = entity.DirectoryName,
                    Description = entity.Description,
                    Status = entity.Status
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Update(Directory Model)
        {
            try
            {
                if (Model == null)
                    throw new System.Exception("Model is null");

                if (Model.Id == null)
                    throw new System.Exception("EntityId is null");

                var entity = new DirectoryRepository().GetById(Model.Id.Value);

                entity.DirectoryCode = Model.DirectoryCode;
                entity.DirectoryName = Model.DirectoryName;
                entity.Description = Model.Description;

                entity.UpdatedBy = this.CurrentUser.Id;
                entity.UpdateTime = System.DateTime.Now;

                new DirectoryRepository().Update(entity);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public int? Create(Directory Model)
        {
            try
            {
                if (Model == null)
                    throw new Exception("Entity boş olamaz");


                var entity = new Core.Domain.Directory.Directory()
                {
                    DirectoryCode = Model.DirectoryCode,
                    DirectoryName = Model.DirectoryName,
                    Description =Model.Description,
                    CreatedBy = CurrentUser.Id,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0,
                    Status = 0
                };

                new DirectoryRepository().Add(entity);

                return entity.Id;

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}