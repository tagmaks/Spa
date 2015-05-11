using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Spa.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Customers",
                routeTemplate: "api/customers/{id}",
                defaults: new { controller = "customers", id = RouteParameter.Optional }
            );
        }
    }
}
