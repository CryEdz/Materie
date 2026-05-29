namespace Esercizio_MazzoCarte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crea il mazzo di carte
            MazzoCarte mazzo = new MazzoCarte();

            // Stampa il mazzo ordinato
            Console.WriteLine("MAZZO ORDINATO:");
            mazzo.Stampa();

            // Attende l'input dell'utente per procedere
            Console.WriteLine("\nPremere un tasto per mescolare il mazzo...");
            Console.ReadKey();

            // Mescola il mazzo 300 volte (default)
            mazzo.Mescola();

            // Stampa il mazzo mescolato
            Console.WriteLine("\n\nMAZZO MESCOLATO (300 volte):");
            mazzo.Stampa();

            // Opzione per mescolare nuovamente con numero personalizzato
            Console.WriteLine("\nDesideri mescolare di nuovo? (s/n)");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                Console.WriteLine("Quante volte? (default 300)");
                if (int.TryParse(Console.ReadLine(), out int volte) && volte > 0)
                {
                    mazzo.Mescola(volte);
                    Console.WriteLine($"\nMAZZO MESCOLATO ({volte} volte):");
                }
                else
                {
                    mazzo.Mescola();
                    Console.WriteLine("\nMAZZO MESCOLATO (300 volte):");
                }
                mazzo.Stampa();
            }
        }
    }
}
