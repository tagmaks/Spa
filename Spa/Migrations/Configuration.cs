using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Spa.Data.Migrations
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
        }
#endif 
    }
}
