using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasAPI.Models
{
    public class LoginCliente
    {
        public int Id { get; set; }
        public int IdRollElemento { get; set; }
        public string DireccionElectronica { get; set; }
    }
}