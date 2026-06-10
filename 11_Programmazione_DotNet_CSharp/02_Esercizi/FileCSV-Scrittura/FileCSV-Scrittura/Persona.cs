using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileCSV_Scrittura
{
    internal class Persona
    {
        public required string Nome { get; set; }
        public required string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public required string LuogoNascita { get; set; }
        public TipoSesso Sesso { get; set; }

        //metodi
        public int Eta()
        {
            DateTime oggi = DateTime.Today;
            
            int eta=oggi.Year - DataNascita.Year;

            if (oggi.Month > DataNascita.Month
                ||
                (oggi.Month == DataNascita.Month && oggi.Day > DataNascita.Day))
                eta--;

            return eta;
        }
        public string FormatCSV()
        {
            return$"{Nome};{Cognome};{DataNascita.ToShortDateString()};{LuogoNascita};{Sesso.ToString()}";
        }
        public override string ToString()
        {
            return $"{{" +
                $"{nameof(Nome)}={Nome}" +
                $", {nameof(Cognome)}={Cognome}" +
                $", {nameof(DataNascita)}={DataNascita.ToString()}" +
                $", {nameof(LuogoNascita)}={LuogoNascita}" +
                $", {nameof(Sesso)}={Sesso.ToString()}" +
                $"}}";
        }
    }
}
