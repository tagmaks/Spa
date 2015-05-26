using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using HibernatingRhinos.Profiler.Appender.Messages;

namespace Spa.Web.Controllers
{
    public class CustomersController : ODataController
    {
        readonly SpaRepository _ctx = new SpaRepository();
        
        //[EnableQuery]
        //public IQueryable<Customer> Get()
        //{
        //    var customers = _ctx.GetCustomers();
        //    if (customers == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return customers;
        //}

        [EnableQuery(PageSize = 10)]
        public IHttpActionResult Get()
        {
            var customers = _ctx.GetCustomers();
            if (customers == null)
            {
                NotFound();
            }
            return Ok(customers);
        }

        [EnableQuery]
        public IHttpActionResult Get([FromODataUri] int key)
        {
            var customer = _ctx.GetCustomer(key);
            if (customer == null)
            {
                NotFound();
            }
            return Ok(customer);
        }

        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var postCustomerTask = _ctx.PostCustomerAsync(customer);
            await postCustomerTask;
            if (!postCustomerTask.IsCompleted)
            {
                StatusCode(HttpStatusCode.InternalServerError);
            }
            return Created(customer);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Customer> customer)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var entity = await _ctx.GetCustomerAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            customer.Patch(entity);
            
            try
            {
                
            }
        } 

        //[EnableQuery]
        //public SingleResult<Customer> Get([FromODataUri] int key)
        //{
        //    var customer = _ctx.GetCustomer(key);
        //    if (customer == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return customer;
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
