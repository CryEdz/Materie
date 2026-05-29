namespace ClasseAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Auto a1 = new Auto()
            {
                Marca = "BMW",
                Modello = "X5",
                Cilindrata = 2500,
                Carburante = TipoCarburante.BENZINA,
                Colore = "Black"
            };
            Console.WriteLine(a1);

                Auto a2 = new Auto()
                {
                    Marca = "Audi",
                    Modello = "A4",
                    Cilindrata = 2000,
                    Carburante = TipoCarburante.DIESEL,
                    Colore = "Red"
                };

            Auto a3 = new Auto()
            {
                Marca = "Fiat",
                Modello = "Panda",
                Cilindrata = 1200,
                Carburante = TipoCarburante.GPL,
                Colore = "White"
            };
            Console.WriteLine(a3);
        }
    }
}
