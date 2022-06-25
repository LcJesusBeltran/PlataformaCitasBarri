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

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}