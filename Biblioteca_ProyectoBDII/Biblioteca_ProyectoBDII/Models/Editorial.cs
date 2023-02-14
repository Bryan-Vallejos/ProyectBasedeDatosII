using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdEditorial { get; set; }
        public string? NombreEditorial { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
