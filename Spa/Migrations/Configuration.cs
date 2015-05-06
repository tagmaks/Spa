using Spa.Entities;
using Spa.Infrastructure;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Spa.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

#if DEBUG
        protected override void Seed(ApplicationDbContext context)
        {
            new SpaDataSeeder(context).Seed();

            //var offerList = new OfferList()
            //{
            //    Name = "SpringMelody",
            //    StartDate = DateTime.Now,
            //    EndDate = DateTime.Now
            //};
            //context.OfferLists.Add(offerList);

            //var group = new CustomerGroup()
            //    {
            //        GroupName = "Default",
            //        Discount = 0,
            //        OfferList = offerList
            //    };
            //context.CustomerGroups.Add(group);

            //var user = new Customer()
            //        {
            //            FirstName = "Maks",
            //            LastName = "Ivanov",
            //            RegistrationDate = DateTime.Now,
            //            UserName = "maximus",
            //            Email = "maximus@gmail.com",
            //        };
            //context.Users.Add(user);

            //context.SaveChanges();
        }
#endif
    }
}
