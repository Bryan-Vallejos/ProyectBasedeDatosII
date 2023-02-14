using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class Registro
    {
        public Registro()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdUsuario { get; set; }
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
