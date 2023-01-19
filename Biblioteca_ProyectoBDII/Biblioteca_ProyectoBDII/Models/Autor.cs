using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string? NombreAutor { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
