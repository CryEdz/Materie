namespace ClassePenne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Istanza penna!");

            Penna penna1 = new Penna("Bic", "Blu", "Gel");
            Console.WriteLine(penna1.ToString());

        }
    }
}
