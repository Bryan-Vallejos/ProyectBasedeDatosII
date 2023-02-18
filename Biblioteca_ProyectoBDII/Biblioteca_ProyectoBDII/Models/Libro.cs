using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdLibro { get; set; }
        [Display(Name = "Titulo")]
        public string? Titulo { get; set; }
        [Display(Name = "Autor")]
        public int? IdAutor { get; set; }
        [Display(Name = "Categoria")]
        public int? IdCategoria { get; set; }
        [Display(Name = "Editorial")]
        public int? IdEditorial { get; set; }
        [Display(Name = "Ubicacion")]
        public string? Ubicacion { get; set; }
        [Display(Name = "Ejemplares")]
        public int? Ejemplares { get; set; }
        [Display(Name = "Estado")]
        public bool? Estado { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime? FechaCreacion { get; set; }

        [Display(Name = "Autor")]
        public virtual Autor? IdAutorNavigation { get; set; }
        [Display(Name = "Categoria")]
        public virtual Categorium? IdCategoriaNavigation { get; set; }
        [Display(Name = "Editorial")]
        public virtual Editorial? IdEditorialNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
