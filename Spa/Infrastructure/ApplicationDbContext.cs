using Microsoft.AspNet.Identity.EntityFramework;
using Spa.Entities;
using Spa.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Spa.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //this.Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=Spa";
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
            //Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Spa.Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferList> OfferLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<ProductVideo> ProductVideos { get; set; }
        public DbSet<Ratio> Ratios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMapper());
            modelBuilder.Configurations.Add(new CustomerMapper());
            modelBuilder.Configurations.Add(new CustomerGroupMapper());
            modelBuilder.Configurations.Add(new OfferMapper());
            modelBuilder.Configurations.Add(new OfferListMapper());
            modelBuilder.Configurations.Add(new OrderMapper());
            modelBuilder.Configurations.Add(new OrderItemMapper());
            modelBuilder.Configurations.Add(new ProductMapper());
            modelBuilder.Configurations.Add(new ProductPhotoMapper());
            modelBuilder.Configurations.Add(new ProductVideoMapper());
            modelBuilder.Configurations.Add(new RatioMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}