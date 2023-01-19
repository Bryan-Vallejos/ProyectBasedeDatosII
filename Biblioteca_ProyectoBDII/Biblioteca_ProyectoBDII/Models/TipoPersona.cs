using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models;

public partial class TipoPersona
{
    public int IdTipoPersona { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
