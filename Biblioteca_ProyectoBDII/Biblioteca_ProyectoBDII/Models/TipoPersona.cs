using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class TipoPersona
    {
        public TipoPersona()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdTipoPersona { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
