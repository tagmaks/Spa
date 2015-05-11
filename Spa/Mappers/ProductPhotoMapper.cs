using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Data.Mappers
{
    public class ProductPhotoMapper: EntityTypeConfiguration<ProductPhoto>
    {
        public ProductPhotoMapper()
        {
            this.ToTable("ProductPhotos");

            this.HasKey(pp => pp.ProductPhotoId);
            this.Property(pp => pp.ProductPhotoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(pp => pp.ProductPhotoId).IsRequired();

            this.Property(pp => pp.PhotoName).IsRequired();
            this.Property(pp => pp.PhotoName).HasMaxLength(30);

            this.Property(pp => pp.Description).IsRequired();
            this.Property(pp => pp.Description).HasMaxLength(50);

            this.Property(pp => pp.Main).IsOptional();

            this.Property(pp => pp.OriginName).IsRequired();
            this.Property(pp => pp.OriginName).HasMaxLength(50);

            this.Property(pp => pp.ModifiedDate).IsOptional();
            this.Property(pp => pp.ModifiedDate).HasColumnType("smalldatetime");

            this.HasRequired(pp => pp.Product).WithMany(p => p.ProductPhotos).Map(p => p.MapKey("ProductId"));
        }
    }
}