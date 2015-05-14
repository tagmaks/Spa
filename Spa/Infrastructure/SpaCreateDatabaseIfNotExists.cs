using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Spa.Data.Infrastructure
{
    class SpaCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            new SpaDataSeeder(context).Seed();
            base.Seed(context);
        }

    }
}
