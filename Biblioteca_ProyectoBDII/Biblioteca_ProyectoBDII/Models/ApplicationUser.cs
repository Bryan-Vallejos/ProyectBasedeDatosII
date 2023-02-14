using Microsoft.AspNetCore.Identity;

namespace Biblioteca_ProyectoBDII.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Usuario { get; set; }

       // public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
