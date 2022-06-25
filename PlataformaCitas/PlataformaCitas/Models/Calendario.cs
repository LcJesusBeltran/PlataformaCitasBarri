using System;
using System.Collections.Generic;
namespace PlataformaCitas.Models
{
    public class Calendario
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public DateTime Date { get; set; }

        public List<Calendario> calendario(int lanio)
        {
            var ListaCalendario = new List<Calendario>();
            for(int i = 1; i <= 12; i++)
            {
                var x = 31;
                if(i == 4 || i == 6 || i == 9 || i == 11)
                {
                    x = 30;
                }
                else if(i == 2)
                {
                    x = CalculaBisiesto(lanio); 
                }
                for(int j = 1; j <= x; j++)
                {
                    var fechaString = lanio.ToString("0000") + "-" + i.ToString("00") + "-" + j.ToString("00");
                    var FechaDate = DateTime.ParseExact(fechaString, "yyyy-MM-dd",null);
                    ListaCalendario.Add(new Calendario{ Anio = lanio, Mes = i, Dia = j, Date = FechaDate});
                }
            }

            return ListaCalendario;

        }

        public int CalculaBisiesto(int valor)
        {
            int res = 28;
            if (valor % 4 == 0 && valor % 100 != 0 || valor % 400 == 0)
            {
                res = 29;
            }
            return res;
        }

        internal object calendario(DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}
