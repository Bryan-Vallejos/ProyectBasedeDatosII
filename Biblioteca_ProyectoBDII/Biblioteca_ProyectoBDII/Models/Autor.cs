using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdAutor { get; set; }
        [Display(Name = "Nombre")]
        public string? NombreAutor { get; set; }
        public bool? Estado { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
