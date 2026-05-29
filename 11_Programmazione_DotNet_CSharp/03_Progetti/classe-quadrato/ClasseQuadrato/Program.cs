namespace ClasseQuadrato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Instazza di oggetti Quadrato!");
            Quadrato q1 = new Quadrato();
            Console.Write("Inserisci il lato del quadrato(metri):");

            q1.lato = double.Parse(Console.ReadLine());  //accessibilità in scrittura

            Console.WriteLine();
            Console.WriteLine($"lato: {q1.lato}  m"); //accessibilità in lettura
            Console.WriteLine($"perimetro: {q1.Perimetro()}  m");
            Console.WriteLine($"area: {q1.Area()}  m");
            Console.WriteLine($"diagonale: {q1.Diagonale()}  m");
        }
    }
}
