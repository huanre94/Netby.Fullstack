using Netby.Fullstack.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Netby.Fullstack.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext() : base("TodoDatabase")
        {
        }

        public TodoContext(DbConnection connection) : base(connection, true)
        {
        }

        public DbSet<Todo> Todos { get; set; }

    }
}