using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace PlataformaCitas.Models
{
    public class lDoctores
    {
        public bool bError { get; set; }
        public string Descripcion { get; set; }
        public List<Persona> Doctores = new List<Persona>();

    }
}
