using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace Spa.Web.Controllers
{
    public class CustomerGroupsController : EntitySetController<CustomerGroup, int>
    {
        SpaRepository ctx = new SpaRepository();

        public override IQueryable<CustomerGroup> Get()
        {
            var x = ctx.GetAllCustomerGroups();
            return x;
        }

        protected override CustomerGroup GetEntityByKey(int key)
        {
            var x = ctx.GetCustomerGroup(key);
            return x;
        }
    }
}
