using Microsoft.AspNetCore.Mvc;

namespace PlataformaCitas.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
