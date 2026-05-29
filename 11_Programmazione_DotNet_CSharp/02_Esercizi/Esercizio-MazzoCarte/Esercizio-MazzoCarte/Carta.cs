namespace Esercizio_MazzoCarte
{
    internal class Carta
    {
        public enum Semi
        {
            Denari,
            Coppe,
            Spade,
            Bastoni
        }

        public enum Valore
        {
            Asso = 1,
            Due = 2,
            Tre = 3,
            Quattro = 4,
            Cinque = 5,
            Sei = 6,
            Sette = 7,
            Cavallo = 8,
            Regina = 9,
            Re = 10
        }

        public Semi Seme { get; set; }
        public Valore ValoreCarta { get; set; }

        public Carta(Semi seme, Valore valore)
        {
            Seme = seme;
            ValoreCarta = valore;
        }

        public override string ToString()
        {
            return $"{ValoreCarta} di {Seme}";
        }
    }
}
