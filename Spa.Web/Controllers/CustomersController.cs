using System.Data.Entity.Infrastructure;
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
    public class CustomersController : ODataController
    {
        private readonly SpaRepository<Customer> _ctx = new SpaRepository<Customer>();

        [EnableQuery(PageSize = 10)]
        public IHttpActionResult Get()
        {
            var customers = _ctx.GetAll();
            if (customers == null)
            {
                NotFound();
            }
            return Ok(customers);
        }

        [EnableQuery]
        [HttpCacheControlPolicy(true, 10)]
        public IHttpActionResult Get([FromODataUri] int key)
        {
            var customer = _ctx.Get(c => c.Id == key);
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
                return BadRequest(ModelState);
            }
            if (customer == null)
            {
                return BadRequest();
            }
            var postTask = _ctx.PostAsync(customer);
            await postTask;
            if (!postTask.IsCompleted)
            {
                return InternalServerError();
            }
            return Created(customer);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Customer> patch, ODataQueryOptions<Customer> options)
        {
            //Check if properties name are valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (patch == null)
            {
                return BadRequest("Entity fields cannot be empty");
            }

            var customer = await _ctx.GetAsync(key);
            if (customer == null)
            {
                return NotFound();
            }

            if (options.IfMatch != null && options.IfMatch.ApplyTo(_ctx.Get(c => c.Id == key).Queryable) == null)
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(customer);
            Validate(customer);

            //Check if filters of properties are valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Customer update, ODataQueryOptions<Customer> options)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            //Check if any properies have changed by ETag header (IfMatch)
            if (options.IfMatch != null && options.IfMatch.ApplyTo(_ctx.Get(c => c.Id == key).Queryable) == null)
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }
            try
            {
                await _ctx.PutAsync(update);
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
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var customer = await _ctx.GetAsync(key);
            if (customer == null)
            {
                return NotFound();
            }
            await _ctx.DeleteAsync(customer);
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            //_ctx._db.Dispose();
            base.Dispose(disposing);
        }
    }
}