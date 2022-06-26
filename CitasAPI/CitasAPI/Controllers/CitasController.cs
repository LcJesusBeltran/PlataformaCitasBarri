using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CitasAPI.Models;

namespace CitasAPI.Controllers
{
    public class CitasController : ApiController
    {
        public object Post([FromBody] string[] Busqueda)
        {
            var repo = new RepositoryCitas();
            repo.CrearCita(Busqueda[0], Busqueda[1], Busqueda[2], Busqueda[3]);
            return repo;
        }
    }
}