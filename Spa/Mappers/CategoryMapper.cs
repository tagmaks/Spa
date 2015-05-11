using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Data.Mappers
{
    public class CategoryMapper: EntityTypeConfiguration<Category>
    {
        public CategoryMapper()
        {
            this.ToTable("Categories");

            this.HasKey(c => c.CategoryId);
            this.Property(c => c.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CategoryId).IsRequired();

            this.Property(c => c.Name).IsRequired();
            this.Property(c => c.Name).HasMaxLength(30);

            this.Property(c => c.Description).IsOptional();
            this.Property(c => c.Description).HasMaxLength(100);

            this.Property(c => c.Picture).IsOptional();
            this.Property(c => c.Picture).HasMaxLength(100);

            this.Property(c => c.MiniPicture).IsOptional();
            this.Property(c => c.MiniPicture).HasMaxLength(100);

            this.Property(c => c.Enabled).IsOptional();
        }
    }
}