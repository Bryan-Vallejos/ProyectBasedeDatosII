﻿using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Titulo { get; set; }

    public int? IdAutor { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdEditorial { get; set; }

    public string? Ubicacion { get; set; }

    public int? Ejemplares { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
