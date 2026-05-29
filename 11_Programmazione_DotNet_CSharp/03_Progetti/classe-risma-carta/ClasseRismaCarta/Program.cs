namespace ClasseRismaCarta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gestione Risma Carta\n");

            Console.Write("Inserisci marca risma: ");
            string? marca = Console.ReadLine();

            Console.Write("Inserisci numero fogli rimasti (0-500): ");
            string? inputFogli = Console.ReadLine();

            if (!int.TryParse(inputFogli, out int numeroFogli) || numeroFogli < 0 || numeroFogli > RismaCarta.FogliMassimi)
            {
                Console.WriteLine("Numero fogli non valido.");
                return;
            }

            RismaCarta rismaUtente = new RismaCarta(marca ?? "Sconosciuta", numeroFogli);

            Console.WriteLine("\nRisma inserita:");
            Console.WriteLine(rismaUtente);
        }
    }
}
