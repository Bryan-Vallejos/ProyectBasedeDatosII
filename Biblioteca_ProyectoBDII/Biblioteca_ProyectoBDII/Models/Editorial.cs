using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdEditorial { get; set; }
        [Display(Name = "Nombre Editorial")]
        public string? NombreEditorial { get; set; }
        public bool? Estado { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
