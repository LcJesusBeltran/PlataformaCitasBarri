using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace CitasAPI.Models
{
    public class RepositoryLoggin
    {
        private readonly string conString = ConfigurationManager.AppSettings["ConnStringLocal"].ToString();
        public int GetLoginUserId(string Correo, string nombre )
        {
            var sQuery = "EXEC dbo.InsertLogin '" + Correo + "','" + nombre +"'";
            List<int> res = new List<int>();
            int resultado = 0;
            try
            {
                using (var conn = new SqlConnection(conString))
                {
                    var response = conn.QuerySingle(sQuery);
                    resultado = response.IdRollElemento;
                }              
                return resultado;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}