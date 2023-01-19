using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models;

public partial class Editorial
{
    public int IdEditorial { get; set; }

    public string? NombreEditorial { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
