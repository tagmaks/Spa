using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Spa.Data.Infrastructure
{
    public class SpaDropCreateDatabaseAlways : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            new SpaDataSeeder(context).Seed();
            base.Seed(context);
        }
    }
}