using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netby.Fullstack.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }

        public Todo()
        {
            Id = 0;
            FechaCreacion = DateTime.Now;
            Completada = false;
        }
    }
}