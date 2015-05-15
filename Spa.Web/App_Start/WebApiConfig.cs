using Microsoft.Data.Edm;
using Newtonsoft.Json.Serialization;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace Spa.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapODataRoute("Spa", "OData", GenerateEdmModel());

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static IEdmModel GenerateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
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
