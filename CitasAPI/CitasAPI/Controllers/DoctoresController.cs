using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CitasAPI.Models;

namespace CitasAPI.Controllers
{
    public class DoctoresController : ApiController
    {
        // GET api/values
        public object Get()
        {
            var resp = new RepositoryDoctores();
            resp.GetDoctores();
            return resp;
        }
    }
}