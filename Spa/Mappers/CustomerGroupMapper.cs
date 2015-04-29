using Spa.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Mappers
{
    public class CustomerGroupMapper: EntityTypeConfiguration<CustomerGroup>
    {
        public CustomerGroupMapper()
        {
            this.ToTable("CustomerGroups");

            this.HasKey(cg => cg.CustomerGroupId);
            this.Property(cg => cg.CustomerGroupId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(cg => cg.CustomerGroupId).IsRequired();

            this.Property(cg => cg.GroupName).IsRequired();
            this.Property(cg => cg.GroupName).HasMaxLength(30);

            this.Property(cg => cg.Discount).IsOptional();

            this.HasRequired(cg => cg.CustomerGroupOfferList).WithMany().Map(of => of.MapKey("OfferListId"));
        }
    }
}