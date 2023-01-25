using Microsoft.EntityFrameworkCore;
using Biblioteca_ProyectoBDII.Models;
using Biblioteca_ProyectoBDII.Service.Contrato;

namespace Biblioteca_ProyectoBDII.Service.Implement
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BibliotecaProyectBdiiContext _dbContext;
        public UsuarioService(BibliotecaProyectBdiiContext dbContect)
        {
            _dbContext = dbContect;
        }

        public async Task<Registro> GetRegistro(string user, string password)
        {
            Registro usuarioEncontrado = await _dbContext.Registros.Where(u => u.Usuario == user && u.Contraseña == password)
                .FirstOrDefaultAsync();

            return usuarioEncontrado;
        }

        public async Task<Registro> SaveRegistro(Registro modelo)
        {
            _dbContext.Registros.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
