using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using GenericServices;
using GenericServices.Services;
using GenericServices.Services.Concrete;
using Spa.Data.Infrastructure;

namespace Spa.Data
{
    public class ServiceLayerModule: Module
    {
        /// <summary>
        /// This registers all items in service layer and below
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //Now register the DataLayer
            builder.RegisterModule(new DataLayerModule());

            //Reigister the BizLayer
            //builder.RegisterModule(new BizLayerModule());

            ////---------------------------
            ////Register service layer: autowire all 
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();

            //and register all the non-generic interfaces interfaces GenericServices assembly
            builder.RegisterAssemblyTypes(typeof(IListService<>).Assembly).AsImplementedInterfaces();

            //builder.RegisterGeneric(typeof(SpaRepository<>)).As(typeof(ISpaRepository<>));
            
            //and register all the non-generic interfaces GenericServices assembly
            //builder.RegisterType<ListService>().As<IListService>();

            

            //builder.RegisterType<ListService>().As<IListService>();

            //builder.RegisterAssemblyTypes(typeof(IListService).Assembly).AsImplementedInterfaces();
            //builder.RegisterType(typeof(ListService)).UsingConstructor(typeof(IGenericServicesDbContext));

        }
    }
}