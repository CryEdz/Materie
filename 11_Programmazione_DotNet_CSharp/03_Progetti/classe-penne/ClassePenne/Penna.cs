using System;
using System.Collections.Generic;
using System.Text;

namespace ClassePenne
{
    internal class Penna
    {
        public string marca { get; set; }
        public string colore { get; set; }
        public string tipologiaInchiostro { get; set; }

        public Penna(string marca, string colore, string tipologiaInchiostro)
        {
            this.marca = marca;
            this.colore = colore;
            this.tipologiaInchiostro = tipologiaInchiostro;
        }

        public override string ToString()
        {
            return $"Marca: {marca}, Colore: {colore}, Tipologia Inchiostro: {tipologiaInchiostro}";       
        }
    } 
}
