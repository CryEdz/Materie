using System;
using System.Collections.Generic;
using System.Text;

namespace ListaStudenti
{
    internal class Studente
    {
        public int Matricola { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Classe { get; set; }

        public string FromatStampa(string separatore)
        {
            return $"{nameof(Matricola)}={Matricola.ToString()}" +
            $"{separatore}{nameof(Nome)}={Nome}" +
            $"{separatore}{nameof(Cognome)}={Cognome}" +
            $"{separatore}{nameof(Email)}={Email}" +
            $"{separatore}{nameof(Classe)}={Classe}";
        }

        public string FormatStampaDettaglio()
        {
            return FromatStampa("\n");
        }

        public string FormatStampaLineare()
        {
            return FromatStampa(", ");
        }
        public override string ToString()
        {
            return $"{GetType().Name}:" +
                $"{nameof(Matricola)}={Matricola.ToString()}" +
                $", {nameof(Nome)}={Nome}" +
                $", {nameof(Cognome)}={Cognome}" +
                $", {nameof(Email)}={Email}" +
                $", {nameof(Classe)}={Classe}";
        }
    }
}
