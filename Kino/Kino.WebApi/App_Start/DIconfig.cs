using Autofac.Integration.WebApi;
using Autofac;
using Kino.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac.Core;
using Kino.Repository.Common;
using Kino.Service;
using Kino.Repository;
using Kino.DAL;

namespace Kino.WebApi.App_Start
{
    public class DIconfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<FilmService>().As<IFilmService>();
            builder.RegisterType<EFFilmRepository>().As<IFilmRepository>();
            builder.RegisterType<SmallCinemaContext>().AsSelf();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
