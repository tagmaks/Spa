using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Spa.Data.Infrastructure;

namespace Spa.Data.Mappers
{
    public class UserMapper: EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            this.Property(ap => ap.Id).HasColumnName("UserID");

            this.Property(c => c.DateOfBirth).IsOptional();
            this.Property(c => c.DateOfBirth).HasColumnType("smalldatetime");

            this.Property(c => c.SubscribedNews).IsOptional();

            this.HasOptional(c => c.CustomerGroup).WithMany(cg => cg.Customers).Map(cg => cg.MapKey("CustomerGroupId"));
        }
    }
}