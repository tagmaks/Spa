namespace Spa.Migrations
{
    using Spa.Infrastructure;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

#if DEBUG
        //protected override void Seed(ApplicationDbContext)
        //{
            
        //}
#endif
    }
}
