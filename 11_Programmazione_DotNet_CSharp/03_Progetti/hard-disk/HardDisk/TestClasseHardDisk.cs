using System;

namespace HardDisk
{
    internal static class TestClasseHardDisk
    {
        public static void Esegui()
        {
            ClasseHardDisk[] modelli =
            {
                new ClasseHardDisk("Seagate", 7200, 9, 1000),
                new ClasseHardDisk("Western Digital", 5400, 12, 2000),
                new ClasseHardDisk("Toshiba", 7200, 8, 500),
                new ClasseHardDisk("Samsung", 10000, 6, 2000),
                new ClasseHardDisk("Hitachi", 5900, 11, 4000)
            };

            Console.WriteLine("Confronto modelli hard disk:\n");
            foreach (ClasseHardDisk modello in modelli)
            {
                Console.WriteLine(modello);
            }

            ClasseHardDisk migliore = modelli[0];
            foreach (ClasseHardDisk modello in modelli)
            {
                if (modello.CalcolaPunteggio() > migliore.CalcolaPunteggio())
                {
                    migliore = modello;
                }
            }

            Console.WriteLine("\nModello con punteggio migliore:");
            Console.WriteLine(migliore);
        }
    }
}
