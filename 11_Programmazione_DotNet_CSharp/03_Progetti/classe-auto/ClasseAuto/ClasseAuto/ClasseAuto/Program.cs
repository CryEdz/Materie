namespace ClasseAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Classe Auto!");

            Auto a1 = new Auto()
            {
                Marca = "BMW",
                Modello = "X5",
                Cilindrata = 1990,
                Alimentazione = Alimentazione.DIESEL,
                Colore = "Nera"
            };
            Auto a2 = new Auto()
            {
                Marca = "Mercedes",
                Modello = "Class A",
                Cilindrata = 1890,
                Alimentazione = Alimentazione.GPL,
                Colore = "Bianca"
            };
            Auto a3 = new Auto()
            {
                Marca = "Fiat",
                Modello = "Panda",
                Cilindrata = 1400,
                Alimentazione = Alimentazione.METANO,
                Colore = "Grigio Topo"
            };

            Console.WriteLine();
            Console.WriteLine(a1.Stampa());
            Console.WriteLine();
            Console.WriteLine(a2.Stampa());
            Console.WriteLine();
            Console.WriteLine(a3.Stampa());
        }
    }
}
