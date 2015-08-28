using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
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

        //TODO fix for Dto entities
        [EnableQuery(PageSize = 10)]
        public IHttpActionResult Get()
        {
            var response = _repo.GetAllDto();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        //TODO fix for Dto entities
        [EnableQuery]
        public IHttpActionResult Get([FromODataUri] int key)
        {
            var response = _repo.GetDto(key);
            if (response.IsValid)
            {
                return Ok(response.Result);
            }
            return NotFound();
        }

        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            var response = await _repo.PostAsync(customer);
            if (response.IsValid)
            {
                return Created(customer);
            }
            response.CopyErrorsToModelState(ModelState);
            return BadRequest(ModelState);
        }

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
            }

            var entity = await _repo.GetAsync(key);
            var customer = entity.Result;
            if (customer == null)
            {
                return NotFound();
            }

            patch.Patch(customer);

            var response = await _repo.PatchAsync(customer);
            if (response.IsValid)
            {
                return Updated(customer);
            }
            response.CopyErrorsToModelState(ModelState);
            return BadRequest(ModelState);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Customer update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }

            var response = await _repo.PatchAsync(update);
            if (response.IsValid)
            {
                return Updated(update);
            }
            response.CopyErrorsToModelState(ModelState);
            return BadRequest(ModelState);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            //var customer = await _repo.GetAsync(key);
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            var response = await _repo.DeleteAsync(key);
            if (response.IsValid)
            {
                return Ok();
            }
            response.CopyErrorsToModelState(ModelState);
            return BadRequest(ModelState);
        }
    }
}