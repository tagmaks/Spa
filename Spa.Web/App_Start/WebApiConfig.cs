using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.OData.Extensions;
using System.Web.OData.Builder;
using Microsoft.OData.Edm;
using Newtonsoft.Json.Serialization;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using Spa.Web.Helpers;
using Spa.Web.Infrastructure;
using Spa.Web.Tracing;

namespace Spa.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "OData",
                model: GenerateEdmModel()
                );

            config.AddODataQueryFilter();

            //setup dependency injection items
            DependencyInjectionConfig.RegisterDependencyInjection();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Configure HTTP Caching using Entity Tags (ETags)
            var cacheCowCacheHandler = CachingFactory.GetCachingHandlerByCacheStore(CachingStores.SqlCacheStore, config, "ApplicationConnection");
            config.MessageHandlers.Add(cacheCowCacheHandler);

            config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }

        private static IEdmModel GenerateEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<AppUser>("AppUsers");
            builder.EntitySet<CustomUserClaim>("Claims");

            var customers = builder.EntitySet<Customer>("Customers");
            customers.EntityType.Ignore(c => c.PasswordHash);

            builder.EntitySet<CustomerGroup>("CustomerGroups");
            builder.EntitySet<OfferList>("OfferLists");
            builder.EntitySet<Offer>("Offers");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<Ratio>("Ratios");

            return builder.GetEdmModel();
        }
    }
}