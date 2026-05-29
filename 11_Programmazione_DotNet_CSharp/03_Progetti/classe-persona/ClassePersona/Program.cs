namespace ClassePersona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Istanza di oggetti di tipo Persona!");

            Persona pino = new Persona("De Lillo", "Diego", new DateTime(2000, 4, 7), "Torino", TipoSesso.M);
            Console.WriteLine(pino);
            Console.WriteLine($"Eta': {pino.Eta()}");

        }
    }
}
