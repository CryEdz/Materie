namespace Matite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matite!");

            Matita m1 = new Matita()
            {
                Marca = "Faber-Castell",
                Modello = "HB",
                Lunghezza = 20
            };
            Console.WriteLine(m1);
            MatitaConGommino m2 = new MatitaConGommino()
            {
                Marca = "Staedtler",
                Modello = "HB",
                Lunghezza = 20
            };

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Temperare la matita");
                Console.WriteLine("2. Cancellare (con gommino)");
                Console.WriteLine("3. Esci");
                Console.WriteLine("Scegli un'opzione (1/2/3): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    m1.Temperare();
                    Console.WriteLine($"Matita temperata! Lunghezza attuale: {m1.Lunghezza}");
                    Console.WriteLine(m1);
                }
                else if (input == "2")
                {
                    m2.cancella();
                    Console.WriteLine(m2);
                }
                else if (input == "3")
                {
                    Console.WriteLine("Arrivederci!");
                    break;
                }
                else
                {
                    Console.WriteLine("Input non valido. Inserisci '1', '2' o '3'.");
                }
            }
        }
    }
}
