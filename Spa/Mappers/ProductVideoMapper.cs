using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Data.Mappers
{
    public class ProductVideoMapper: EntityTypeConfiguration<ProductVideo>
    {
        public ProductVideoMapper()
        {
            this.ToTable("ProductVideo");

            this.HasKey(pv => pv.ProductVideoId);
            this.Property(pv => pv.ProductVideoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(pv => pv.ProductVideoId).IsRequired();

            this.Property(pv => pv.Name).IsRequired();
            this.Property(pv => pv.Name).HasMaxLength(30);

            this.Property(pv => pv.Description).IsRequired();
            this.Property(pv => pv.Description).HasMaxLength(50);

            this.HasRequired(pv => pv.Product).WithMany(p => p.ProductVideos).Map(p => p.MapKey("ProductId"));
        }
    }
}