using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace CitasAPI.Models
{
    public class RepositoryDoctores
    {

        private readonly string conString = ConfigurationManager.AppSettings["ConnStringLocal"].ToString();
        private readonly string sQuery = ConfigurationManager.AppSettings["SQLGetDoctores"].ToString();
        public bool bError { get; set; }
        public string Descripcion { get; set; }
        public List<Persona> Doctores = new List<Persona>();
        public void GetDoctores()
        {
            Doctores.Clear();
            try
            {
                //dao <-- buscar
                using(var conn = new SqlConnection(conString))
                {
                    using(var reader = conn.QueryMultiple(sQuery))
                    {
                        Doctores = reader.Read<Persona>().ToList();
                    }
                }
                //quitar cuando tengas el formato de la imagen para almacenar
                foreach(var Doctor in Doctores)
                {
                    Doctor.img = Doctor.IdRollElemento + ".jpg";
                }
            }
            catch (Exception)
            {
                bError = true;
                Descripcion = "Lista de doctores no disponible";
            }

        }
    }
}