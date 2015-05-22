using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace Spa.Web.Controllers
{
    public class CustomerGroupsController : ODataController
    {
        readonly SpaRepository _ctx = new SpaRepository();

        [EnableQuery(PageSize = 10)]
        public IHttpActionResult Get()
        {
            IQueryable<CustomerGroup> customerGroups = _ctx.GetAllCustomerGroups();
            if (customerGroups != null)
            {
                return Ok(customerGroups);
            }
            return NotFound();
        }

        public IHttpActionResult Get([FromODataUri] int key)
        {
            CustomerGroup customerGroup = _ctx.GetCustomerGroup(key);
            if (customerGroup != null)
            {
                return Ok(customerGroup);
            }
            return NotFound();
        }
    }
}
