using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using PlataformaCitas.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace PlataformaCitas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*[AllowAnonymous]*/
        public IActionResult Index()
        {
            ViewBag.Nombre = HttpContext.Session.GetString("LoginName");
            lDoctores Doctores = new lDoctores();
            var repo = new APIRequest();
            Doctores = repo.GetDoctores();
            HttpContext.Session.SetString("Doctores", JsonConvert.SerializeObject(Doctores));
            return View(Doctores);
        }

        public IActionResult Citas(int Id = 0)
        {
            ViewBag.Nombre = HttpContext.Session.GetString("LoginName");
            var resp = JsonConvert.DeserializeObject<lDoctores>(HttpContext.Session.GetString("Doctores"));
            var Doctor = resp.Doctores.Where(x => x.IdRollElemento == Id).FirstOrDefault();
            return View(Doctor);
        }

        public IActionResult CitasManual(int Id = 0)
        {
            ViewBag.Nombre = HttpContext.Session.GetString("LoginName");
            var resp = JsonConvert.DeserializeObject<lDoctores>(HttpContext.Session.GetString("Doctores"));
            var Doctor = resp.Doctores.Where(x => x.IdRollElemento == Id).FirstOrDefault();
            return View(Doctor);
        }

        [HttpPost]
        public ActionResult BuscarDisponibilidad(string fecha, int Id)
        {
            lCalendario ListaCalendario = new lCalendario();
            var repo = new APIRequest();
            ListaCalendario = repo.CalendarioCitas(fecha, Id);
            return Content(JToken.Parse(JsonConvert.SerializeObject(ListaCalendario,Newtonsoft.Json.Formatting.None)).ToString());
        }

        [HttpPost]
        public ActionResult CrearCita(string fecha, int Id, int IdHoraCita)
        {
            int IdCliente = int.Parse(HttpContext.Session.GetString("LoginSession"));
            lCalendario ListaCalendario = new lCalendario();
            var repo = new APIRequest();
            ListaCalendario = repo.CrearCita(fecha, Id, IdHoraCita, IdCliente);
            return Content(JToken.Parse(JsonConvert.SerializeObject(ListaCalendario, Newtonsoft.Json.Formatting.None)).ToString());
        }

        [HttpPost]
        public ActionResult CrearCitaManual(string fecha, int Id, int IdHoraCita, string Nombre, string Correo)
        {
            int IdCliente = int.Parse(HttpContext.Session.GetString("LoginSession"));
            lCalendario ListaCalendario = new lCalendario();
            var repo = new APIRequest();
            ListaCalendario = repo.CrearCitaManual(fecha, Id, IdHoraCita, IdCliente, Nombre, Correo);
            return Content(JToken.Parse(JsonConvert.SerializeObject(ListaCalendario, Newtonsoft.Json.Formatting.None)).ToString());
        }

        public IActionResult TestApi()
        {
            APIRequest request = new APIRequest();
            request.TestRequest();
            return View("Privacy");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
