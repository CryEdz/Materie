namespace AutomaAuto.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new(50);
            bool inEsecuzione = true;

            while (inEsecuzione)
            {
                Console.WriteLine();
                Console.WriteLine("Scegli un'azione:");
                Console.WriteLine("1 - accelera");
                Console.WriteLine("2 - frena");
                Console.WriteLine("0 - esci");
                Console.Write("Scelta: ");

                string? scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        auto.Accelera();
                        Console.WriteLine($"Velocità attuale: {auto.VelocitaAttuale} km/h");
                        break;

                    case "2":
                        auto.Frena();
                        Console.WriteLine($"Velocità attuale: {auto.VelocitaAttuale} km/h");
                        break;

                    case "0":
                        inEsecuzione = false;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        continue;
                }

                if (auto.VelocitaAttuale > 130)
                {
                    Console.WriteLine("Rallenta! Stai andando troppo forte");
                }
            }
        }
    }
}
