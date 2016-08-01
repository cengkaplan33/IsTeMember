using Membership.Core.Domain;
using Membership.Core.Domain.Account;
using Membership.Core.Domain.Application;
using Membership.Core.Domain.Web;
using System;
using System.Data.Entity;
using System.Linq;

namespace Membership.Data
{
    public class DomainEfModel : DbContext
    {
        // Your context has been configured to use a 'BenimKredimModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BenimKredim.EntityFramework.BenimKredimModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BenimKredimModel' 
        // connection string in the application configuration file.
        public DomainEfModel()
            : base("name=MembershipDefault")
        {

            Database.SetInitializer<DomainEfModel>(null);
        }

        ////OK::NOT:: oluþmamýþ tablolarý ömap etmek için kullanýlýr
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<WebUser>().ToTable("WebUser");
        //}


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        #region EntityList

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountAddress> AccountAddresses { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<WebUserIp> WebUserIps { get; set; }

        #endregion
    }
}