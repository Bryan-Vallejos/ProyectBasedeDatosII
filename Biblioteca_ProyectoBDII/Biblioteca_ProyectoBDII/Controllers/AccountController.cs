using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_ProyectoBDII.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingUp()
        {
            return View();
        }
    }
}
