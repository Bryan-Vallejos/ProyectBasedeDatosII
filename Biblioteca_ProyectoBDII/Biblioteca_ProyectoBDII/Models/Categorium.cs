using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
