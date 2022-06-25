using Microsoft.AspNetCore.Mvc;

namespace PlataformaCitas.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Logon()
        {
            return View();
        }
    }
}
