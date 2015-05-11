using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Data.Mappers
{
    public class ProductMapper : EntityTypeConfiguration<Product>
    {
        public ProductMapper()
        {
            this.ToTable("Products", "catalog");

            this.HasKey(p => p.ProductId);
            this.Property(p => p.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.ProductId).IsRequired();

            this.Property(p => p.Name).IsRequired();
            this.Property(p => p.Name).HasMaxLength(30);

            this.Property(p => p.Price).IsRequired();

            this.Property(p => p.Ratio).IsOptional();

            this.Property(p => p.Discount).IsOptional();

            this.Property(p => p.Weight).IsOptional();

            this.Property(p => p.Size).IsOptional();

            this.Property(p => p.IsFreeShipping).IsOptional();

            this.Property(p => p.ItemSold).IsOptional();

            this.Property(p => p.Enabled).IsOptional();

            this.Property(p => p.ShortDescription).IsRequired();

            this.Property(p => p.Description).IsRequired();

            this.Property(p => p.DateAdded).IsOptional();
            this.Property(p => p.DateAdded).HasColumnType("smalldatetime");

            this.Property(p => p.DateModified).IsOptional();
            this.Property(p => p.DateModified).HasColumnType("smalldatetime");

            this.Property(p => p.Recomended).IsOptional();

            this.Property(p => p.New).IsOptional();

            this.Property(p => p.OnSale).IsOptional();

            this.HasMany(p => p.Categories).WithMany(c => c.Products).Map(m =>
                {
                    m.ToTable("ProductCategories");
                    m.MapLeftKey("ProductId");
                    m.MapRightKey("CategoryId");
                });
        }
    }
}