using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Prestamos = new HashSet<Prestamo>();
        }
        public int IdPersona { get; set; }

        [Display(Name = "Nombres")]
        public string Nombres { get; set; } = null!;

        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = null!;

        [Display(Name = "Correo")]
        public string Correo { get; set; } = null!;

        [Display(Name = "Codigo")]
        public string? Codigo { get; set; }

        [Display(Name = "Tipo Persona")]
        public int? IdTipoPersona { get; set; }

        public string? Id { get; set; }

        [Display(Name = "Estado")]
        public bool? Estado { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual User? IdNavigation { get; set; }
        public virtual TipoPersona? IdTipoPersonaNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
