namespace Veicoli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Istanze di veicoli!");

            var v1 = new Auto
            {
                Marca = "Fiat",
                Modello = "Panda",
                Cilindrata = 2500,
                Carburante = TipoCarburante.GPL,
                Colore = "Bianca",
                NumeroPorte = 3,
                Cambio = TipoCambio.MANUALE
            };

            Console.WriteLine(v1);

            var v2= new Auto
            {
                Marca = "BMW",
                Modello = "X3",
                Cilindrata = 2000,
                Carburante = TipoCarburante.DIESEL,
                Colore = "Green",
                NumeroPorte = 5,
                Cambio = TipoCambio.AUTOMATICO
            };
            Console.WriteLine(v2);

            var s1 = new Scooter
            {
                Marca = "Piaggio",
                Modello = "Beverly",
                Cilindrata = 300,
                Carburante = TipoCarburante.BENZINA,
                Colore = "Rosso",
                NumeroRuote = 2
            };

            Console.WriteLine(s1);

            var s2 = new Scooter
            {
                Marca = "Piaggio",
                Modello = "MP3",
                Cilindrata = 400,
                Carburante = TipoCarburante.BENZINA,
                Colore = "Black",
                NumeroRuote = 3
            };
            Console.WriteLine(s2);

            
        }
    }
}
