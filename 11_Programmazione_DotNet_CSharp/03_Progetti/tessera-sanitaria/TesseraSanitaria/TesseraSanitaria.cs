using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClasseTesseraSanitaria
{
    internal class TesseraSanitaria
    {
        //propietà
        public string NumeroIdentificativoTessera { get; set; }
        public string CodiceFiscale { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string LuogoNascita { get; set; }
        public string Provincia { get; set; }
        public DateTime DataNascita { get; set; }
        public Sesso Sesso { get; set; }
        public DateTime DataScadenza { get; set; }
        public string NumeroIdentificativoIstituzione { get; set; }

        //costruttori
        public TesseraSanitaria(string numeroIdentificativoTessera, string codiceFiscale, string cognome, string nome, string luogoNascita, string provincia, DateTime dataNascita, Sesso sesso, DateTime dataScadenza, string numeroIdentificativoIstituzione)
        {
            NumeroIdentificativoTessera = numeroIdentificativoTessera;
            CodiceFiscale = codiceFiscale;
            Cognome = cognome;
            Nome = nome;
            LuogoNascita = luogoNascita;
            Provincia = provincia;
            DataNascita = dataNascita;
            Sesso = sesso;
            DataScadenza = dataScadenza;
            NumeroIdentificativoIstituzione = numeroIdentificativoIstituzione;
        }

        //metodi
        public bool IsInScadenza()
        {
            DateTime oggi = DateTime.Now;

            //30 giorni prima della scadenza
            DateTime verifica = DataScadenza.AddDays(-30);

            if (verifica <= oggi)
            {
                return true; //è in scadenza
            }
            else
            {
                return false; //non è in scadenza
            }
        }

        public bool IsScaduta()
        {
            DateTime oggi = DateTime.Now;
            if (DataScadenza < oggi)
            {
                return true; //è scaduta
            }
            else
            {
                return false; //non è scaduta
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(NumeroIdentificativoTessera)}={NumeroIdentificativoTessera}," +
                $" {nameof(CodiceFiscale)}={CodiceFiscale}," +
                $" {nameof(Cognome)}={Cognome}," +
                $" {nameof(Nome)}={Nome}," +
                $" {nameof(LuogoNascita)}={LuogoNascita}," +
                $" {nameof(Provincia)}={Provincia}," +
                $" {nameof(DataNascita)}={DataNascita.ToString()}," +
                $" {nameof(Sesso)}={Sesso.ToString()}," +
                $" {nameof(DataScadenza)}={DataScadenza.ToString()}," +
                $" {nameof(NumeroIdentificativoIstituzione)}={NumeroIdentificativoIstituzione}}}";
        }

    }


    } 


