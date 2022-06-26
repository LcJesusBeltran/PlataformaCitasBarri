using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CitasAPI.Models;
using Newtonsoft.Json;

namespace CitasAPI.Controllers
{
    public class LoginController : ApiController
    {
        public object Post([FromBody] string[] Credenciales)
        {
            var repo = new RepositoryLoggin();
            var resp = repo.GetLoginUserId(Credenciales[0], Credenciales[1]);
            return resp;
        }

    }
}