using Spa.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Mappers
{
    public class CustomerMapper: EntityTypeConfiguration<Customer>
    {
        public CustomerMapper()
        {
            this.ToTable("Customers");

            this.HasKey(c => c.CustomerId);
            this.Property(c => c.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CustomerId).IsRequired();

            this.Property(c => c.DateOfBirth).IsOptional();
            this.Property(c => c.DateOfBirth).HasColumnType("smalldatetime");

            this.Property(c => c.SubscribedNews).IsOptional();

            this.HasRequired(c => c.ApplicationUser).WithMany().Map(au => au.MapKey("ApplicationUserId"));
            this.HasRequired(c => c.CustomerGroup).WithMany().Map(cg => cg.MapKey("CustomerGroupId"));
        }
    }
}