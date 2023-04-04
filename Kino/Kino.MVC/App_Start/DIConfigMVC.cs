using Autofac;
using Autofac.Integration.Mvc;
using Kino.DAL;
using Kino.Repository;
using Kino.Repository.Common;
using Kino.Service;
using Kino.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Kino.MVC.App_Start
{
    public class DIConfigMVC
    {
        public static void ConfigureMVC()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<FilmService>().As<IFilmService>();
            builder.RegisterType<EFFilmRepository>().As<IFilmRepository>();
            builder.RegisterType<SmallCinemaContext>().AsSelf();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}