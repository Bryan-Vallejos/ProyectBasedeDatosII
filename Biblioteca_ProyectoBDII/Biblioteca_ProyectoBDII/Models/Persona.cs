﻿using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models;

public partial class Persona
{

    public int IdPersona { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string Correo { get; set; } = null!;

    public string? Codigo { get; set; }

    public int? IdTipoPersona { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual TipoPersona? IdTipoPersonaNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();

    public virtual ICollection<Registro> Registros { get; } = new List<Registro>();
}