using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Data.Mappers
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
            this.Property(r => r.AddDate).HasColumnType("smalldatetime");

            this.HasRequired(r => r.Product).WithMany(p => p.Ratios).Map(p => p.MapKey("ProductId"));
            this.HasRequired(r => r.Customer).WithMany(c => c.Ratios).Map(p => p.MapKey("CustomerId"));
        }
    }
}