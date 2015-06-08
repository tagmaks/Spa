using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using CacheCow.Server.CacheControlPolicy;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;

namespace Spa.Web.Controllers
{
    //[HttpCacheControlPolicy(true, 100)]
    public class CustomerGroupsController : ODataController
    {
        //private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private readonly SpaRepository<CustomerGroup> _ctx = new SpaRepository<CustomerGroup>();
        // GET: odata/CustomerGroups

        [EnableQuery(PageSize = 10, AllowedQueryOptions = AllowedQueryOptions.All)]
        //[HttpCacheControlPolicy(true, 100)]
        public IHttpActionResult GetCustomerGroups(ODataQueryOptions<CustomerGroup> options)
        {
            //// validate the query.
            //try
            //{
            //    queryOptions.Validate(_validationSettings);
            //}
            //catch (ODataException ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            var customerGroups = _ctx.GetAll();
            if (customerGroups == null)
            {
                NotFound();
            }
            //if (Request.Headers.IfNoneMatch != null && options.IfNoneMatch.ApplyTo(customerGroups) == null)
            //{
            //    return StatusCode(HttpStatusCode.NotModified);
            //}
            //if (options.IfNoneMatch != null && options.IfNoneMatch.ApplyTo(customerGroups) == null)
            //{
            //    return StatusCode(HttpStatusCode.PreconditionFailed);
            //}

            return Ok(customerGroups);
        }

        // GET: odata/CustomerGroups(5)
        [EnableQuery]
        public IHttpActionResult GetCustomerGroup([FromODataUri] int key)
        {
            //// validate the query.
            //try
            //{
            //    queryOptions.Validate(_validationSettings);
            //}
            //catch (ODataException ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            var customerGroup = _ctx.Get(c => c.CustomerGroupId == key);
            if (customerGroup == null)
            {
                NotFound();
            }
            return Ok(customerGroup);
        }

        // PUT: odata/CustomerGroups(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CustomerGroup> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (delta == null)
            {
                return BadRequest("Entity fields cannot be empty");
            }

            Validate(delta.GetEntity());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _ctx.GetAsync(key);
            if (customer == null)
            {
                return NotFound();
            }

            delta.Patch(customer);

            try
            {
                await _ctx.PatchAsync();
            }
            // Exception occures if entity was changed since the last loading
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_ctx.EntityExists(key))
                {
                    return NotFound();
                }
                return InternalServerError(ex);
            }
            return Updated(customer);
        }

        // POST: odata/CustomerGroups
        public async Task<IHttpActionResult> Post(CustomerGroup customerGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (customerGroup == null)
            {
                return BadRequest();
            }
            var postTask = _ctx.PostAsync(customerGroup);
            await postTask;
            if (!postTask.IsCompleted)
            {
                return InternalServerError();
            }
            return Created(customerGroup);
        }

        // PATCH: odata/CustomerGroups(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CustomerGroup> delta)
        {
            //Check if properties name are valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (delta == null)
            {
                return BadRequest("Entity fields cannot be empty");
            }

            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerGroup = await _ctx.GetAsync(key);
            if (customerGroup == null)
            {
                return NotFound();
            }

            delta.Patch(customerGroup);

            try
            {
                await _ctx.PatchAsync();
            }
                // Exception occures if entity was changed since the last loading
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_ctx.EntityExists(key))
                {
                    return NotFound();
                }
                return InternalServerError(ex);
            }

            return Updated(customerGroup);
        }

        // DELETE: odata/CustomerGroups(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}