using System;
using System.Collections.Generic;
using System.Text;

namespace Atleti
{
    internal class Atleta:IAtleta,ITennista,INuotatore, IAtletaUniversale
    {
        //propietà
        public required string Nome { get; set; }
        public required string Cognome { get; set; }
        public int Pettorina { get; set; }
        public required string Disciplina { get; set; }


        //overriding
        //IAtleta
        public string Corro()
        {
            return "sto correndo...";
        }

        public string Salto()
        {
            return "sto saltando...";
        }
        //ITennista
        public string Dritto()
        {
            return "sto colpendo di dritto...";
        }
        public string Rovescio()
        {
            return "sto colpendo di rovescio...";
        }
        //INuotatore
        public string Dorso()
        {
            return "sto nuotando a dorso...";
        }

        public string Rana()
        {
            return "sto nuotando a rana...";
        }
        //IAtletaUniversale
        public string Mangio()
        {
            return "Sto mangiando ...";
        }

        public string  Bevo()
        {
            return "Sto bevendo ...";
        }


        public override string ToString()
        {
            return $"{GetType().Name}:" +
                $" {nameof(Nome)} = {Nome}" +
                $", {nameof(Cognome)} = {Cognome}" +
                $", {nameof(Pettorina)} = {Pettorina.ToString()}" +
                $", {nameof(Disciplina)} = {Disciplina}";
        }


    }
}
