using Autofac;
using Autofac.Integration.WebApi;
using Effort;
using Netby.Fullstack.Context;
using Netby.Fullstack.Interfaces;
using Netby.Fullstack.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Netby.Fullstack
{
    public class DependencyResolverConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => DbConnectionFactory.CreateTransient())
                   .As<DbConnection>()
                   .InstancePerLifetimeScope();

            builder.Register(c => new TodoContext(c.Resolve<DbConnection>()))
                   .AsSelf()
                   .InstancePerLifetimeScope();

            builder.RegisterType<TodoEFRepository>()
                   .As<ITodoRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}