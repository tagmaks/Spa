using Spa.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Mappers
{
    public class RatioMapper: EntityTypeConfiguration<Ratio>
    {
        public RatioMapper()
        {
            this.ToTable("Ratios");

            this.HasKey(r => r.RatioId);
            this.Property(r => r.RatioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(r => r.RatioId).IsRequired();

            this.Property(r => r.ProductRatio).IsRequired();

            this.Property(r => r.AddDate).IsOptional();
            this.Property(r => r.AddDate).HasColumnType("smalldatetype");

            this.HasRequired(r => r.Product).WithMany().Map(p => p.MapKey("ProductId"));
            this.HasRequired(r => r.Customer).WithMany().Map(p => p.MapKey("CustomerId"));
        }
    }
}