using Microsoft.AspNetCore.Mvc;
using Biblioteca_ProyectoBDII.Models;
using Biblioteca_ProyectoBDII.Resource;
using Biblioteca_ProyectoBDII.Service.Contrato;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Biblioteca_ProyectoBDII.Controllers.Cuenta
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Registro registro)
        {
            bool registrado;
            string mensaje;

            if(registro.Contraseña == registro.ConfirmarContraseña)
            {

            }
            return View();
        }
    }
}
