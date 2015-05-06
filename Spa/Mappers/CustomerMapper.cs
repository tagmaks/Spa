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
            this.Property(c => c.DateOfBirth).IsOptional();
            this.Property(c => c.DateOfBirth).HasColumnType("smalldatetime");

            this.Property(c => c.SubscribedNews).IsOptional();      

            this.HasRequired(c => c.CustomerGroup).WithMany(cg => cg.Customers).Map(cg => cg.MapKey("CustomerGroupId"));
        }
    }
}