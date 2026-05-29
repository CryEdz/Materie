using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassePersona
{
    internal class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string LuogoNascita { get; set; }
        public TipoSesso Sesso { get; set; }

        //costruttori
        //Overloading
        public Persona(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }

        public Persona(string nome, string cognome, DateTime dataNascita, string luogoNascita) 
            : this(nome, cognome)
        {
            DataNascita = dataNascita;
            LuogoNascita = luogoNascita;
        }

        public Persona(string nome, string cognome, DateTime dataNascita, string luogoNascita, TipoSesso sesso)
            : this(nome, cognome, dataNascita, luogoNascita)
        {
            Sesso = sesso;
        }

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
