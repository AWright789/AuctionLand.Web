using AuctionLand.Data.Entities;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;
using System.Web.Mvc;
using AuctionLand.Data.Entities.DAL;
using AuctionLand.Service.Interfaces;
using AuctionLand.Service.Implementations;
using AuctionLand.Web.App_Start;
using System.Reflection;
using AuctionLand.Web.Areas.Admin.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuctionLand.Web.IoC
{
    public class IoCConfiguration
    {
        public static void RegisterDependencies()
        {

            AutoMapperConfiguration.Configure();

            var builder = new ContainerBuilder();


            #region Setup a common pattern - placed here before RegisterControllers as last one wins
            builder.RegisterAssemblyTypes().Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes().Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerHttpRequest();
            #endregion

            #region Register all controllers for the assembly
            // Note that ASP.NET MVC requests controllers by their concrete types, so registering them As<IController>() is incorrect. 
            // Also, if you register controllers manually and choose to specify lifetimes, you must register them as InstancePerDependency() or InstancePerHttpRequest() - 
            // ASP.NET MVC will throw an exception if you try to reuse a controller instance for multiple requests. 
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerDependency();
            //builder.RegisterApiControllers(typeof(MvcApplication).Assembly).InstancePerHttpRequest();

           // builder.RegisterControllers(Assembly.GetExecutingAssembly()).InjectActionInvoker().InstancePerHttpRequest();
            
            #endregion

            #region Register modules
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            #endregion

            #region Model binder providers - excluded - not sure if need
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();
            #endregion

            #region Register Services and DB Context

            builder.RegisterType<AuctionLandDbContext>().As<IAuctionLandDbContext>();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>();

            builder.RegisterType<UserManager<ApplicationUser>>();



            builder.RegisterType<RealEstateService>().As<IRealEstateService>();
            builder.RegisterType<ImageService>().As<IImageService>();
            builder.RegisterType<ImageBlobStorageService>().As<IImageBlobStorageService>();
            builder.RegisterType<RealEstateImageController>().InstancePerDependency();
            builder.RegisterType<BidService>().As <IBidService>();
           
            #endregion

            builder.RegisterType<AuctionLand.Web.Controllers.HomeController>().InstancePerDependency();

            #region Inject HTTP Abstractions
            /*
         The MVC Integration includes an Autofac module that will add HTTP request lifetime scoped registrations for the HTTP abstraction classes. The following abstract classes are included: 
        -- HttpContextBase 
        -- HttpRequestBase 
        -- HttpResponseBase 
        -- HttpServerUtilityBase 
        -- HttpSessionStateBase 
        -- HttpApplicationStateBase 
        -- HttpBrowserCapabilitiesBase 
        -- HttpCachePolicyBase 
        -- VirtualPathProvider 

        To use these abstractions add the AutofacWebTypesModule to the container using the standard RegisterModule method. 
        */
            builder.RegisterModule<AutofacWebTypesModule>();

            #endregion

            #region Set the MVC dependency resolver to use Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion

        }
    }
    
}