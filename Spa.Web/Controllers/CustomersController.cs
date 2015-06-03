using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;

namespace Spa.Web.Controllers
{
    public class CustomersController : ODataController
    {
        private readonly SpaRepository _ctx = new SpaRepository();

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
                return BadRequest(ModelState);
            }
            var postCustomerTask = _ctx.PostCustomerAsync(customer);
            await postCustomerTask;
            if (!postCustomerTask.IsCompleted)
            {
                return InternalServerError();
            }
            return Created(customer);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Customer> patch)
        {
            //Validate(patch.GetEntity());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = await _ctx.GetCustomerAsync(key);
            if (customer == null)
            {
                return NotFound();
            }
            Validate(customer, typeof(Customer));


            try
            {
                await _ctx.PatchCustomerAsync(patch, customer);
            }
            // Exception occures if entity was changed since the last loading
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_ctx.CustomerExists(key))
                {
                    return NotFound();
                }
                return InternalServerError(ex);
            }
            return Updated(customer);
        }

        private void Validate(object model, Type type)
        {
            var validator = Configuration.Services.GetBodyModelValidator();
            var metadataProvider = Configuration.Services.GetModelMetadataProvider();

            HttpActionContext actionContext = new HttpActionContext(ControllerContext, Request.GetActionDescriptor());

            if (!validator.Validate(model, type, metadataProvider, actionContext, String.Empty))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState));
            }
        }


        public async Task<IHttpActionResult> Put([FromODataUri] int key, Customer update, ODataQueryOptions options)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            if (options.IfMatch != null && options.IfMatch.ApplyTo(_ctx.GetCustomer(key).Queryable) == null)
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }
            try
            {
                await _ctx.PutCustomerAsync(update);
            }
            // Exception occures if entity was changed since the last loading
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_ctx.CustomerExists(key))
                {
                    return NotFound();
                }
                return InternalServerError(ex);
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var customer = await _ctx.GetCustomerAsync(key);
            if (customer == null)
            {
                return NotFound();
            }
            await _ctx.DeleteCustomerAsync(customer);
            return StatusCode(HttpStatusCode.NoContent);
        } 



        protected override void Dispose(bool disposing)
        {
            //_ctx._db.Dispose();
            base.Dispose(disposing);
        }
    }
}