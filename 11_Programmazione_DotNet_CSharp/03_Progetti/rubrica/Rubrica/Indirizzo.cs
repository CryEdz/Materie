namespace Rubrica
{
    internal class Indirizzo
    {
        public string Via { get; }
        public string Cap { get; }
        public string Citta { get; }
        public string Provincia { get; }

        public Indirizzo(string via, string cap, string citta, string provincia)
        {
            Via = via;
            Cap = cap;
            Citta = citta;
            Provincia = provincia;
        }

        public override string ToString()
        {
            return $"{Via}, {Cap} {Citta} ({Provincia})";
        }
    }
}
