using Netby.Fullstack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netby.Fullstack.Interfaces
{
    public interface ITodoRepository
    {
        bool Agregar(Todo item);
        bool Actualizar(Todo item);
        bool Borrar(int id);
        Todo ConsultarTodo(int id);
        IEnumerable<Todo> ConsultarTodos();
    }
}