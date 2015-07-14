using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using GenericLibsBase.Core;
using GenericServices;
using Microsoft.AspNet.Identity.EntityFramework;
using Spa.Data.Entities;
using Spa.Data.Mappers;

namespace Spa.Data.Infrastructure
{
    public class ApplicationDbContext :
        IdentityDbContext<AppUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>,
        IGenericServicesDbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new SpaCreateDatabaseIfNotExists());
            //Database.SetInitializer<ApplicationDbContext>(new SpaDropCreateDatabaseAlways());
        }

        ///// <summary>
        ///// This has been overridden to handle:
        ///// a) Updating of modified items (see p194 in DbContext book)
        ///// </summary>
        ///// <returns></returns>
        //public override int SaveChanges()
        //{
        //    HandleChangeTracking();
        //    return base.SaveChanges();
        //}

        ///// <summary>
        ///// Same for async
        ///// </summary>
        ///// <returns></returns>
        //public override Task<int> SaveChangesAsync()
        //{
        //    HandleChangeTracking();
        //    return base.SaveChangesAsync();
        //}

        private void HandleChangeTracking()
        {
            //Debug.WriteLine("----------------------------------------------");
            //foreach (var entity in ChangeTracker.Entries()
            //.Where(
            //    e =>
            //    e.State == EntityState.Added || e.State == EntityState.Modified))
            //{
            //    Debug.WriteLine("Entry {0}, state {1}", entity.Entity, entity.State);
            //}       

            foreach (var entity in ChangeTracker.Entries()
                                                .Where(
                                                    e =>
                                                    e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                //UpdateTrackedEntity(entity);
            }

        }

        /// <summary>
        /// Looks at everything that has changed and applies any further action if required.
        /// </summary>
        /// <param name="entityEntry"></param>
        /// <returns></returns>
        //private static void UpdateTrackedEntity(DbEntityEntry entityEntry)
        //{
        //    var trackUpdateClass = entityEntry.Entity as IModifiedEntity;
        //    if (trackUpdateClass == null) return;
        //    trackUpdateClass.ModifiedDate = DateTime.UtcNow;
        //    if (entityEntry.State == EntityState.Added)
        //        trackUpdateClass.rowguid = Guid.NewGuid();
        //}

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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMapper());
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