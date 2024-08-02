using Netby.Fullstack.Interfaces;
using Netby.Fullstack.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Netby.Fullstack.Controllers
{
    [RoutePrefix("api/todo")]
    public class TodoController : ApiController
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetTodos()
        {
            var todos = _todoRepository.ConsultarTodos();

            if (todos == null || !todos.Any())
            {
                return NotFound();
            }

            return Ok(todos);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetTodo([FromUri] int id)
        {
            var todo = _todoRepository.ConsultarTodo(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public IHttpActionResult PostTodo([FromBody] Todo newTodo)
        {
            if (newTodo == null)
            {
                return BadRequest("Todo no puede ser nulo.");
            }

            _todoRepository.Agregar(newTodo);

            return CreatedAtRoute("DefaultApi", new { id = newTodo.Id }, newTodo);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult PutTodo(int id, [FromBody] Todo updatedTodo)
        {
            if (updatedTodo == null || id != updatedTodo.Id)
            {
                return BadRequest("Los campos de Todo no son válidos.");
            }

            var updated = _todoRepository.Actualizar(updatedTodo);

            if (updated)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteTodo(int id)
        {
            var deleted = _todoRepository.Borrar(id);

            if (!deleted)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
