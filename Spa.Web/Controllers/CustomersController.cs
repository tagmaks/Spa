using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace Spa.Web.Controllers
{
    public class CustomersController : EntitySetController<Customer, int>
    {
        SpaRepository ctx = new SpaRepository();
        
        [Queryable]
        public override IQueryable<Customer> Get()
        {
            var x = ctx.GetAllCustomers();
            return x;
        }

        protected override Customer GetEntityByKey(int key)
        {
            var x = ctx.GetCustomer(key);
            return x;
        }
    }
}
