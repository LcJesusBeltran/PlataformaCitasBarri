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
            try
            {
                using (var conn = new SqlConnection(conString))
                {
                    using (var reader = conn.QueryMultiple(sQuery))
                    {
                        res = reader.Read<int>().ToList();
                    }
                }
                var resultado = res.ToArray();
                return resultado[0];
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}