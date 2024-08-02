using Netby.Fullstack.Context;
using Netby.Fullstack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Netby.Fullstack
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependencyResolverConfig.RegisterDependencies();

            Effort.Provider.EffortProviderConfiguration.RegisterProvider();

            Database.SetInitializer(new TodoDatabaseInitializer());
        }
    }

    public class TodoDatabaseInitializer : DropCreateDatabaseAlways<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            var todos = new List<Todo>
        {
            new Todo { Titulo = "Todo 1", Descripcion = "Descripcion 1", FechaVencimiento = DateTime.Now.AddDays(1), Completada = false },
            new Todo { Titulo = "Todo 2", Descripcion = "Descripcion 2", FechaVencimiento = DateTime.Now.AddDays(2), Completada = false }
        };

            todos.ForEach(todo => context.Todos.Add(todo));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
