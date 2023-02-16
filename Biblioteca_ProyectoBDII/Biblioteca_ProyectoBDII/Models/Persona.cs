﻿using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdPersona { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Codigo { get; set; }
        public int? IdTipoPersona { get; set; }
        public string? Id { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual User? IdNavigation { get; set; }
        public virtual TipoPersona? IdTipoPersonaNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
