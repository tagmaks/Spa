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
    public class UsersController : ODataController
    {
        private readonly ISpaRepository<User, UserDto, UserDtoAsync> _repo;

        public UsersController(ISpaRepository<User, UserDto, UserDtoAsync> repo)
        {
            _repo = repo;
        }

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

        public async Task<IHttpActionResult> Post(User customer)
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

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<User> patch)
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

        public async Task<IHttpActionResult> Put([FromODataUri] int key, User update)
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