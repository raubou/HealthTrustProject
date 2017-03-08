using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace HealthTrustProject
{
    public class HealthTrustContext : DbContext
    {
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Contacts> Contracts { get; set; }
        public DbSet<Accounts> Accounts { get; set; }

        public HealthTrustContext() : base(AppSettings.HealthTrustConnection)
        {
            if(AppSettings.migrateDB)
                Database.SetInitializer<HealthTrustContext>(new CreateDatabaseIfNotExists<HealthTrustContext>());
            else
                Database.SetInitializer<HealthTrustContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Contacts>()
            // .HasMany<Addresses>(u => u.Address)
            // .WithOptional(p => p.Contact).Map(m => m.MapKey("ContactId"));
            //one-to-many 
            //modelBuilder.Entity<Addresses>()
            //            .HasRequired<Contacts>(s => s.Contact) // Student entity requires Standard 
            //            .WithMany(s => s.Address);

            //modelBuilder.Entity<Addresses>().HasRequired<Contacts>(p => p.Contact).WithMany(s => s.Address).HasForeignKey(p => p.ContractId);
        }

        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            return base.ShouldValidateEntity(entityEntry);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }
    }
}