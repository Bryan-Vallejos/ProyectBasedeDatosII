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
        private readonly IUsuarioService _usuarioservice;
        public AccountController(IUsuarioService usuarioService)
        {
            _usuarioservice = usuarioService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string user,string password)
        {
            Registro usuario_encontrado = await _usuarioservice.GetRegistro(user, Utilidades.EncriptarPwd(password));

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontro el usuario";
                return View();
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Usuario)
            };

            ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity), properties
            );

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Registro registro)
        {
            registro.Contraseña = Utilidades.EncriptarPwd(registro.Contraseña);
            Registro registro_creado = await _usuarioservice.SaveRegistro(registro);

            if (registro_creado.IdUsusario > 0)
                return RedirectToAction("Login", "Account");

            ViewData["Mensaje"] = "No se pudo registrar el usuario";     
            return View();
        }
    }
}
