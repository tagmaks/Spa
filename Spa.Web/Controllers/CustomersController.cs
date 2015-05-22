using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Spa.Web.Controllers
{
    public class CustomersController : ODataController
    {
        readonly SpaRepository _ctx = new SpaRepository();
        
        [EnableQuery(PageSize = 10)]
        public async Task<IHttpActionResult> Get()
        {
            var customers = await _ctx.GetCustomers().ToListAsync();
            var cust = _ctx.GetCustomers().AsEnumerable();
            if (customers.Count != 0)
            {
                return Ok(customers);
            }
            return NotFound();
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var customer = await _ctx.GetCustomer(key).FirstOrDefaultAsync();
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }


    }
}
