using Spa.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Spa.Data.Mappers
{
    public class AppUserMapper: EntityTypeConfiguration<AppUser>
    {
        public AppUserMapper()
        {
            this.Property(ap => ap.Id).HasColumnName("UserID");
        }
    }
}