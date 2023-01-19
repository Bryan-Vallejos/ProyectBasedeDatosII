using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
