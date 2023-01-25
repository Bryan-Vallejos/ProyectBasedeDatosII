using Microsoft.EntityFrameworkCore;
using Biblioteca_ProyectoBDII.Models;

namespace Biblioteca_ProyectoBDII.Service.Contrato
{
    public interface IUsuarioService
    {
        Task<Registro> GetRegistro(string user, string password);
        Task<Registro> SaveRegistro(Registro modelo);    
    }
}
