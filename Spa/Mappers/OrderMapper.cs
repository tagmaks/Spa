using Spa.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Mappers
{
    public class OrderMapper: EntityTypeConfiguration<Order>
    {
        public OrderMapper()
        {
            this.ToTable("Orders");

            this.HasKey(o => o.OrderId);
            this.Property(o => o.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(o => o.OrderId).IsRequired();

            this.Property(o => o.OrderDiscount).IsOptional();

            this.Property(o => o.OrderDate).IsOptional();
            this.Property(o => o.OrderDate).HasColumnType("smalldatetype");

            this.Property(o => o.PaymentDate).IsOptional();
            this.Property(o => o.PaymentDate).HasColumnType("smalldatetype");

            this.Property(o => o.CustomerComment).IsOptional();
            this.Property(o => o.CustomerComment).HasMaxLength(255);

            this.Property(o => o.AdminOrderComment).IsOptional();
            this.Property(o => o.AdminOrderComment).HasMaxLength(255);

            this.Property(o => o.ShippingCost).IsRequired();

            this.HasRequired(o => o.Customer).WithMany().Map(c => c.MapKey("CustomerId"));
        }
    }
}