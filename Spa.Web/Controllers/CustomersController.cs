using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using CacheCow.Server.CacheControlPolicy;
using GenericServices;
using GenericServices.Services;
using GenericServices.Services.Concrete;
using Spa.Data.Dtos;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using Spa.Web.Infrastructure;

namespace Spa.Web.Controllers
{
    public class CustomersController : ODataController
    {
        private readonly ISpaRepository<Customer, CustomerDto, CustomerDtoAsync> _repo;

        public CustomersController(ISpaRepository<Customer, CustomerDto, CustomerDtoAsync> repo)
        {
            _repo = repo;
        }

        [EnableQuery(PageSize = 10)]
        public IHttpActionResult Get()
        {
            var customers = _repo.GetAllDto();
            if (customers == null)
            {
                NotFound();
            }
            return Ok(customers);
        }

        [EnableQuery]
        public IHttpActionResult Get([FromODataUri] int key)
        {
            var customer = _repo.Get2(key);
            if (customer == null)
            {
                NotFound();
            }
            return Ok(customer);
        }

        //TODO fix this method
        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            var response = await _repo.PostAsync2(customer);
            if (response.IsValid)
            {
                return Created(customer);
            }
            response.CopyErrorsToModelState(ModelState);
            return BadRequest(ModelState);
        }

        //TODO fix this method
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Customer> patch)
        {
            //Check if properties name are valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (patch == null)
            {
                return BadRequest();
                //return BadRequest("Entity fields cannot be empty");
            }

            var entity = await _repo.GetAsync2(key);
            var customer = entity.Result;
            if (customer == null)
            {
                return NotFound();
            }

            patch.Patch(customer);
            //Validate(customer);

            ////Check if filters of properties are valid
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var response = await _repo.PatchAsync2(customer);
            if (response.IsValid)
            {
                return Updated(customer);
            }
            response.CopyErrorsToModelState(ModelState);
            return BadRequest(ModelState);
            //try
            //{
            //    await _repo.PatchAsync();
            //}
            // Exception occures if entity was changed since the last loading
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    if (!_repo.EntityExists(key))
            //    {
            //        return NotFound();
            //    }
            //    return InternalServerError(ex);
            //}
        }

        //TODO fix this method
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
            if (options.IfMatch != null && options.IfMatch.ApplyTo(_repo.Get(c => c.Id == key).Queryable) == null)
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }
            try
            {
                await _repo.PutAsync(update);
            }
            // Exception occures if entity was changed since the last loading
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_repo.EntityExists(key))
                {
                    return NotFound();
                }
                return InternalServerError(ex);
            }
            return Updated(update);
        }

        //TODO fix this method
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var customer = await _repo.GetAsync(key);
            if (customer == null)
            {
                return NotFound();
            }
            await _repo.DeleteAsync(customer);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    //_repo._db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}