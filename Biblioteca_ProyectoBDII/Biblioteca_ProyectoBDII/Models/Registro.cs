using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models;

public partial class Registro
{
    public int IdUsusario { get; set; }

    public string? Usuario { get; set; }

    public string? Contraseña { get; set; }
    public string? ConfirmarContraseña { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
