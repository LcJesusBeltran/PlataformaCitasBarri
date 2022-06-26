using System.Collections.Generic;

namespace PlataformaCitas.Models
{
    public class lCalendario
    {
        public bool bError { get; set; }
        public string Descripcion { get; set; }
        public List<CalendarioCitas> ListaCalendario = new List<CalendarioCitas>();
    }
}
