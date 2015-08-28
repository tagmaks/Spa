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
using Spa.Data.Dtos;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;

namespace Spa.Web.Controllers
{
    public class CustomerGroupsController : ODataController
    {
        private readonly ISpaRepository<CustomerGroup, CustomerGroupDto, CustomerGroupDtoAsync> _repo;

        // GET: odata/CustomerGroups
        public CustomerGroupsController(ISpaRepository<CustomerGroup, CustomerGroupDto, CustomerGroupDtoAsync> repo)
        {
            _repo = repo;
        }
        [EnableQuery(PageSize = 10, AllowedQueryOptions = AllowedQueryOptions.All)]
        //[HttpCacheControlPolicy(true, 100)]
        public IHttpActionResult Get()
        {
            var customerGroups = _repo.GetAllDto();
            if (customerGroups == null)
            {
                NotFound();
            }

            return Ok(customerGroups);
        }

        // GET: odata/CustomerGroups(5)
        [EnableQuery]
        public IHttpActionResult Get([FromODataUri] int key)
        {
            var customer = _repo.Get(key);
            if (customer == null)
            {
                NotFound();
            }
            return Ok(customer);
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

            var customer = await _repo.GetAsyncOld(key);
            if (customer == null)
            {
                return NotFound();
            }

            delta.Patch(customer);

            try
            {
                await _repo.PatchAsyncOld();
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
            var postTask = _repo.PostAsyncOld(customerGroup);
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

            var customerGroup = await _repo.GetAsyncOld(key);
            if (customerGroup == null)
            {
                return NotFound();
            }

            delta.Patch(customerGroup);

            try
            {
                await _repo.PatchAsyncOld();
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