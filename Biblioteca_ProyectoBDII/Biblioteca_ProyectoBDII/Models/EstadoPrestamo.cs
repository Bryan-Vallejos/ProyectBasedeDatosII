using System;
using System.Collections.Generic;

namespace Biblioteca_ProyectoBDII.Models
{
    public partial class EstadoPrestamo
    {
        public EstadoPrestamo()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdEstadoPrestamo { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
