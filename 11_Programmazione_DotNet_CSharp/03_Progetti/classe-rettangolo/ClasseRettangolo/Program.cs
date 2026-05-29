using System.Security.AccessControl;

namespace ClasseRettangolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Istanza di Rettangolo!");

            Rettangolo r1 = new Rettangolo();
            r1.Base = 5;
            r1.Altezza = 3;

            string msg = $"" +
                $"\nbase={r1.Base}" +
                $"\naltezza={r1.Altezza}" +
                $"\nperimetro={r1.Perimetro()}" +
                $"\narea={r1.Area()}" +
                $"\ndiagonale={r1.Diagonale()}";

            Console.WriteLine(msg);

        }
    }
}
