namespace Quadrilateri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quadrilateri!");

            var q1 = new Quadrilatero(1.25, 1.75, 1.90, 2);
            Console.WriteLine(q1);

            var q2 = new Rettangolo(1.25, 1.5);
            Console.WriteLine(q2);

            var q3 = new Quadrato(1.25);
            Console.WriteLine(q3);
        }
    }
}
