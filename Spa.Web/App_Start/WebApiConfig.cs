using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Builder;
using Microsoft.OData.Edm;
using Newtonsoft.Json.Serialization;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;

namespace Spa.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapODataServiceRoute("Spa", "OData", GenerateEdmModel());

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static Microsoft.Data.Edm.IEdmModel GenerateEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<AppUser>("AppUsers");
            builder.EntitySet<CustomUserClaim>("Claims");
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<CustomerGroup>("CustomerGroups");
            builder.EntitySet<OfferList>("OfferLists");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<Ratio>("Ratios");

            return builder.GetEdmModel();
        }
    }
}