using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using System.Web.Http.Dependencies;
using Autofac.Builder;
using Autofac.Core.Activators.Reflection;
using Autofac.Integration.WebApi;
using GenericServices;
using GenericServices.Services;
using GenericServices.Services.Concrete;
using GenericServices.ServicesAsync;
using GenericServices.ServicesAsync.Concrete;
using Spa.Data;
using Spa.Data.Dtos;
using Spa.Data.Entities;
using Spa.Data.Infrastructure;
using Spa.Web.Controllers;

namespace Spa.Web
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependencyInjection()
        {
            //This sets up the Autofac container for all levels in the program
            var container = SetupDependencies();

            var config = GlobalConfiguration.Configuration;

            // Set the dependency resolver for Web Api
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer SetupDependencies()
        {
            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterAssemblyTypes()
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .InstancePerRequest();

            //builder.RegisterType<ListService<Customer>>()
            //    .As<IListService<Customer>>()
            //    .UsingConstructor(typeof(IGenericServicesDbContext));

            builder.RegisterGeneric(typeof (SpaRepository<,,>))
                .As(typeof (ISpaRepository<,,>))
                .InstancePerRequest()
                .PropertiesAutowired();

            #region Property injection <TEntity>
            builder.RegisterGeneric(typeof(ListService<>))
                .As(typeof(IListService<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DetailServiceAsync<>))
                .As(typeof(IDetailServiceAsync<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DetailService<>))
                .As(typeof(IDetailService<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(CreateServiceAsync<>))
                .As(typeof(ICreateServiceAsync<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(UpdateServiceAsync<>))
                .As(typeof(IUpdateServiceAsync<>))
                .InstancePerRequest();
            #endregion

            #region Property injection <TEntity, TDto>
            builder.RegisterGeneric(typeof(ListService<,>))
                .As(typeof(IListService<,>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DetailServiceAsync<,>))
                .As(typeof(IDetailServiceAsync<,>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DetailService<,>))
                .As(typeof(IDetailService<,>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(CreateServiceAsync<,>))
                .As(typeof(ICreateServiceAsync<,>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(UpdateServiceAsync<,>))
                .As(typeof(IUpdateServiceAsync<,>))
                .InstancePerRequest();
            #endregion

            //builder.RegisterGeneric(typeof(DeleteService))
            //    .As(typeof(IDeleteService))
            //    .InstancePerRequest();

            ////Registration concreate repo for entity
            //builder.RegisterType<SpaRepository<Customer>>()
            //    .As<ISpaRepository<Customer>>()
            //    .AsImplementedInterfaces()
            //    .InstancePerRequest()
            //    .OnActivated(e =>
            //    {
            //        e.Instance.ListService = e.Context.ResolveOptional<IListService<Customer>>();

            //    });

            builder.RegisterType(typeof(UsersController))
                .UsingConstructor(typeof(ISpaRepository<User, UserDto, UserDtoAsync>));

            Load(builder);

            return builder.Build();
        }

        private static void Load(ContainerBuilder builder)
        {
            //register the service layer, which then registers all other dependencies in the rest of the system
            builder.RegisterModule(new ServiceLayerModule());
        }
    }
}