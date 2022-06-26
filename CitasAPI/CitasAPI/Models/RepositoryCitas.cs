using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace CitasAPI.Models
{
    public class RepositoryCitas
    {
        private readonly string conString = ConfigurationManager.AppSettings["ConnStringLocal"].ToString();
        public bool bError { get; set; }
        public string Descripcion { get; set; }
        public List<CalendarioCitas> ListaCalendario = new List<CalendarioCitas>();
        public void GetCalendarioDisponible( string Fecha, string Id)
        {
            ListaCalendario.Clear();
            var sQuery = "EXEC dbo.CalendarioCitas " + Id + ",'" + Fecha + "'";
            try
            {
                using (var conn = new SqlConnection(conString))
                {
                    using (var reader = conn.QueryMultiple(sQuery))
                    {
                        ListaCalendario = reader.Read<CalendarioCitas>().ToList();
                    }
                }
            }
            catch (Exception)
            {
                bError = true;
                Descripcion = "Lista de citas no disponible";
            }
        }
    }
}