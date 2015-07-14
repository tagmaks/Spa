using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using GenericServices;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;

namespace Spa.Data
{
    public class DataLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ////Autowire the classes with interfaces
            //builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();

            //set Entity Framework context to instance per lifetime scope. 
            //This is important as we get one context per lifetime, so all db classes are tracked together.
            builder.RegisterType<ApplicationDbContext>().As<IGenericServicesDbContext>().InstancePerLifetimeScope();
            //builder.RegisterType(typeof(SpaRepository<Customer>)).UsingConstructor(typeof(IGenericServicesDbContext));

        }
    }
}