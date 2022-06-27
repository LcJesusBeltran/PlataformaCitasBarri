using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace PlataformaCitas.Models
{
    public class APIRequest
    {
        private readonly string uriApi = "http://localhost:44321/api";
        //SACA LISTA DE DOCTORES
        public lDoctores GetDoctores()
        {
            var resp = new lDoctores();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uriApi+"/Doctores");
                request.Method = "GET";
                request.ContentType = "application/json";
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resp = JsonConvert.DeserializeObject<lDoctores>(responseString);
            }
            catch (Exception)
            {
                resp.bError = true;
                resp.Descripcion = "Lista de Clientes no Disponible";
            }
            return resp;
        }
        //LOG DE INICIO DE SESION
        public int saveLogin(string Correo, string Nombre)
        {
            var Lista = new List<string>();
            Lista.Add(Correo);
            Lista.Add(Nombre);
            var json = JsonConvert.SerializeObject(Lista);
            var data = Encoding.UTF8.GetBytes(json);
            var resp = 0;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uriApi + "/Login");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resp = int.Parse(responseString);
            }catch (Exception)
            {
                return 0;
            }
            return resp;
        }

        public lCalendario CalendarioCitas(string Fecha,int Id)
        {
            var Lista = new List<string>();
            Lista.Add(Fecha);
            Lista.Add(Id.ToString());
            var json = JsonConvert.SerializeObject(Lista);
            var data = Encoding.UTF8.GetBytes(json);
            var resp = new lCalendario();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uriApi + "/Calendario");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resp = JsonConvert.DeserializeObject<lCalendario>(responseString);
            }
            catch (Exception)
            {
                resp.bError = true;
            }
            return resp;
        }

        public lCalendario CrearCita(string Fecha, int Id,int IdHoraCita, int IdCliente)
        {
            var Lista = new List<string>();
            Lista.Add(Fecha);
            Lista.Add(Id.ToString());
            Lista.Add(IdHoraCita.ToString());
            Lista.Add(IdCliente.ToString());

            var json = JsonConvert.SerializeObject(Lista);
            var data = Encoding.UTF8.GetBytes(json);
            var resp = new lCalendario();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uriApi + "/Citas");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resp = JsonConvert.DeserializeObject<lCalendario>(responseString);
            }catch (Exception)
            {
                resp.bError = true;
            }
            return resp;
        }

        public lCalendario CrearCitaManual(string Fecha, int Id, int IdHoraCita, int IdCliente,string Nombre, string Correo)
        {
            var Lista = new List<string>();
            Lista.Add(Fecha);
            Lista.Add(Id.ToString());
            Lista.Add(IdHoraCita.ToString());
            Lista.Add(IdCliente.ToString());
            Lista.Add(Nombre);
            Lista.Add(Correo);

            var json = JsonConvert.SerializeObject(Lista);
            var data = Encoding.UTF8.GetBytes(json);
            var resp = new lCalendario();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uriApi + "/Citas");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resp = JsonConvert.DeserializeObject<lCalendario>(responseString);
            }
            catch (Exception)
            {
                resp.bError = true;
            }
            return resp;
        }

        public void TestRequest()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://localhost:44321/api/values");
                request.Method = "GET";
                request.ContentType = "application/json";  
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var resp = JsonConvert.DeserializeObject<List<string>>(responseString);
            }
            catch (Exception)
            {

            }
            
        }
    }
}
