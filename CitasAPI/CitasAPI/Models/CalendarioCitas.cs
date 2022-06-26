using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasAPI.Models
{
    public class CalendarioCitas
    {
        public int IdHoraCita { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }
        public int? IdCalendario { get; set; }
        public string NombreCompleto { get; set; }
        public string DireccionElectronica { get; set; }
        public string FechaCita { get; set; }
        public int? IdRollMedico { get; set; }
    }
}