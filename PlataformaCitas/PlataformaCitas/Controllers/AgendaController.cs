using Microsoft.AspNetCore.Mvc;
using PlataformaCitas.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace PlataformaCitas.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            var resp = JsonConvert.DeserializeObject<lDoctores>(HttpContext.Session.GetString("Doctores"));
            return View(resp);
        }
        public IActionResult Agendas(int Id = 0)
        {
            var resp = JsonConvert.DeserializeObject<lDoctores>(HttpContext.Session.GetString("Doctores"));
            var Doctor = resp.Doctores.Where(x => x.IdRollElemento == Id).FirstOrDefault();
            return View(Doctor);
        }
    }
}
