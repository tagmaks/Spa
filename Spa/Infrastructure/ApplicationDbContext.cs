using Microsoft.AspNet.Identity.EntityFramework;
using Spa.Data.Entities;
using Spa.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Spa.Data.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext()
            : base("name=ApplicationConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            Database.SetInitializer<ApplicationDbContext>(new SpaDropCreateDatabaseAlways());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //public DbSet<AppUser> AppUsers { get; set; }
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
            //modelBuilder.Configurations.Add(new AppUserMapper());
            //modelBuilder.Configurations.Add(new CategoryMapper());
            //modelBuilder.Configurations.Add(new CustomerMapper());
            //modelBuilder.Configurations.Add(new CustomerGroupMapper());
            //modelBuilder.Configurations.Add(new OfferMapper());
            //modelBuilder.Configurations.Add(new OfferListMapper());
            //modelBuilder.Configurations.Add(new OrderMapper());
            //modelBuilder.Configurations.Add(new OrderItemMapper());
            //modelBuilder.Configurations.Add(new ProductMapper());
            //modelBuilder.Configurations.Add(new ProductPhotoMapper());
            //modelBuilder.Configurations.Add(new ProductVideoMapper());
            //modelBuilder.Configurations.Add(new RatioMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}