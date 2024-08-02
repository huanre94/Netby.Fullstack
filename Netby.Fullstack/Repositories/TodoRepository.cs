using Netby.Fullstack.Interfaces;
using Netby.Fullstack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netby.Fullstack.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        List<Todo> _todoList = new List<Todo>
            {
                new Todo { Id = 1, Titulo = "Comprar leche", Descripcion = "Comprar leche en el supermercado", FechaVencimiento = DateTime.Now.AddDays(1), Completada = false },
                new Todo { Id = 2, Titulo = "Hacer ejercicio", Descripcion = "Ir al gimnasio por la tarde", FechaVencimiento = DateTime.Now.AddDays(2), Completada = false },
                new Todo { Id = 3, Titulo = "Leer un libro", Descripcion = "Leer al menos 20 páginas de un libro", FechaVencimiento = DateTime.Now.AddDays(3), Completada = true }
            };

        public TodoRepository()
        {

        }

        public bool Actualizar(Todo item)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == item.Id);

            if (todo == null)
            {
                return false;
            }

            todo.Titulo = item.Titulo;
            todo.Descripcion = item.Descripcion;
            todo.FechaVencimiento = item.FechaVencimiento;
            todo.Completada = item.Completada;

            return true;
        }

        public bool Agregar(Todo item)
        {
            int nextId = _todoList.Any() ? _todoList.Max(t => t.Id) + 1 : 1;

            item.Id = nextId;

            _todoList.Add(item);

            return true;
        }

        public bool Borrar(int id)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == id);

            if (todo == null)
            {
                return false;
            }

            _todoList.Remove(todo);
            return true;

        }

        public Todo ConsultarTodo(int id)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == id);

            return todo == null ? new Todo() : todo;
        }

        public IEnumerable<Todo> ConsultarTodos()
        {
            return _todoList;
        }
    }
}