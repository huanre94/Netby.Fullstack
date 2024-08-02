using Netby.Fullstack.Context;
using Netby.Fullstack.Interfaces;
using Netby.Fullstack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Netby.Fullstack.Repositories
{
    public class TodoEFRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoEFRepository(TodoContext context)
        {
            _context = context;
        }

        public bool Actualizar(Todo item)
        {
            var todo = _context.Todos.Find(item.Id);

            if (todo == null)
            {
                return false;
            }

            todo.Titulo = item.Titulo;
            todo.Descripcion = item.Descripcion;
            todo.FechaVencimiento = item.FechaVencimiento;
            todo.Completada = item.Completada;

            _context.SaveChanges();
            return true;
        }

        public bool Agregar(Todo item)
        {
            int nextId = _context.Todos.Any() ? _context.Todos.Max(t => t.Id) + 1 : 1;
            item.Id = nextId;
            _context.Todos.Add(item);
            var added = _context.SaveChanges();
            return added > 0;
        }

        public bool Borrar(int id)
        {
            var todo = _context.Todos.Find(id);

            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Todo ConsultarTodo(int id)
        {
            return _context.Todos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Todo> ConsultarTodos()
        {
            var todos = _context.Todos.ToList();

            return todos;
        }
    }
}